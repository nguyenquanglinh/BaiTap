using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 9999;

        static ASCIIEncoding encoding = new ASCIIEncoding();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                TcpClient client = new TcpClient();

                // 1. connect
                client.Connect("127.0.0.1", PORT_NUMBER);
                Stream stream = client.GetStream();
                Console.WriteLine("Kết nối tới server");
                while (true)
                {
                    Console.Write("b : ");
                    string str = Console.ReadLine();
                    // 2. send
                    byte[] data = encoding.GetBytes(str);
                    stream.Write(data, 0, data.Length);
                    if (str == "0")
                    {
                        stream.Close();
                        client.Close();
                        Environment.Exit(0);
                    }
                    // 3. receive
                    data = new byte[str.Length];
                    stream.Read(data, 0, str.Length);

                    Console.WriteLine("a : " + encoding.GetString(data));
                    if (encoding.GetString(data)[0] == '0')
                    {
                        stream.Close();
                        client.Close();
                        Environment.Exit(0);
                    }
                }
                // 4. Close

            }

            catch (Exception ex)
            {
                Console.WriteLine("không có sever");
                Console.WriteLine("Error: " + ex);
                Console.ReadKey();
            }


        }
    }
}
