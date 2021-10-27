using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsApplication1
{
    public interface Observer
    {
        void Update(float temp, float humidity, float pressure);
    }

    public interface DisplayElement
    {
        void Display();
    }

    public interface Subject
    {
        void RegisterObserver(Observer o);
        void RemoveObserver(Observer o);
        void NotifyObservers();        
    }

    public class WeatherData : Subject  
    {
        public void MeasurementChanged()
        {
            NotifyObservers();
        }

        /// <summary>
        /// Funkcija koja postavlja nove vrednosti za temperaturu, vlaznost i pritisak
        /// </summary>
        /// <param name="temperature"></param>
        /// <param name="humidity"></param>
        /// <param name="pressure"></param>
        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementChanged();
        }
        
        float temperature = 0.0F;

        public float GetTemperature()
        {
            return this.temperature;
        }

        float pressure = 0.0F;

        public float GetPressure()
        {
            return this.pressure;
        }

        float humidity = 0.0F;

        public float GetHumidity()
        {
            return this.humidity;
        }

        #region Subject Members

        ArrayList observers = new ArrayList();

        public void RegisterObserver(Observer o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(Observer o)
        {
            if (observers.IndexOf(o) >= 0)
            {
                observers.Remove(observers.IndexOf(o));
            }
        }

        public void NotifyObservers()
        {
            foreach (Observer obs in observers)
            {
                obs.Update(this.GetTemperature(), this.GetHumidity(), this.GetPressure());
            }
        }

        #endregion
    }

    public class CurrentConditionDisplay : Observer, DisplayElement
    {

        Subject weatherData;

        public CurrentConditionDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            MessageBox.Show(this.temperature.ToString() + " " + this.humidity.ToString());
        }

        /// <summary>
        /// Ovaj displej ima pokazuje smao temperaturu i vlaznost
        /// </summary>
        float temperature;
        float humidity;

        public void Update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            Display();
        }

    }

    public class StatisticsDisplay : Observer, DisplayElement
    {
        Subject weatherData;

        public StatisticsDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        /// <summary>
        /// Ovaj displej pokazuje samo statisticke prosecne vrednosti
        /// </summary>
        float avgtemperature;
        float avghumidity;
        float avgpressure;
        int brojMerenja = 0;

        public void Display()
        {
            MessageBox.Show(this.ToString() + " " + this.avgtemperature.ToString() + " " + this.avghumidity.ToString() + " " + this.avgpressure.ToString());
        }

        public void Update(float temp, float hum, float press)
        {
            avgtemperature = (avgtemperature * brojMerenja + temp) / (brojMerenja + 1);
            avghumidity = (avghumidity * brojMerenja + hum) / (brojMerenja + 1);
            avgpressure = (avgpressure * brojMerenja + press) / (brojMerenja + 1);
            brojMerenja++;
            Display();
        }
    }

    public class ForecastDisplay : Observer, DisplayElement
    {
        Subject weatherData;

        public ForecastDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            this.weatherData.RegisterObserver(this);
        }

        float temperature;
        public void Display()
        {
            MessageBox.Show(this.ToString() + " " + this.temperature.ToString());
        }

        int currentPos = 0;
        ArrayList lastThree = new ArrayList(new float[] { 0,0,0});
        public void Update(float temp, float hum, float press)
        {
            lastThree[currentPos] = temp;
            currentPos = (currentPos + 1) % 3;

            float forecastTemp = (float.Parse(lastThree[0].ToString()) + float.Parse(lastThree[1].ToString()) + float.Parse(lastThree[2].ToString()));
            this.temperature = forecastTemp / 3;
            this.Display();
        }
    }

    ///Kako se koriste kreirane klase
    public class WeatherStation
    {
        public static void Use()
        {
            WeatherData wD = new WeatherData();
            CurrentConditionDisplay ccd = new CurrentConditionDisplay(wD);
            StatisticsDisplay std = new StatisticsDisplay(wD);
            ForecastDisplay fcd = new ForecastDisplay(wD);

            wD.SetMeasurements(10.0F, 44F, 1012);
            wD.SetMeasurements(12.0F, 63F, 1030);
            wD.SetMeasurements(-4.3F, 64F, 998);
            wD.SetMeasurements(-2.0F, 75F, 1022);
        }
    }
}
