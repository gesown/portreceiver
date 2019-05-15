using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PortReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<byte> localBytes = new List<byte>();
            var ipBytes = args[0].Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ip in ipBytes)
            {
                localBytes.Add(byte.Parse(ip));
            }

            IPAddress localAddr = new IPAddress(localBytes.ToArray());
            int localPort = int.Parse(args[1]);
            TcpListener listener = new TcpListener(localAddr, localPort);
            listener.Start();
            Console.WriteLine("Port "+args[1]+" On IP "+args[0]+" Listening");
            Console.Read();
        }
    }
}
