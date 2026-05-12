using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Keresztrejtveny
{
    class Program
    {
        static void Main(string[] args)
        {
            KeresztrejtvenyRacs kr = new KeresztrejtvenyRacs("kr1.txt");

            Console.WriteLine("5. feladat");
            Console.WriteLine($"Sorok száma: {kr.SorokDb}");
            Console.WriteLine($"Oszlopok száma: {kr.OszlopokDb}");

            Console.WriteLine("\n6. feladat");
            kr.Megjelenit();

            Console.WriteLine("\n7. feladat");
            Console.WriteLine($"Leghosszabb függőleges szó: {kr.LeghosszabbFuggolegesSzo()}");

            Console.WriteLine("\n8. feladat");
            kr.VizszintesStatisztika();

            Console.WriteLine("\n9. feladat");
            kr.Szamoz();
            kr.SzamozottMegjelenit();

            Console.ReadKey();
        }
    }

    class KeresztrejtvenyRacs
    {
        public List<string> Adatsorok;
        public char[,] Racs;
        public int[,] Sorszamok;

        public int SorokDb;
        public int OszlopokDb;

        public KeresztrejtvenyRacs(string fajlnev)
        {
            BeolvasAdatsorok(fajlnev);

            SorokDb = Adatsorok.Count;
            OszlopokDb = Adatsorok[0].Length;

            Racs = new char[SorokDb + 2, OszlopokDb + 2];
            Sorszamok = new int[SorokDb + 2, OszlopokDb + 2];

            FeltoltRacs();
        }

        void BeolvasAdatsorok(string fajlnev)
        {
            Adatsorok = File.ReadAllLines(fajlnev).ToList();
        }

        void FeltoltRacs()
        {
            for (int i = 0; i < SorokDb; i++)
            {
                for (int j = 0; j < OszlopokDb; j++)
                {
                    Racs[i + 1, j + 1] = Adatsorok[i][j];
                }
            }
        }

        public void Megjelenit()
        {
            for (int i = 1; i <= SorokDb; i++)
            {
                for (int j = 1; j <= OszlopokDb; j++)
                {
                    if (Racs[i, j] == '#')
                        Console.Write("##");
                    else
                        Console.Write("[]");
                }
                Console.WriteLine();
            }
        }

        public int LeghosszabbFuggolegesSzo()
        {
            int max = 0;

            for (int j = 1; j <= OszlopokDb; j++)
            {
                int hossz = 0;

                for (int i = 1; i <= SorokDb; i++)
                {
                    if (Racs[i, j] == '-')
                    {
                        hossz++;
                        if (hossz > max)
                            max = hossz;
                    }
                    else
                    {
                        hossz = 0;
                    }
                }
            }

            return max;
        }

        public void VizszintesStatisztika()
        {
            Dictionary<int, int> stat = new Dictionary<int, int>();

            for (int i = 1; i <= SorokDb; i++)
            {
                int hossz = 0;

                for (int j = 1; j <= OszlopokDb; j++)
                {
                    if (Racs[i, j] == '-')
                    {
                        hossz++;
                    }
                    else
                    {
                        if (hossz >= 2)
                        {
                            if (!stat.ContainsKey(hossz))
                                stat[hossz] = 0;

                            stat[hossz]++;
                        }
                        hossz = 0;
                    }
                }

                if (hossz >= 2)
                {
                    if (!stat.ContainsKey(hossz))
                        stat[hossz] = 0;

                    stat[hossz]++;
                }
            }

            foreach (var elem in stat.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{elem.Key} betűs: {elem.Value} db");
            }
        }

        public void Szamoz()
        {
            int szam = 1;

            for (int i = 1; i <= SorokDb; i++)
            {
                for (int j = 1; j <= OszlopokDb; j++)
                {
                    if (Racs[i, j] == '-')
                    {
                        bool vizszintes =
                            Racs[i, j - 1] == '#' &&
                            Racs[i, j + 1] == '-';

                        bool fuggoleges =
                            Racs[i - 1, j] == '#' &&
                            Racs[i + 1, j] == '-';

                        if (vizszintes || fuggoleges)
                        {
                            Sorszamok[i, j] = szam;
                            szam++;
                        }
                    }
                }
            }
        }

        public void SzamozottMegjelenit()
        {
            for (int i = 1; i <= SorokDb; i++)
            {
                for (int j = 1; j <= OszlopokDb; j++)
                {
                    if (Racs[i, j] == '#')
                    {
                        Console.Write(" ## ");
                    }
                    else if (Sorszamok[i, j] > 0)
                    {
                        Console.Write($"{Sorszamok[i, j],3} ");
                    }
                    else
                    {
                        Console.Write(" .. ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}