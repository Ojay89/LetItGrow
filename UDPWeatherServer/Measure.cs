using System;
using System.ComponentModel;
using System.Net.Http;
using System.Security.Cryptography;


namespace UDPWeatherBroadcaster
{
    public class Measure
    {
        public DateTime MeasureTime { get; set; }
        public string DeviceLocation { get; set; }
        public int RandomTemperature { get; set; }
        public int Rain { get; set; }
        public int WindSpeed { get; set; }
        public  int Id { get; set; }

        //Bruges ikke af reciever
        //public string SensorType { get; set; }
        //public double MeasurementValue { get; set; }
        //public string DeviceName { get; set; }
        //public string DeviceIp { get; set; }
        //public string DevicePort { get; set; }

        public Measure(int id, DateTime measureTime, string location, int randomTemperature, int rain, int windSpeed) /*, double measurementValue, string sensorType, string port, string ip, string deviceName)*/
        {
            MeasureTime = measureTime;
            DeviceLocation = location;
            RandomTemperature = new Random().Next(-5,25);
            Rain = RandomRain();
            WindSpeed = new Random().Next(4, 8);
            Id = 2;

            //Bruges ikke af reciever
            //MeasurementValue = measurementValue;
            //SensorType = sensorType;
            //DeviceName = deviceName;
            //DeviceIp = ip;
            //DevicePort = port;
        }

        public int RandomRain()
        {
            int result;
            result = new Random().Next(0,20);
            if (result < 10)
            { 
                new Random().Next(0,10);
                if (result < 5)
                {
                    new Random().Next(0, 5);
                    if (result < 3)
                    {
                        return 0;
                    }
                }
                else return result;
            }
            return result;
        }


        public Measure()
        {

        }
     
        public override string ToString()
        {
            return $"ID | {Id} | DATE | {MeasureTime} | LOCATION | {DeviceLocation} | TEMPERATURE IN CELCIUS | {RandomTemperature} | RAIN IN MM | {Rain} | WINDSPEED IN M/S | {WindSpeed}";
             
            //return "Dato og tid:" + " " +  MeasureTime + " | " + "Hvor:" + " " + DeviceLocation + " | " + "Temperatur:" + " " + RandomTemperature + "C" + " | " +
            //      "Regn:" + " " + Rain + "mm" + " | " + "Vindhastighed:" + " " + WindSpeed + " m/sek "; /*+ " " + MeasurementValue + " " + SensorType + " " + DevicePort + " " + DeviceIp + " " + DeviceName;*/
        }
    }
}

