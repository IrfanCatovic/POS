using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Market
{
    class Program
    {
        static void Main(string[] args)
        {   List<(string ime, string sifra, int cena, int kol)> artikal = new List<(string ime, string sifra , int cena, int kol)>();

            if (File.Exists("artikal.txt"))
            {
                foreach (string red in File.ReadLines("artikal.txt"))
                {
                    string[] razdvojeno = red.Split(';');
                    artikal.Add((razdvojeno[0], razdvojeno[1], int.Parse(razdvojeno[2]), int.Parse(razdvojeno[3])));
                }
            }
            while (true)
            {
                Console.WriteLine();
                Console.Write("Meni\n" + 
                              "=======\n" +
                              "1 - Unos\n" +
                              "2 - Pregled\n" +              //MENI
                              "3 - Racun\n" +
                              "4 - Ukloni artikal\n" +
                              "5 - Izlaz\n" +
                              "Izaberite: ");
                char izbor = Console.ReadKey().KeyChar;
                Console.WriteLine(); //samo da nam se ispis spusti u iduci red
                switch (izbor)
                {
                    case '1':
                        { while (true)
                            {  Console.Write("Unesite ime: "); //kupimo informacije
                                string ime = Console.ReadLine();
                                Console.Write("Unesite sifru: ");
                                string sifra = Console.ReadLine();
                                Console.Write("Unesite cenu: ");
                                int cena = int.Parse(Console.ReadLine());
                                Console.Write("Unesite kolicinu: ");
                                int kol = int.Parse(Console.ReadLine());
                                artikal.Add((ime, sifra, cena, kol)); //dodajem novi element
                                
                                Console.WriteLine("Ako zelite da napustite pritisnite x");
                                char izlazUnos = Console.ReadKey().KeyChar;
                                if (izlazUnos == 'x')
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine();
                                }
                        }
                }
                        break;
                        
                    case '2':
                        {
                            Console.WriteLine("Pregled: \n==========");
                            foreach ((string ime, string sifra, int cena, int kol) broj in artikal)
                            {
                                Console.WriteLine($"Ime: {broj.ime}\nSifra: {broj.sifra}\nCena: {broj.cena}\nKolicina: {broj.cena}  \n-------------------");
                            }
                            break;
                        }
                    case '3':
                        

                            (string rIme, int rCena, int kolicina) racun; //novi tupl za racun
                            racun.rCena = 0;

                        while (true)
                        {
                            Console.Write("Unesite ime ili sifru artikla: ");
                            string unos = Console.ReadLine();

                            Console.Write("Unesite kolicinu: ");
                            racun.kolicina = int.Parse(Console.ReadLine());
                            for (int i = 0; i < artikal.Count; i++)
                            {
                                if (artikal[i].sifra.Contains(unos) || (artikal[i].ime.Contains(unos)))
                                {
                                    Console.Write($"Uneli ste: {artikal[i].ime}, sifra: {artikal[i].sifra}, cena {artikal[i].cena}\n");
                                    racun.rCena = racun.rCena + racun.kolicina * artikal[i].cena;

                                    artikal[i].kol = artikal[i].kol - racun.kolicina; //KAKO MOGU DA NAPISEM OVU LINIJU DA MI JE FUNKCIONALNA???


                                    Console.WriteLine($"Vas racun iznosi: {racun.rCena}");
                                    break;
                                } else
                                {
                                    Console.WriteLine("Uneli ste nepostojecu sifru ili ime");
                                }
                            }

                            File.Delete("artikal.txt");
                            Console.WriteLine("Ako zelite da napustite kupovinu pritniste x");
                            char izlazRacun = Console.ReadKey().KeyChar;
                            if (izlazRacun == 'x')
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                        }
                            break;
                    case '4':
                        

                        break;
                    case '5':
                        Console.WriteLine("Dovidjenja!");

                        File.Delete("artikal.txt");
                        foreach ((string ime, string sifra, int cena, int kol) Item in artikal)
                        {
                            File.AppendAllText("artikal.txt",
                                Item.ime + ";" + Item.sifra + ";" + Item.cena + ";" + Item.kol + Environment.NewLine);
                        }
                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("Greska!");
                        break;
                        
                }

            }
        }
    }
}

