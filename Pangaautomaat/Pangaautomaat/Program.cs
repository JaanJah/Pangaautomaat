using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangaautomaat
{
    class Program : Konto
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tere tulemast pangaautomaati, kas soovite sisselogida või regada?");
            string valik1 = Console.ReadLine();
            Sisselogimine:
            if (valik1 == "sisselogida")
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader("../../kontoinfod.txt"))
                Console.WriteLine("Sisestage kasutajanimi (ainult tähed): ");
                Konto.kasutajanimi = Console.ReadLine();
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
                Konto konto = new Konto();
                Console.WriteLine("Valige endale kasutajanimi (ainult tähed): ");
                konto.kasutajanimi = Console.ReadLine();
                Console.WriteLine("Looge endale 4-kohaline PIN: ");
                konto.kasutajapin = int.Parse(Console.ReadLine());
                Console.WriteLine("Kasutaja on loodud, kas soovite sisselogida? (jah/ei)");
                string valik4 = Console.ReadLine();
                System.IO.File.AppendAllText("../../accounts.txt", konto.kasutajanimi + " " + konto.kasutajapin + Environment.NewLine);
                if (valik4 == "jah")
                {
                    goto Sisselogimine;
                }
                else if (valik4 == "ei")
                {
                    Console.ReadLine();
                }
            }
        }
    }
}
