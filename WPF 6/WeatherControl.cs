using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_6
{
    enum Precipitation
    {
        sunny,
        cloudy,
        fog,
        rain,
        hail,
        snow
    }


    class WeatherControl: System.Windows.DependencyObject
    {
        private Precipitation precipitation;
        private string wind_direction;
        private int wind_speed;
        public string WindDirection { get; set; }

        public int WindSpeed { get; set; }

        public WeatherControl(string winddirection, int windspeed, Precipitation precipitation)
        {
            this.WindDirection = winddirection;
            this.WindSpeed = windspeed;
            this.precipitation = precipitation;

        }

        public static readonly DependencyProperty TempProperty;

        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }

        static WeatherControl()
        {
            TempProperty = DependencyProperty.Register(
            nameof(Temp),
            typeof(int),
            typeof(WeatherControl),
            new FrameworkPropertyMetadata(
                0,
                FrameworkPropertyMetadataOptions.AffectsMeasure |
                FrameworkPropertyMetadataOptions.AffectsRender,
                null,
                new CoerceValueCallback(CoerceTemp)),
            new ValidateValueCallback(ValidateTemp));
        }

        private static bool ValidateTemp(object value)
        {
            int v = (int)value;

            if (v >= -50 && v <= 50)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;

            if (v >= -50 && v <= 50)
            {
                return v;
            }

            else
            {
                return null;
            }
        }

        public string Print()
        {
            return $"{WindDirection}  {WindSpeed} {WindSpeed} {precipitation}";
        }  
    }
}
