using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MeasurementLibrary;
using Newtonsoft.Json;


namespace WeatherReciever
{
    public class Program
    {
       

    static void Main(string[] args)
        {
            Console.WriteLine("Hello im waiting for data...");
            Console.ReadLine();
            UdpClient udpRecieveData = new UdpClient(11111);

            IPEndPoint MyEndPoint = new IPEndPoint(IPAddress.Any, 0);
            
            Console.WriteLine("Getting ready to print and post data....");


            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpRecieveData.Receive(ref MyEndPoint);
                    string receiveData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("Data:" + " " + receiveData.ToString());

                    //Split received data string into substring, each denoting a specific measurement          
                    String[] subStrings = receiveData.Split(" | ", 10);
                    string dateTimeString = subStrings[1];
                    string location = subStrings[3];
                    string randomTemperatureString = subStrings[5];
                    string rainString = subStrings[7];
                    string windSpeedString = subStrings[9];

                    //Parsing substrings, so that each measurement is parsed into the right type (if not a string)
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    int randomTemperature = Int32.Parse(randomTemperatureString);
                    int rain = Int32.Parse(rainString);
                    int windSpeed = Int32.Parse(windSpeedString);

                    //Creating new object from received data
                    Measurement newMeasurement = new Measurement { DeviceLocation = location, MeasureTime = dateTime, Rain = rain, RandomTemperature = randomTemperature, WindSpeed = windSpeed };

                    //Calling postmethod on the object
                    PostMeasurementHttpTask(newMeasurement);

                    Thread.Sleep(200);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public static async void PostMeasurementHttpTask(Measurement nm)
        {
            //Virker med denne hjemmeside, men ikke den hjemmeside vi selv har lavet i Azure til projektet
           
            string ItemWebApiBase = "https://letitgrowweather.azurewebsites.net/";

            using HttpClient client = new HttpClient();
            {
                string newMeasurementJson = JsonConvert.SerializeObject(nm);
                var content = new StringContent(newMeasurementJson, Encoding.UTF8, ("application/json"));
                client.BaseAddress = new Uri(ItemWebApiBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync("api/weather", content);
                

                Console.WriteLine("*****An item posted to service*****");
                Console.WriteLine("***** Response is" + response + "*****");
                response.EnsureSuccessStatusCode();
                var httpResponseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(httpResponseBody);
            }

        }
    }

}
