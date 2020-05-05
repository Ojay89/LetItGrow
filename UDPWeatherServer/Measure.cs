﻿using System;
using System.ComponentModel;
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

        //Bruges ikke af reciever
        //public string SensorType { get; set; }
        //public double MeasurementValue { get; set; }
        //public string DeviceName { get; set; }
        //public string DeviceIp { get; set; }
        //public string DevicePort { get; set; }

        public Measure(DateTime measureTime, string location, int randomTemperature, int rain, int windSpeed) /*, double measurementValue, string sensorType, string port, string ip, string deviceName)*/
        {
            MeasureTime = measureTime;
            DeviceLocation = location;
            RandomTemperature = new Random().Next(-10, 30);
            Rain = new Random().Next(0, 30);
            WindSpeed = new Random().Next(0, 80);

            //Bruges ikke af reciever
            //MeasurementValue = measurementValue;
            //SensorType = sensorType;
            //DeviceName = deviceName;
            //DeviceIp = ip;
            //DevicePort = port;
        }
        public Measure()
        {

        }
     
        public override string ToString()
        {
            return "Dato og tid:" + " " +  MeasureTime + " | " + "Hvor:" + " " + DeviceLocation + " | " + "Temperatur:" + " " + RandomTemperature + "C" + " | " +
                   "Regn:" + " " + Rain + "mm" + " | " + "Vindhastighed:" + " " + WindSpeed + " m/sek "; /*+ " " + MeasurementValue + " " + SensorType + " " + DevicePort + " " + DeviceIp + " " + DeviceName;*/
        }
    }
}

