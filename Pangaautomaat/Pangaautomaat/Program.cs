using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangaautomaat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tere tulemast pangaautomaati, kas soovite sisselogida või regada?");
            string valik1 = Console.ReadLine();
            if (valik1 == "sisselogida")
            {
                Console.WriteLine("Sisestage kasutajanimi: ");
                string kasutajanimi = Console.ReadLine();
                //kui kasutaja ühildub sellega mis ennem salvestatud
                Console.WriteLine("Sisestage oma 4-kohaline PIN: ");
                int kasutajapin = int.Parse(Console.ReadLine());
                //kui kasutajapin ühildub sellega mis ennem salvestatud
                Console.WriteLine("Teie kontol on: " + kontojääk +"eur(i)");
                Console.WriteLine("Kas soovite raha sisestada või väljastada?");
                string valik2 = Console.ReadLine();
                if (valik2 == "sisestada")
                {
                    Console.WriteLine("Kui palju sooviksite panna kontole?");
                    int rahasisse = int.Parse(Console.ReadLine());
                    kontojääk = kontojääk + rahasisse;
                    Console.WriteLine("Raha on edukalt kasutajale pandud, head päeva!");
                    Console.ReadLine();
                }
                else if (valik2 == "väljastada")
                {
                    Väljastada:
                    Console.WriteLine("Kui suure summa sooviksite väljastada?");
                    int rahavälja = int.Parse(Console.ReadLine());
                    if (rahavälja > kontojääk)
                    {
                        Console.WriteLine("Nii suurt summat pole võimalik välja võtta, palun proovige uuesti.");
                        goto Väljastada;
                    }
                    else if (rahavälja < kontojääk)
                    {
                        kontojääk = kontojääk - rahavälja;
                        Console.WriteLine("Raha on edukalt välja võetud, head päeva!");
                        Console.ReadLine();
                    }
                }

            }
            else if (valik1 == "regada")
            {
                Console.WriteLine("");
            }
        }
    }
}
