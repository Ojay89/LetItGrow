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
                    //PostMeasurementHttpTask().ToString().Split("|", 4);
                    String[] subStrings = PostMeasurementHttpTask().ToString().Split("|", 5);
                    string dateTime = subStrings[0];
                    string location = subStrings[1];
                    string randomTemperature = subStrings[2];
                    string rain = subStrings[3];
                    string windSpeed = subStrings[4];



                    Thread.Sleep(200);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public static async Task<string> PostMeasurementHttpTask()
        {
            string ItemWebApiBase = "https://letitgrow.azurewebsites.net/";
            Measurement newMeasurement = new Measurement{DeviceLocation = "Baghaven", MeasureTime = DateTime.Now, Rain = 10, RandomTemperature = 12, WindSpeed = 2};

            using (HttpClient client = new HttpClient())
            {
                string newItemJson = JsonConvert.SerializeObject(newMeasurement);
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
            return newMeasurement.ToString();
        }
    }

}
