using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapTin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            StreamReader st = new StreamReader("tapTin.txt");
            string f= st.ReadToEnd();
            for(int i = 0; i < f.Length; i++)
            {
                Console.WriteLine(f[i]);
            }

        }
    }
}
