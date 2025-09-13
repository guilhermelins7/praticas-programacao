using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream infile;
            int tam;
            char x;

            infile = new System.IO.FileStream("arquivo.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read);


            tam = (int)infile.Length;
            char[] arquivos = new char[tam];
            for (int i = 0; i < tam; ++i)
            {
                x = (char)infile.ReadByte();
                //outfile.WriteByte((byte)x);
                arquivos[i] = x;
            }

            enviarArquivo(arquivos);
            infile.Close();
        }

        static void enviarArquivo(char[] arquivo)
        {
            Socket socketenviar = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            IPEndPoint endereco = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9060);

            Console.ReadKey();
            socketenviar.SendTo(Encoding.ASCII.GetBytes(arquivo), endereco);
            socketenviar.Close();
        }
    }
}
