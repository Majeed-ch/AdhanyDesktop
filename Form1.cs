using AdhanyDesktop.Model;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            statusProgressBar.Value = 0;
            table_fetchedData.Visible = false;
            statusLabel.Text = "Fetching Data...";

            var country = ddl_country.SelectedItem.ToString();
            var city = ddl_city.SelectedItem.ToString();
            var method = (CalculationMethod)ddl_method.SelectedItem;

            statusProgressBar.Value = 25;

            PrayerTimesAPI prayerTimes = await GetPrayerTimesAsync(country, city, method.id);

            statusProgressBar.Value = 50;

            res_location.Text = city + ", " + country;

            res_date.Text = prayerTimes.Data.Date.readable;
            res_hijri.Text = prayerTimes.Data.Date.hijri.date;
            res_fajr.Text = prayerTimes.Data.Timings.Fajr;
            res_sunrise.Text = prayerTimes.Data.Timings.Sunrise;
            res_dhuhr.Text = prayerTimes.Data.Timings.Dhuhr;
            res_asir.Text = prayerTimes.Data.Timings.Asr;
            res_maghrib.Text = prayerTimes.Data.Timings.Maghrib;
            res_isha.Text = prayerTimes.Data.Timings.Isha;

            statusProgressBar.Value = 75;

            table_fetchedData.Visible = true;

            statusProgressBar.Value = 100;
            statusLabel.Text = "Done";
            MessageBox.Show("Prayer times fetched successfully");
        }

        private void Form1_Load(object sender, EventArgs e)
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


        private async Task<PrayerTimesAPI> GetPrayerTimesAsync(string country, string city, int method)
        {
            PrayerTimesAPI prayerTimes = null;
            var uri = string.Format(timingsUri, city, country, method);

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = await httpClient.SendAsync(request);

            try
            {
                response.EnsureSuccessStatusCode();
                prayerTimes = await response.Content.ReadFromJsonAsync<PrayerTimesAPI>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return prayerTimes;
        }
    }
}