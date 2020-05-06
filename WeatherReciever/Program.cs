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

            Console.WriteLine("Its Blocked");


            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpRecieveData.Receive(ref MyEndPoint);

                    string receiveData = Encoding.ASCII.GetString(receiveBytes);

                   Console.WriteLine("Data:" + " " + receiveData.ToString());
                    //Parsedvalue and post

                    String[] subStrings = receiveData.Split(" | ", 10);
                    string dateTimeString = subStrings[1];
                    string location = subStrings[3];
                    string randomTemperatureString = subStrings[5];
                    string rainString = subStrings[7];
                    string windSpeedString = subStrings[9];

                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    int randomTemperature = Int32.Parse(randomTemperatureString);
                    int rain = Int32.Parse(rainString);
                    int windSpeed = Int32.Parse(windSpeedString);
                    Measurement newMeasurement = new Measurement { DeviceLocation = location, MeasureTime = dateTime, Rain = rain, RandomTemperature = randomTemperature, WindSpeed = windSpeed };

                    PostMeasurementHttpTask(newMeasurement);

                    Thread.Sleep(200);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public static async Task<string> PostMeasurementHttpTask(Measurement nm)
        {
            string ItemWebApiBase = "https://letitgrow.azurewebsites.net/";

           using (HttpClient client = new HttpClient())
            {
                string newItemJson = JsonConvert.SerializeObject(nm);
                var content = new StringContent(newItemJson, Encoding.UTF8, ("application/json"));
                client.BaseAddress = new Uri(ItemWebApiBase);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync("api/items", content);
                

                Console.WriteLine("*****An item posted to service*****");
                Console.WriteLine("***** Response is" + response + "*****");
                response.EnsureSuccessStatusCode();
                var httpResponseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(httpResponseBody);
            }

            Console.WriteLine("*****Get all items for verification*****");
            string ItemWebApi = "https://letitgrow.azurewebsites.net/";
            return nm.ToString();
        }
    }

}
