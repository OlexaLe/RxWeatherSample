using System;
using Refit;
using RxWeatherSample.Models;

namespace RxWeatherSample.Services
{
    public interface IApiOpenWeather
    {
        [Get("/data/2.5/weather?q={city}&appid={appId}&units=metric")]
        IObservable<RootObject> GetWeather(string city, string appId);
    }
}