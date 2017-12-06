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

        public static bool Registreerimine()
        {
            ProoviUuesti:
            Console.WriteLine("Soovisite registreerida!\nSisestage kasutajanimi (Peab olema 5 tähte): ");
            kasutajanimi = Console.ReadLine();
            if (kasutajanimi.Length != 5)
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
            return true;
        }

        public static bool Logimine()
        {
            mitmeskasutaja = 0;

            Console.WriteLine("Soovisite sisselogida!\nSisestage kasutajanimi: ");
            kasutajanimi = Console.ReadLine();
            Console.WriteLine("Sisestage oma PIN (4 numbrit)");
            kasutajapin = int.Parse(Console.ReadLine());

            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("../../kontolist.txt"))
                {
                    string rida;

                    while ((rida = sr.ReadLine()) != null)
                    {
                        mitmeskasutaja++;
                        if (rida.Substring(0, 5) == kasutajanimi)
                        {
                            if (rida.Substring(6, 4) == kasutajapin.ToString())
                            {
                                Console.WriteLine("Sisse logitud");
                                return true;
                            }
                            else if (rida.Substring(6, 4) != kasutajapin.ToString())
                            {
                                Console.WriteLine("Vale parool.");
                                return false;
                            }
                        }

                    }
                        Console.WriteLine("Kontot ei eksisteeri andmebaasis. ");
                        return false;
                    }
                }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                return false;

            }
        }
    }
}
