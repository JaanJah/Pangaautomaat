using System;
using System.IO;
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
            string[] kasutajaRida = File.ReadAllLines("../../kontolist.txt");

            int kogus = int.Parse(kasutajaRida[mitmeskasutaja].Substring(9));
            return kogus;
        }

        public static bool RahaSisse(int summa, int mitmeskasutaja)
        {
            string[] kasutajarida = File.ReadAllLines("../../kontolist.txt");

            string uuskasutajarida = kasutajarida[mitmeskasutaja - 1].Substring(0, 10);

            int kogus = int.Parse(kasutajarida[mitmeskasutaja - 1].Substring(10));
            kogus += summa;

            kasutajarida[mitmeskasutaja - 1] = uuskasutajarida + " " + kogus.ToString();
            File.WriteAllLines("../../kontolist.txt", kasutajarida);

            return true;
        }

        public static bool RahaVälja(int summa, int mitmeskasutaja)
        {
            string[] kasutajarida = File.ReadAllLines("../../kontolist.txt");

            string uuskasutajarida = kasutajarida[mitmeskasutaja - 1].Substring(0, 10);

            int kogus = int.Parse(kasutajarida[mitmeskasutaja - 1].Substring(10));
            kogus -= summa;

            if (kogus < 0)
            {
                Console.WriteLine("Sellist summat ei ole võimalik väljastada");
                return false;
            }

            kasutajarida[mitmeskasutaja - 1] = uuskasutajarida + " " + kogus.ToString();
            File.WriteAllLines("../../kontolist.txt", kasutajarida);

            return true;
        }
    }
}
