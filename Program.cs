using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherInfoTool
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter a city name: ");
            string cityName = Console.ReadLine();

            decimal latitude = 0;
            decimal longitude = 0;

            string json = File.ReadAllText("cities.json");
            dynamic cityData = JsonConvert.DeserializeObject<dynamic>(json);

            if (cityData != null && cityData.cities != null)
            {
                foreach (var city in cityData.cities)
                {
                    if (city.city != null && city.lat != null && city.lng != null)
                    {
                        string name = city.city.ToString();
                        decimal lat = city.lat;
                        decimal lon = city.lng;

                        if (name.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                        {
                            latitude = lat;
                            longitude = lon;
                            break;
                        }
                    }
                }
            }

            if (latitude == 0 || longitude == 0)
            {
                Console.WriteLine("City not found or data not available.");
                return;
            }

            string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";

            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(apiUrl);
                dynamic weatherData = JsonConvert.DeserializeObject<dynamic>(response);

                if (weatherData != null && weatherData.current_weather != null)
                {
                    decimal temperature = weatherData.current_weather.temperature;
                    decimal windspeed = weatherData.current_weather.windspeed;


                    Console.WriteLine($"Temperature: {temperature}°C");
                    Console.WriteLine($"Windspeed: {windspeed} km/h");
                }
                else
                {
                    Console.WriteLine("Weather data not available.");
                }
            }
        }
    }
}
