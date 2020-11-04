using System;
using System.Net;
using System.Net.NetworkInformation;
using static System.Console;

namespace WorkingWithNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Insira um endereço web valido: ");
            string url = ReadLine();
            
            if(string.IsNullOrWhiteSpace(url))
                url = "https://world.episerver.com/cms/?q=pagetype";

            var uri = new Uri(url);
            WriteLine($"URL: {url}");
            WriteLine($"Scheme: {uri.Scheme}");
            WriteLine($"Port: {uri.Port}");
            WriteLine($"Host: {uri.Host}");
            WriteLine($"Path: {uri.AbsolutePath}");
            WriteLine($"Query: {uri.Query}");

            // Obtendo o endereço de IP do site
            IPHostEntry entry = Dns.GetHostEntry(uri.Host);
            WriteLine($"{entry.HostName} tem o seguinte endereço de IP: ");
            foreach (IPAddress address in entry.AddressList)
                WriteLine(address);

            // Pingando um servidor para ver se ele está OK
            WriteLine();
            try 
            {
                var ping = new Ping();
                WriteLine("Pingando em um servido. Um momento...");

                PingReply reply = ping.Send(uri.Host);
                WriteLine($"{uri.Host} foi pingando e respondeu {reply.Status}");

                if(reply.Status == IPStatus.Success)
                {
                    WriteLine($"Reply from {reply.Address} took {reply.RoundtripTime:N0}ms");
                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType().ToString()} says {ex.Message}");
            }
        }
    }
}
