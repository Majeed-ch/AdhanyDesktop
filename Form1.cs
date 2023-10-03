using AdhanyDesktop.Model;
using AdhanyDesktop.Services;
using System.ComponentModel;
using System.Media;
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

            timer = new Timer(
                new TimerCallback(NotifyPrayerTime),
                null,
                TimeSpan.FromSeconds(30),
                TimeSpan.FromSeconds(10));
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
            Dictionary<string, string> schedualedTimes = new Dictionary<string, string>();
            if (prayerTimes != null)
            {
                schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Fajr), prayerTimes.Data.Timings.Fajr);
                schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Sunrise), prayerTimes.Data.Timings.Sunrise);
                schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Dhuhr), prayerTimes.Data.Timings.Dhuhr);
                schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Asr), prayerTimes.Data.Timings.Asr);
                schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Maghrib), prayerTimes.Data.Timings.Maghrib);
                schedualedTimes.Add(nameof(prayerTimes.Data.Timings.Isha), prayerTimes.Data.Timings.Isha);
            }

            var currentTime = "05:43"; //DateTime.Now.ToString("HH:mm");
            foreach (var time in schedualedTimes)
            {
                if (time.Value == currentTime)
                {
                    ShowNotification(time.Key);
                    LoadSoundAsync();
                    break;
                }
            }
        }

        private void LoadSoundAsync()
        {
            try
            {
                SoundPlayer.SoundLocation = @"C:\ASP_Projects\AdhanyDesktop\Audio\Adhan_Al_Deghreri.wav";
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
        private void ShowNotification(string prayerName)
        {

            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.BalloonTipText = $"It's {prayerName} time";
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(2000);
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
                ddl_country.SelectedItem = Properties.Settings.Default.Country;
                ddl_city.SelectedItem = Properties.Settings.Default.City;
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

        private async void btn_save_Click(object sender, EventArgs e)
        {
            statusProgressBar.Value = 0;
            table_fetchedData.Visible = false;
            statusLabel.Text = "Fetching Data...";

            var country = ddl_country.SelectedItem.ToString();
            var city = ddl_city.SelectedItem.ToString();
            var method = (CalculationMethod)ddl_method.SelectedItem;

            statusProgressBar.Value = 25;
            // Save the settings
            Properties.Settings.Default.Country = country;
            Properties.Settings.Default.City = city;
            Properties.Settings.Default.Method = method.id;
            Properties.Settings.Default.Save();

            statusProgressBar.Value = 50;
            prayerTimes = await _service.GetPrayerTimesAsync(country, city, method.id);

            statusProgressBar.Value = 75;
            res_location.Text = city + ", " + country;
            DisplayPrayerTimes(prayerTimes);


            statusProgressBar.Value = 100;
            statusLabel.Text = "Done";
            MessageBox.Show("Prayer times fetched successfully");
        }

        /// <summary>
        /// This is called to display the prayer times in the table from the PrayerTimesAPI object
        /// </summary>
        /// <param name="prayerTimes">The PrayerTimesAPI object to display</param>
        private void DisplayPrayerTimes(PrayerTimesAPI prayerTimes)
        {
            res_location.Text = prayerTimes.Location.City + ", " + prayerTimes.Location.Country;
            res_date.Text = prayerTimes.Data.Date.readable;
            res_hijri.Text = prayerTimes.Data.Date.hijri.date;
            res_fajr.Text = prayerTimes.Data.Timings.Fajr;
            res_sunrise.Text = prayerTimes.Data.Timings.Sunrise;
            res_dhuhr.Text = prayerTimes.Data.Timings.Dhuhr;
            res_asir.Text = prayerTimes.Data.Timings.Asr;
            res_maghrib.Text = prayerTimes.Data.Timings.Maghrib;
            res_isha.Text = prayerTimes.Data.Timings.Isha;

            table_fetchedData.Visible = true;
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            table_fetchedData.Visible = false;
            ddl_country.Text = String.Empty;
            ddl_city.Text = String.Empty;
            ddl_method.Text = String.Empty;
            _service.deleteLocalFile();
            statusLabel.Text = "";
            statusProgressBar.Value = 0;
            MessageBox.Show("Settings reset successfully");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            string message = "Do you want to stop the athan?";
            string caption = "Adhan";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                // will need to stop playing the adhan sound
                SoundPlayer.Stop();
            }
        }
    }
}
