using AdhanyDesktop.Model;
using System.Diagnostics.Metrics;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using static AdhanyDesktop.Model.PrayerTimesAPI;

namespace AdhanyDesktop
{
    public partial class Form1 : Form
    {
        private static HttpClient httpClient;
        private static string timingsUri = "http://api.aladhan.com/v1/timingsByCity?city={0}&country={1}&method={2}";

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.aladhan.com/v1/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        /* 
         * This method is called when the form is loaded.
         * Populates the method combo box with the available methods.
         */
        private async void Form1_Load(object sender, EventArgs e)
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

            // Check for saved settings
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Country) || !String.IsNullOrEmpty(Properties.Settings.Default.City))
            {
                // populate the combo boxes
                ddl_country.SelectedItem = Properties.Settings.Default.Country;
                ddl_city.SelectedItem = Properties.Settings.Default.City;
                ddl_method.SelectedValue = Properties.Settings.Default.Method;

                statusProgressBar.Value = 25;
                // get the prayer times for these settings
                PrayerTimesAPI prayerTimes = await GetPrayerTimesAsync(
                    Properties.Settings.Default.Country,
                    Properties.Settings.Default.City,
                    Properties.Settings.Default.Method);

                // Populate the table with the prayer times
                statusProgressBar.Value = 50;
                displayPrayerTimes(prayerTimes);

                statusProgressBar.Value = 100;
                statusLabel.Text = "Prayer times from saved settings";
            }
            else
            {
                statusLabel.Text = "Please select a country and city";

            }
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
            PrayerTimesAPI prayerTimes = await GetPrayerTimesAsync(country, city, method.id);

            statusProgressBar.Value = 75;
            res_location.Text = city + ", " + country;
            displayPrayerTimes(prayerTimes);


            statusProgressBar.Value = 100;
            statusLabel.Text = "Done";
            MessageBox.Show("Prayer times fetched successfully");
        }


        /// <summary>
        /// This fetches the prayer times from the API using the given parameters, and returns a PrayerTimesAPI object.
        /// If the data has been fetched recently, it will be returned from the cache.
        /// the method parameter is the calculation method index number <see cref="https://aladhan.com/calculation-methods"/>
        /// </summary>
        /// <param name="country">Country Name or Code</param>
        /// <param name="city">City Name</param>
        /// <param name="method">The Method index number</param>
        /// <returns></returns>
        private async Task<PrayerTimesAPI> GetPrayerTimesAsync(string country, string city, int method)
        {
            PrayerTimesAPI prayerTimes = null;
            var uri = string.Format(timingsUri, city, country, method);

            if (File.Exists("savedPrayerTimes.json"))
            {
                var savedPrayerTimes = await File.ReadAllTextAsync("savedPrayerTimes.json");
                prayerTimes = JsonSerializer.Deserialize<PrayerTimesAPI>(savedPrayerTimes);

                var formattedDate = prayerTimes.Data.Date.gregorian.date;

                bool isSameDate = formattedDate == DateTime.Now.ToString("dd-MM-yyyy");
                bool isSameCity = prayerTimes?.Location.City == city;
                bool isSameCountry = prayerTimes?.Location.Country == country;

                if (isSameDate && isSameCity && isSameCountry)
                    return prayerTimes;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await httpClient.SendAsync(request);
            try
            {
                response.EnsureSuccessStatusCode();
                prayerTimes = await response.Content.ReadFromJsonAsync<PrayerTimesAPI>();
                prayerTimes.Location = new Location { City = city, Country = country };
                saveToLocalFile(prayerTimes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return prayerTimes;
        }

        private void saveToLocalFile(PrayerTimesAPI prayerTimes)
        {
            var json = JsonSerializer.Serialize(prayerTimes);
            File.WriteAllText("savedPrayerTimes.json", json);
        }
        private void deleteLocalFile()
        {
            if (File.Exists("savedPrayerTimes.json"))
                File.Delete("savedPrayerTimes.json");
        }

        /// <summary>
        /// This is called to display the prayer times in the table from the PrayerTimesAPI object
        /// </summary>
        /// <param name="prayerTimes">The PrayerTimesAPI object to display</param>
        private void displayPrayerTimes(PrayerTimesAPI prayerTimes)
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
            deleteLocalFile();
            statusLabel.Text = "";
            statusProgressBar.Value = 0;
            MessageBox.Show("Settings reset successfully");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}