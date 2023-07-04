using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace WeatherInfoTool.Tests
{
    public class WeatherInfoToolTests
    {
        private readonly HttpClient httpClient;

        public WeatherInfoToolTests()
        {
            httpClient = new HttpClient();
        }

        [Fact]
        public async Task GetWeatherInfo_ValidCity_ReturnsWeatherData()
        {
            // Arrange
            var cityName = "Kolkata";
            var expectedTemperature = 30.5m;
            var expectedWindSpeed = 10.2m;

            var json = File.ReadAllText("cities.json");           
            dynamic cityData = JsonConvert.DeserializeObject(json);
            var city = FindCityByName(cityData, cityName);                   
            decimal latitude = city.lat;
            decimal longitude = city.lng;

            var apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";

            // Act
            var response = await httpClient.GetStringAsync(apiUrl);
            dynamic weatherData = JsonConvert.DeserializeObject(response);
            decimal temperature = weatherData.current_weather.temperature;
            decimal windSpeed = weatherData.current_weather.windspeed;

            // Assert
            Assert.Equal(expectedTemperature, temperature);
            Assert.Equal(expectedWindSpeed, windSpeed);
        }
        private dynamic FindCityByName(dynamic cityData, string cityName)
        {
            foreach (var city in cityData.cities)
            {
                if (city.city != null && city.lat != null && city.lng != null)
                {
                    string name = city.city.ToString();

                    if (name.Equals(cityName, StringComparison.OrdinalIgnoreCase))
                    {
                        return city;
                    }
                }
            }

            return null;
        }
    }
}
