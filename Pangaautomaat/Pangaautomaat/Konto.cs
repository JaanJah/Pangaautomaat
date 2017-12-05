using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangaautomaat
{
    static class Konto
    {
        public static string kasutajanimi { get; set; }
        public static int kasutajapin { get; set;}
        public static int mitmeskasutaja { get; set; }

        public static void Registreerimine()
        {
            ProoviUuesti:
            Console.WriteLine("Soovisite registreerida!\nSisestage kasutajanimi (Peab olema 6 tähte): ");
            kasutajanimi = Console.ReadLine();
            if (kasutajanimi.Length != 6)
            {
                Console.WriteLine("Te ei sisestanud 6 tähelist kasutajanime. Proovige uuesti!");
                goto ProoviUuesti;
            }
            Console.WriteLine("Sisestage endale sobiv PIN (4 numbrit): ");
            if (kasutajapin > 9999 && kasutajapin.ToString().Length < 3)
            {
                Console.WriteLine("Te ei sisestanud 4 kohalist PINi. Proovige uuesti!");
                goto ProoviUuesti;
            }
            kasutajapin = int.Parse(Console.ReadLine());

            System.IO.File.AppendAllText("../../kontolist.txt", kasutajanimi + " " + kasutajapin + Environment.NewLine);
            return;
        }

        public static void Logimine()
        {
            mitmeskasutaja = 0;

            Console.WriteLine("Soovisite sisselogida!\nSisestage kasutajanimi: ");
            kasutajanimi = Console.ReadLine();
            Console.WriteLine("Sisestage oma PIN (4 numbrit)");
            kasutajapin = int.Parse(Console.ReadLine());

            using (System.IO.StreamReader sr = new System.IO.StreamReader("../../kontolist.txt"))
            {
                string rida;

                if ((rida = sr.ReadLine()) != null)
                {
                    mitmeskasutaja++;
                    if (rida.Substring(0,6) == kasutajanimi)
                    {
                        if (rida.Substring(7, 4) == kasutajapin.ToString())
                        {

                        }
                    }

                }

            }
        }

    }
}
