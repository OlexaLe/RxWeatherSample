using System;
using System.Linq;
using System.Reactive.Linq;
using Reactive.Bindings;
using RxWeatherSample.Services;

namespace RxWeatherSample.ViewModels
{
    public class MainViewModel
    {
        private readonly OpenWeatherService _service = new OpenWeatherService();

        public MainViewModel()
        {
            Temperature = City
                .Throttle(TimeSpan.FromMilliseconds(500))
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(_service.GetTemperature)
                .Switch()
                .ToReadOnlyReactiveProperty("n/a");
        }

        public ReactiveProperty<string> City { get; } = new ReactiveProperty<string>();
        public ReadOnlyReactiveProperty<string> Temperature { get; }
    }
}