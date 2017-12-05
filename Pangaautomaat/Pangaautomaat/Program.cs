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
            Start:
            Console.WriteLine("Tere olen pangaautomaat!\nKas soovite: (Valige number)\n1. Logida sisse.\n2. Luua konto.\n");
            int logivõirega = int.Parse(Console.ReadLine());

            if (logivõirega == 1)
            {
                Konto.Logimine();
                return;
            }

            else if (logivõirega == 2)
            {
                Konto.Registreemine();
                return;
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
                else
                {
                    return;
                }
            }
        }
    }
}
