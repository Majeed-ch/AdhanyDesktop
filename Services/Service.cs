using AdhanyDesktop.Model;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace AdhanyDesktop.Services
{
    public class Service
    {
        private static HttpClient httpClient;
        private static string timingsUri = "http://api.aladhan.com/v1/timingsByCity";

        public Service(HttpClient client)
        {
            httpClient = client;
            httpClient.BaseAddress = new Uri("http://api.aladhan.com/v1/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
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
        public async Task<PrayerTimesAPI> GetPrayerTimesAsync(string country, string city, int method)
        {
            PrayerTimesAPI prayerTimes = null;
            string uri = method == 100 ? 
                timingsUri + $"?city={city}&country={country}" :
                timingsUri + $"?city={city}&country={country}&method={method}";

            // Check if the data has been fetched recently and saved to a local file
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

            // Fetch the new data from the API if the data is not cached
            // or if the data is cached but it's old, or user changed the city or country
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            try
            {
                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                prayerTimes = await response.Content.ReadFromJsonAsync<PrayerTimesAPI>();
                prayerTimes.Location = new Location { City = city, Country = country };
                SaveToLocalFile(prayerTimes);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error occurred fetching todays prayer times\n" +
                    "Make sure you're connected to the Internet!\n\n" +
                    "Showing last saved prayer times", "Error!");
                return prayerTimes;
            }
            // return null if something went wrong
            return prayerTimes;
        }

        /// <summary>
        /// Saves the prayer times to a local file
        /// </summary>
        /// <param name="prayerTimes"></param>
        public static void SaveToLocalFile(PrayerTimesAPI prayerTimes)
        {
            var json = JsonSerializer.Serialize(prayerTimes);
            File.WriteAllText("savedPrayerTimes.json", json);
        }

        /// <summary>
        /// Deletes the local file that contains the prayer times
        /// </summary>
        public static void DeleteLocalFile()
        {
            if (File.Exists("savedPrayerTimes.json"))
                File.Delete("savedPrayerTimes.json");
        }
    }
}
