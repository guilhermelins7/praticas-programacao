using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ServidorRecebe
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socketreceber = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            EndPoint endereco = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9060);
            byte[] data = new byte[1024];
            int  qtdbytes;

            socketreceber.Bind(endereco);
           
            qtdbytes = socketreceber.ReceiveFrom(data, ref endereco);
            string recebido = Encoding.ASCII.GetString(data, 0, qtdbytes);
            Console.WriteLine(recebido);

            SalvarArquivo(recebido);
        }

        static void SalvarArquivo(String recebido)
        {
            FileStream outfile = new System.IO.FileStream("arquivo_escrito.txt", System.IO.FileMode.Create, System.IO.FileAccess.Write);
            for (int i = 0; i < recebido.Length; ++i)
            {
                outfile.WriteByte((byte)recebido[i]);
            }
            outfile.Close();
        }
    }
}
