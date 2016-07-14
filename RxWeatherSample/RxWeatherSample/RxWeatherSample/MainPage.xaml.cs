using RxWeatherSample.ViewModels;
using Xamarin.Forms;

namespace RxWeatherSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}