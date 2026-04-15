using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Keresztrejtveny
{

    internal class Program
    {
        public class KeresztrejtvenyRacs
        {
            public int OszlopolDb { get; set; }
            public int SorokDb { get; set; }

            public KeresztrejtvenyRacs(string line)
            {
                string[] szet = line.Split();
                OszlopolDb = line.Length+2;



            }


            public static List<KeresztrejtvenyRacs> BeolvasAdatsorok(string fileName)
            {
                string[] strings = File.ReadAllLines(fileName, Encoding.UTF8).Skip(1).ToArray();
                List<KeresztrejtvenyRacs> kr = new List<KeresztrejtvenyRacs>();
                foreach (var item in strings)
                {
                    kr.Add(new KeresztrejtvenyRacs(item));
                }
                return kr;
            }

            
        }

        static void Main(string[] args)
        {
            List<KeresztrejtvenyRacs> adatok = KeresztrejtvenyRacs.BeolvasAdatsorok("kr1.txt");

            Console.ReadLine();

        }
    }
}
