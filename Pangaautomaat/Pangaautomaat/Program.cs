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
            while (true)
            {
                Start:
                Console.WriteLine("Tere olen pangaautomaat!\nKas soovite: (Valige number)\n1. Logida sisse.\n2. Luua konto.\n");
                int logivõirega = int.Parse(Console.ReadLine());

                if (logivõirega == 1)
                {
                    Konto.Logimine();
                    while (true)
                    {
                        Outer:
                        Console.WriteLine("Kas te soovite (Valige number))\n1. Võtta raha välja.\n2. Sisestada raha.\n");
                        int sissevõivälja = int.Parse(Console.ReadLine());
                        if (sissevõivälja == 1)
                        {
                            Console.WriteLine("Sisestage summa mida soovite väljastada: ");
                            int summa = int.Parse(Console.ReadLine());
                            //võtab kontojäägilt
                            return;
                        }
                        else if (sissevõivälja == 2)
                        {
                            Console.WriteLine("Sisestage summa mida soovite sisestada: ");
                            int summasisse = int.Parse(Console.ReadLine());
                            //lisab kontojäägile
                        }
                        else
                        {
                            Console.WriteLine("Teadmata käsk sisestatud. Proovige uuesti.");
                            goto Outer;
                        }
                    }
                }
                else if (logivõirega == 2)
                {
                    Konto.Registreerimine();
                    goto Start;
                }
                else
                {
                    Console.WriteLine("Sellist valikut ei ole, kas sooviksite uuesti proovida? (Y/N)");
                    string YorN = Console.ReadLine();
                    if (YorN == "Y")
                    {
                        goto Start;
                    }
                    else if (YorN == "N")
                    {
                        return;
                    }
                }
            }
        }
    }
}