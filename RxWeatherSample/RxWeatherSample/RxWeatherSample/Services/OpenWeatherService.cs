using System;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using Akavache;
using Refit;
using RxWeatherSample.Models;

namespace RxWeatherSample.Services
{
    public class OpenWeatherService
    {
        public IObservable<string> GetTemperature(string city)
        {
            return BlobCache.LocalMachine.GetAndFetchLatest(city, () => FetchWeather(city))
                .Select(ExtractTemperature);
        }

        private string ExtractTemperature(RootObject response)
        {
            return response.Main.Temperature.ToString();
        }

        private IObservable<RootObject> FetchWeather(string city)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://api.openweathermap.org") };
            var api = RestService.For<IApiOpenWeather>(client);
            return api.GetWeather(city, Constants.ApiKey);
        }
    }
}