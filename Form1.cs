using AdhanyDesktop.Model;
using AdhanyDesktop.Services;
using System.ComponentModel;
using System.Media;
using System.Text.Json;
using Timer = System.Threading.Timer;

namespace AdhanyDesktop
{
    public partial class Form1 : Form
    {

        private readonly Service _service;
        private readonly Timer timer;
        private PrayerTimesAPI prayerTimes;
        private readonly SoundPlayer SoundPlayer = new();

        public Form1()
        {
            InitializeComponent();

            _service = new Service(new HttpClient());
            SoundPlayer.LoadCompleted += new AsyncCompletedEventHandler(SoundPlayer_LoadCompleted);

            // Create a timer that will call the NotifyPrayerTime but don't start it yet
            // the timer will be started when the user saves the settings or loads from saved settings
            timer = new Timer(
                new TimerCallback(NotifyPrayerTime),
                null,
                Timeout.InfiniteTimeSpan,
                Timeout.InfiniteTimeSpan);

            // Check the radio button for the saved Adhan type
            if (Properties.Settings.Default.AdhanType == "full")
            {
                radioFull.Checked = true;
                Properties.Settings.Default.AdhanDurationSeconds = 190; // 3:10 minutes
            }
            else
            {
                radioTakbeer.Checked = true;
                Properties.Settings.Default.AdhanDurationSeconds = 22;
            }
        }

        /* 
         * This method is called when the form is loaded.
         * Populates the method combo box with the available methods 
         * and displays the prayer times from the saved settings if they exist.
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            BindMethodBox();
            LoadFromSettings();
        }

        /// <summary>
        /// This is called by the timer to check if it's time for a prayer
        /// and show a notification if it is.
        /// </summary>
        /// <param name="state"></param>
        private void NotifyPrayerTime(object state)
        {
            if (prayerTimes == null)
                return;

            Dictionary<string, string> schedualedTimes = new Dictionary<string, string>();

            schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Fajr), prayerTimes.Data.Timings.Fajr);
            schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Sunrise), prayerTimes.Data.Timings.Sunrise);
            schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Dhuhr), prayerTimes.Data.Timings.Dhuhr);
            schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Asr), prayerTimes.Data.Timings.Asr);
            schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Maghrib), prayerTimes.Data.Timings.Maghrib);
            schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Isha), prayerTimes.Data.Timings.Isha);

            var currentTime = DateTime.Now.ToString("HH:mm");
            foreach (var time in schedualedTimes)
            {
                if (time.Value == currentTime)
                {
                    int adhanDurationMs = Properties.Settings.Default.AdhanDurationSeconds * 1000;
                    ShowNotification(time.Key, adhanDurationMs);
                    LoadSoundAsync();
                    break;
                }
            }
        }

        private void LoadSoundAsync()
        {
            try
            {
                var adhanType = Properties.Settings.Default.AdhanType;
                SoundPlayer.SoundLocation = adhanType == "full" ? @"Audio\Adhan_Al_Deghreri.wav" : @"Audio\Takbeer_Mishari.wav";
                SoundPlayer.LoadAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred loading the Adhan\n" +
                    "We will try again next prayer time", "Warning");
            }
        }

        /// <summary>
        /// This is called to show a notification with the prayer name
        /// </summary>
        /// <param name="prayerName"></param>
        private void ShowNotification(string prayerName, int adhanDurationMs)
        {
            NotifyIcon.Icon = new Icon(@"icon\call.ico");
            NotifyIcon.Text = "Click to stop the Adhan";
            NotifyIcon.BalloonTipText = $"It's {prayerName} time";
            NotifyIcon.BalloonTipTitle = "Adhan";
            NotifyIcon.BalloonTipIcon = ToolTipIcon.None;
            NotifyIcon.Visible = true;
            NotifyIcon.ShowBalloonTip(2000);
            // hide the tray icon after the adhan duration
            if (adhanDurationMs > 0)
                Task.Delay(adhanDurationMs).ContinueWith(t => NotifyIcon.Visible = false);

        }

        private void SoundPlayer_LoadCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            if (SoundPlayer.IsLoadCompleted)
            {
                try
                {
                    SoundPlayer.Play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred playing the Adhan", "Warning");
                }
            }
        }

        /// <summary>
        /// Checks for saved settings and displays the prayer times if they exist
        /// </summary>
        private async void LoadFromSettings()
        {
            bool settingsExist = Properties.Settings.Default.Country != String.Empty
                && Properties.Settings.Default.City != String.Empty;

            if (settingsExist)
            {
                // populate the combo box values from the saved settings
                // city's value is being set in the ddl_country_SelectedValueChanged
                ddl_country.SelectedItem = Properties.Settings.Default.Country;
                ddl_method.SelectedValue = Properties.Settings.Default.Method;

                statusProgressBar.Value = 25;
                // get the prayer times for these settings
                prayerTimes = await _service.GetPrayerTimesAsync(
                    Properties.Settings.Default.Country,
                    Properties.Settings.Default.City,
                    Properties.Settings.Default.Method);

                // Populate the table with the prayer times
                statusProgressBar.Value = 50;
                DisplayPrayerTimes(prayerTimes);

                statusProgressBar.Value = 100;
                statusLabel.Text = "Prayer times from saved settings";
                // start the timer with 30 seconds interval
                timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(59));
            }
            else
            {
                statusLabel.Text = "Please select a country and city";

            }
        }

        /// <summary>
        /// This is called to populate the method combo box with the available methods
        /// </summary>
        private void BindMethodBox()
        {
            var methods = new List<CalculationMethod>();

            // Create method objects and add them to the methods list
            foreach (var kvp in CalculationMethod.methodDictionary)
            {
                methods.Add(new CalculationMethod { id = kvp.Key, name = kvp.Value });
            }
            // Bind the list to the combo box
            ddl_method.DataSource = methods;
            ddl_method.DisplayMember = "name";
            ddl_method.ValueMember = "id";
        }

        private City[] BindCityBox()
        {
            var countryName = ddl_country.SelectedItem.ToString();
            City[] cities = null;

            // Get the cities for the selected country from the Json file
            if (File.Exists("cities.json"))
            {
                var json = File.ReadAllText("cities.json");
                var countries = JsonSerializer.Deserialize<CountryCityModel>(json);

                if (countries == null)
                {
                    statusLabel.Text = "Error occurred fetching data, try again later.";
                    return cities;
                }

                // Find the country by name then its cities
                var selectedCountry = countries.countries.FirstOrDefault(c => c.name == countryName);
                if (selectedCountry != null)
                {
                    cities = selectedCountry.cities;
                    ddl_city.DataSource = cities;
                    ddl_city.DisplayMember = "Name";
                    ddl_city.ValueMember = "Name";

                    return cities;
                }
                else
                {
                    statusLabel.Text = "Error occurred fetching data, try again later.";
                }
            }
            return cities;

        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            statusProgressBar.Value = 0;
            table_fetchedData.Visible = false;
            statusLabel.Text = "Fetching Data...";

            try
            {
                var country = ddl_country.SelectedItem.ToString();
                City city = (City)ddl_city.SelectedItem;
                var method = (CalculationMethod)ddl_method.SelectedItem;
                var adhanType = radioFull.Checked ? "full" : "short";
                var adhanDuration = radioFull.Checked ? 190 : 22;

                statusProgressBar.Value = 25;
                // Save the settings
                Properties.Settings.Default.Country = country;
                Properties.Settings.Default.City = city.name;
                Properties.Settings.Default.Method = method.id;
                Properties.Settings.Default.AdhanType = adhanType;
                Properties.Settings.Default.AdhanDurationSeconds = adhanDuration;
                Properties.Settings.Default.Save();

                statusProgressBar.Value = 50;
                prayerTimes = await _service.GetPrayerTimesAsync(country, city.name, method.id);

                if (prayerTimes == null)
                {
                    statusProgressBar.Value = 0;
                    statusLabel.Text = "Error occurred fetching data, try again later.";
                    return;
                }

                statusProgressBar.Value = 75;
                res_location.Text = city + ", " + country;
                DisplayPrayerTimes(prayerTimes);


                statusProgressBar.Value = 100;
                statusLabel.Text = "Done, you can minimize the app now.";
                MessageBox.Show("Prayer times fetched successfully\n\n" +
                    "You can minimize the app, and it will notify you when it's time for prayer.", "Success");
                // start the timer with 59 seconds interval
                timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(59));
            }
            catch (Exception ex)
            {
                statusProgressBar.Value = 0;
                statusLabel.Text = "Error occurred fetching data";
                MessageBox.Show("Please select Country and City in order to save and show prayer times", "Warning");
            }



        }

        /// <summary>
        /// This is called to display the prayer times in the table from the PrayerTimesAPI object
        /// </summary>
        /// <param name="prayerTimes">The PrayerTimesAPI object to display</param>
        private void DisplayPrayerTimes(PrayerTimesAPI prayerTimes)
        {
            res_location.Text = prayerTimes.Location.City + ", " + prayerTimes.Location.Country;
            res_date.Text = prayerTimes.Data.Date.gregorian.date;
            res_hijri.Text = prayerTimes.Data.Date.hijri.date;

            try
            {
                // Displaying times in 12-hour format
                res_fajr.Text = DateTime.Parse(prayerTimes.Data.Timings.Fajr).ToString("hh:mm tt");
                res_sunrise.Text = DateTime.Parse(prayerTimes.Data.Timings.Sunrise).ToString("hh:mm tt");
                res_dhuhr.Text = DateTime.Parse(prayerTimes.Data.Timings.Dhuhr).ToString("hh:mm tt");
                res_asir.Text = DateTime.Parse(prayerTimes.Data.Timings.Asr).ToString("hh:mm tt");
                res_maghrib.Text = DateTime.Parse(prayerTimes.Data.Timings.Maghrib).ToString("hh:mm tt");
                res_isha.Text = DateTime.Parse(prayerTimes.Data.Timings.Isha).ToString("hh:mm tt");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("An error occurred while parsing the time. Please ensure the time is in a valid 24-hour format.");
                // Displaying times in 24-hour format if the parsing failed
                res_fajr.Text = prayerTimes.Data.Timings.Fajr;
                res_sunrise.Text = prayerTimes.Data.Timings.Sunrise;
                res_dhuhr.Text = prayerTimes.Data.Timings.Dhuhr;
                res_asir.Text = prayerTimes.Data.Timings.Asr;
                res_maghrib.Text = prayerTimes.Data.Timings.Maghrib;
                res_isha.Text = prayerTimes.Data.Timings.Isha;
            }

            table_fetchedData.Visible = true;
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            table_fetchedData.Visible = false;
            ddl_country.SelectedIndex = -1;
            ddl_city.SelectedIndex = -1;
            ddl_city.DataSource = null;
            ddl_method.SelectedIndex = 0;
            statusLabel.Text = "";
            statusProgressBar.Value = 0;
            Service.DeleteLocalFile();
            prayerTimes = null;
            timer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);

            MessageBox.Show("Settings reset successfully");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            StopAdhanMessageBox();
        }

        private void StopAdhanMessageBox()
        {
            string message = "Do you want to stop the Adhan?";
            string caption = "Adhan";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                SoundPlayer.Stop();
                NotifyIcon.Visible = false;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the trayIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                TrayIcon.Visible = true;
                // the timeout parameter is deprecated (has no affect)
                // but still needs to be passed
                TrayIcon.ShowBalloonTip(2000);
            }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            StopAdhanMessageBox();
        }

        private void ddl_country_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ddl_country.SelectedIndex > -1)
            {
                var citiesList = BindCityBox();
                if (Properties.Settings.Default.Country == ddl_country.SelectedItem.ToString())
                {
                    var savedCity = citiesList.FirstOrDefault(c => c.name == Properties.Settings.Default.City);
                    if (savedCity != null)
                        ddl_city.SelectedItem = savedCity;
                }
            }
        }

        private void showTrayIconMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            TrayIcon.Visible = false;
        }
    }
}
