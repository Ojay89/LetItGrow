using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


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

                    Console.WriteLine("Sender" + receiveData.ToString());

                    Console.WriteLine("Denne besked blev sendt fra" +
                        MyEndPoint.Address.ToString() +
                        " on their port number " +
                        MyEndPoint.Port.ToString());

                    Thread.Sleep(200);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
