using System;

namespace WeatherModel
{
    public class Weather
    {
        public DateTime MeasureTime { get; set; }
        public string DeviceLocation { get; set; }
        public string SensorType { get; set; }
        public string Temperature { get; set; }
        public double MeasurementValue { get; set; }
        // public double ThresholdValue { get; set; }
        public string DeviceName { get; set; }
        public string DeviceIp { get; set; }
        public string DevicePort { get; set; }

        public Weather(DateTime measureTime, string location, string compound, double measurementValue, string sensorType, string port, string ip, string deviceName)
        {
            MeasureTime = measureTime;
            DeviceLocation = location;
            Temperature = compound;
            MeasurementValue = measurementValue;
            //     ThresholdValue = thresholdValue;
            SensorType = sensorType;
            DeviceName = deviceName;
            DeviceIp = ip;
            DevicePort = port;
        }

        public override string ToString()
        {
            //return MeasureTime + "\r\n" + Location + " " + SensorType + "\r\n" + Temperature + ": " + MeasurementValue+ "\r\n" + "\r\n";
            return MeasureTime + " " + DeviceLocation + " " + Temperature + " " + MeasurementValue + " " + SensorType + " " + DevicePort + " " + DeviceIp + " " + DeviceName;
        }
    }
}
}
