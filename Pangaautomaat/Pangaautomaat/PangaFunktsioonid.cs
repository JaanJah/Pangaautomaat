﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangaautomaat
{
    static class PangaFunktsioonid
    {
        public static int Raha(int mitmeskasutaja)
        {
            string[] kasutajaRida = System.IO.File.ReadAllLines("../../kontolist.txt");

            int kogus = int.Parse(kasutajaRida[mitmeskasutaja].Substring(10));
            return kogus;
        }

        public static bool RahaSisse(int summa, int mitmeskasutaja)
        {
            string[] kasutajarida = System.IO.File.ReadAllLines("../../kontolist.txt");

            string uuskasutajarida = kasutajarida[mitmeskasutaja].Substring(0, 11);

            int kogus = int.Parse(kasutajarida[mitmeskasutaja].Substring(11));
            kogus += summa;

            kasutajarida[mitmeskasutaja] = uuskasutajarida + " " + kogus.ToString();
            System.IO.File.WriteAllLines("../../kontolist.txt", kasutajarida);

            return true;
        }

        public static bool RahaVälja(int summa, int mitmeskasutaja)
        {
            string[] kasutajarida = System.IO.File.ReadAllLines("../../kontolist.txt");

            string uuskasutajarida = kasutajarida[mitmeskasutaja].Substring(0, 11);

            int kogus = int.Parse(kasutajarida[mitmeskasutaja].Substring(11));
            kogus -= summa;

            if (kogus < 0)
            {
                Console.WriteLine("Sellist summat ei ole võimalik väljastada");
                return false;
            }

            kasutajarida[mitmeskasutaja] = uuskasutajarida + " " + kogus.ToString();
            System.IO.File.WriteAllLines("../../kontolist.txt", kasutajarida);

            return true;
        }
    }
}
