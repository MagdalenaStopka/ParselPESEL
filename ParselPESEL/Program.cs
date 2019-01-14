using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserPESEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            string PESEL = "";
            Program p = new Program();
            Console.WriteLine("Wprowadź PESEL:");
            PESEL = Console.ReadLine();

            p.SprawdzDlugosc(PESEL);
            p.SprawdzZnaki(PESEL);
            p.SprawdzCyfreKontrolna(PESEL);
            Console.ReadKey();
        }

        public bool SprawdzDlugosc(string PESEL)
        {
            int dlugosc = PESEL.Length;
            Console.WriteLine("Wprowadzony PESEL ma: " + dlugosc + " znaków");
            if (dlugosc != 11)
            {
                Console.WriteLine("Podano nieprawidłową liczbę znaków");

                return false;

            }
            else
                Console.WriteLine("Wprowadzono poprawną ilość znaków");
            return true;
        }
        public long SprawdzZnaki(string PESEL)
        {
            try
            {
                long cyfry = long.Parse(PESEL);
                return cyfry;
            }
            catch (FormatException)
            {
                throw new FormatException("PESEL składa się tylko z cyfr - nie można wprowadzić innych znaków");
            }
        }
        public string DataUrodzenia(string PESEL)
        {
            char pierwsza = PESEL[0];
            char druga = PESEL[1];
            char trzecia = PESEL[2];
            char czwarta = PESEL[3];
            char piata = PESEL[4];
            char szosta = PESEL[5];
            char siodma = PESEL[6];
            char osma = PESEL[7];
            char dziewiata = PESEL[8];
            char dziesiata = PESEL[9];
            char jedenasta = PESEL[10];
            string dataUrodzenia = piata.ToString() + szosta.ToString() + "-" + trzecia.ToString() + czwarta.ToString() + "-" + pierwsza.ToString() + druga.ToString();
            Console.WriteLine("Data urodzenia to: " + dataUrodzenia);
            return dataUrodzenia;

        }
        public bool SprawdzCyfreKontrolna(string PESEL)
        {
            char pierwsza = PESEL[0];
            char druga = PESEL[1];
            char trzecia = PESEL[2];
            char czwarta = PESEL[3];
            char piata = PESEL[4];
            char szosta = PESEL[5];
            char siodma = PESEL[6];
            char osma = PESEL[7];
            char dziewiata = PESEL[8];
            char dziesiata = PESEL[9];
            char jedenasta = PESEL[10];
            int pierwsza1 = int.Parse(pierwsza.ToString());
            int druga1 = int.Parse(druga.ToString());
            int trzecia1 = int.Parse(trzecia.ToString());
            int czwarta1 = int.Parse(czwarta.ToString());
            int piata1 = int.Parse(piata.ToString());
            int szosta1 = int.Parse(szosta.ToString());
            int siodma1 = int.Parse(siodma.ToString());
            int osma1 = int.Parse(osma.ToString());
            int dziewiata1 = int.Parse(dziewiata.ToString());
            int dziesiata1 = int.Parse(dziesiata.ToString());
            int jedenasta1 = int.Parse(jedenasta.ToString());
            //9×a + 7×b + 3×c + 1×d + 9×e + 7×f + 3×g + 1×h + 9×i + 7×j
            //1×a + 3×b + 7×c + 9×d + 1×e + 3×f + 7×g + 9×h + 1×i + 3×j + 1×k - wersja bez dzielenia

            int kontrola = 9 * pierwsza1 + 7 * druga1 + 3 * trzecia1 + 1 * czwarta1 + 9 * piata1 + 7 * szosta1 + 3 * siodma1 + 1 * osma1 + 9 * dziewiata1 + 7 * dziesiata1;
            // Console.WriteLine(kontrola);
            int cyfraKontrolna = kontrola % 10;

            if (cyfraKontrolna != jedenasta1)
            {
                Console.WriteLine("Podany PESEL jest błędny");
                return false;
            }
            else
            {
                Console.WriteLine("Podany PESEL jest prawidłowy");
                DataUrodzenia(PESEL);
                return true;
            }
        }

    }
}