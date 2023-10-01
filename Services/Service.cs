using AdhanyDesktop.Model;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using static AdhanyDesktop.Model.PrayerTimesAPI;

namespace AdhanyDesktop.Services
{
    public class Service
    {
        private static HttpClient httpClient;
        private static string timingsUri = "http://api.aladhan.com/v1/timingsByCity?city={0}&country={1}&method={2}";

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

        public void saveToLocalFile(PrayerTimesAPI prayerTimes)
        {
            var json = JsonSerializer.Serialize(prayerTimes);
            File.WriteAllText("savedPrayerTimes.json", json);
        }
        public void deleteLocalFile()
        {
            if (File.Exists("savedPrayerTimes.json"))
                File.Delete("savedPrayerTimes.json");
        }
    }
}
