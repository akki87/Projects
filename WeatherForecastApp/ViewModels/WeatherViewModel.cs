using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherForecastApp.Helper;
using WeatherForecastApp.Models;
using WeatherForecastApp.Service;

public class WeatherViewModel : INotifyPropertyChanged
{
    #region private properties
    private WeatherResponse _weatherData;
    private readonly WeatherService _weatherService;
    private readonly GetLocationService _locationService;
    private readonly DataFetcher _dataFetcher;
    public ICommand FetchWeatherCommand { get; }
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion

    #region Constructor
    public WeatherViewModel()
    {
        _weatherService = new WeatherService();
        _locationService = new GetLocationService();
        _dataFetcher = new DataFetcher();

        FetchWeatherCommand = new RelayCommand(async () => await FetchWeatherForDeviceLocation());
        Task.Run(async () => await FetchWeatherForDeviceLocation());
    }
    #endregion

    #region getter
    public WeatherResponse WeatherData
    {
        get => _weatherData;
        set
        {
            _weatherData = value;
            OnPropertyChanged(nameof(WeatherData));
            OnPropertyChanged(nameof(Day));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(Location));
            OnPropertyChanged(nameof(Temps));
            OnPropertyChanged(nameof(Description));
            OnPropertyChanged(nameof(Humidity));
            OnPropertyChanged(nameof(Wind));
            OnPropertyChanged(nameof(Others));
            OnPropertyChanged(nameof(Temperature));
            OnPropertyChanged(nameof(FeelsLike));
        }
    }
    #endregion

    #region Public properties (for Binding)
    public string Day => _weatherData != null ? DateHelper.GetDayOfWeek(_weatherData.dt) : DateTime.Today.DayOfWeek.ToString();

    public string Date => _weatherData != null ? DateHelper.FormatDate(_weatherData.dt) : DateHelper.FormatDate(DateTime.UtcNow);

    public string Location => _weatherData != null ? $"{_weatherData.name}, {_weatherData.sys.country.ToUpper()}" : "Unknown Location";

    public string Temperature => _weatherData != null ? $"{_weatherData.main.temp:F1} °C" : "N/A";

    public string FeelsLike => _weatherData != null ? $"feels like: {_weatherData.main.feels_like:F1} °C" : "N/A";

    public string Temps => _weatherData != null ? $"Max: {_weatherData.main.temp_max:F1} °C, Min: {_weatherData.main.temp_min:F1} °C" : "N/A";

    public string Description => _weatherData?.weather?[0].description ?? "nothing feels";

    public string Humidity => _weatherData != null ? $"{_weatherData.main.humidity}%" : "0%";

    public string Wind => _weatherData != null ? $"{_weatherData.wind.speed:F1} km/h" : "0km/h";

    public string Others => _weatherData != null
        ? $"Sunrise: {DateHelper.FormatTime(_weatherData.sys.sunrise)}\nSunset: {DateHelper.FormatTime(_weatherData.sys.sunset)}"
        : "Sunrise: ---\nSunset: ---";

    public string WeatherBackground => WeatherConditionHelper.GetWeatherBackgroundImage(_weatherData);
    #endregion

    #region public methods
    public async Task FetchWeatherForDeviceLocation()
    {
        var (latitude, longitude) = await _locationService.GetDeviceLocationAsync();
        WeatherData = await _dataFetcher.FetchDataAsync(() => _weatherService.GetWeatherAsync(latitude, longitude));
    }
    #endregion

    #region private methods
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
