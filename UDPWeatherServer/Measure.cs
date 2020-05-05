using System;
using System.Security.Cryptography;

namespace WeatherModel
{
    public class Measure
    {
        public DateTime MeasureTime { get; set; }
        public string DeviceLocation { get; set; }
        public string SensorType { get; set; }


        public int RandomTemperature { get; set; }





        public double MeasurementValue { get; set; }
        // public double ThresholdValue { get; set; }
        public string DeviceName { get; set; }
        public string DeviceIp { get; set; }
        public string DevicePort { get; set; }

        public Measure(DateTime measureTime, string location,int randomTemperature, double measurementValue, string sensorType, string port, string ip, string deviceName)
        {
            MeasureTime = measureTime;
            DeviceLocation = location;
             RandomTemperature = new Random().Next(10, 30);
            MeasurementValue = measurementValue;
            //     ThresholdValue = thresholdValue;
            SensorType = sensorType;
            DeviceName = deviceName;
            DeviceIp = ip;
            DevicePort = port;
        }
        public Measure()
        {

        }
        //public int RandomTemperature(int min, int max)
        //{
        //    Random random = new Random();
        //    return random.Next(min, max);
        //}
        public override string ToString()
        {
            //return MeasureTime + "\r\n" + Location + " " + SensorType + "\r\n" + Temperature + ": " + MeasurementValue+ "\r\n" + "\r\n";
            return MeasureTime + " " + DeviceLocation + " " + RandomTemperature + " " + MeasurementValue + " " + SensorType + " " + DevicePort + " " + DeviceIp + " " + DeviceName;
        }
    }
}

