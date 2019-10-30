using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market
{
    class Program
    {
        static void Main(string[] args)
        {   List<(string ime, string sifra, int cena)> artikal = new List<(string ime, string sifra , int cena)>();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Meni\n" + // \n znaci novi red
                              "=======\n" +
                              "1 - Unos\n" +
                              "2 - Pregled\n" +
                              "3 - Racun\n" +
                              "Izaberite: ");
                char izbor = Console.ReadKey().KeyChar;
                Console.WriteLine(); //samo da nam se ispis spusti u iduci red
                switch (izbor)
                {
                    case '1':
                        {
                            Console.Write("Unesite ime: "); //kupimo informacije
                            string ime = Console.ReadLine();
                            Console.Write("Unesite sifru: ");
                            string sifra = Console.ReadLine();
                            Console.Write("Unesite cenu: ");
                            int cena = int.Parse(Console.ReadLine()); 
                            artikal.Add((ime, sifra, cena)); //dodajem novi element
                            break;
                        }

                    case '2':
                        {
                            Console.WriteLine("Pregled: \n==========");
                            foreach ((string ime, string sifra, int cena) broj in artikal) 
                            {
                                Console.WriteLine($"Ime: {broj.ime}\nSifra: {broj.sifra}\nCena: {broj.cena} \n-------------------");
                            }
                            break;
                        }
                    case '3':
                        Console.Write("Unesite ime ili sifru artikla: ");
                        string unos = Console.ReadLine(); //ucitavam uns
                        (string rIme, int rCena, int kolicina) racun; //novi tupl za racun
                        if (int.TryParse(unos, out int indeks))
                        {

                            Console.WriteLine("Unesite kolicinu: ");
                            racun.kolicina = int.Parse(Console.ReadLine()); //za kolicinu unos
                            racun.rCena = racun.kolicina * ((int)artikal.cena);
                        }

                        else
                        {
                            Console.WriteLine("Nepostojeca sifra!");
                        }
                        Console.WriteLine("Dovidjenja!");
                        Console.ReadKey();
                        return; //izlaz iz programa
                    default: //slucaj ako ni jedan drugi slucaj nije ispunjen
                        Console.WriteLine("Greska!");

                        break;
                }
            }
        }
    }
}
