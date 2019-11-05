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
            int kolicina = 0;

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
                              "4 - Dodaj kolicinu\n" +
                              "5 - Ukloni artikal\n" +
                              "6 - Izlaz\n" +
                              "Izaberite: ");
                char izbor = Console.ReadKey().KeyChar;
                Console.WriteLine(); //samo da nam se ispis spusti u iduci red
                switch (izbor)
                {
                    case '1':
                        while (true)
                        {
                            Console.Write("Unesite ime: "); //kupimo informacije                                
                            string ime = Console.ReadLine();
                            Console.Write("Unesite sifru: ");
                            string sifra = Console.ReadLine();
                            Console.Write("Unesite cenu: ");
                            int cena = int.Parse(Console.ReadLine());
                            Console.Write("Unesite kolicinu: ");
                            int kol = int.Parse(Console.ReadLine());
                            artikal.Add((ime, sifra, cena, kol)); //dodajem novi element

                            Console.WriteLine("Ako zelite da napustite pritisnite x.");
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
                        break;

                    case '2':
                        {

                            Console.WriteLine("Pregled: \n==========");
                            foreach ((string ime, string sifra, int cena, int kol) broj in artikal)
                            {
                                Console.WriteLine($"Ime: {broj.ime}\nSifra: {broj.sifra}\nCena: {broj.cena}\nKolicina: {broj.kol}  \n-------------------");
                            }
                            break;
                        }
                    case '3':

                        (string rIme, int rCena) racun; //novi tupl za racun
                        racun.rCena = 0;

                        while (true)
                        {
                            Console.Write("Unesite ime ili sifru artikla: ");
                            string unos = Console.ReadLine();

                            Console.Write("Unesite kolicinu: ");
                            kolicina = int.Parse(Console.ReadLine());
                            for (int i = 0; i < artikal.Count; i++)
                            {
                                if (artikal[i].sifra.Contains(unos) || (artikal[i].ime.Contains(unos)))
                                {
                                    Console.Write($"Uneli ste: {artikal[i].ime}, sifra: {artikal[i].sifra}, cena {artikal[i].cena}\n");

                                    if (artikal[i].kol >= kolicina)
                                    {
                                        racun.rCena = racun.rCena + kolicina * artikal[i].cena;
                                        artikal[i] = ((artikal[i].ime, artikal[i].sifra, artikal[i].cena, artikal[i].kol - kolicina));
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Nemamo toliko artikala na stanju, trenutni broj artikala: {artikal[i].kol} ");
                                    }

                                    Console.WriteLine($"Vas racun iznosi: {racun.rCena}");
                                    break;
                                }
                            }


                            Console.WriteLine("Ako zelite da napustite kupovinu pritniste x.");
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
                        Console.WriteLine("Unesite sifru artikla: ");
                        string dSifra = Console.ReadLine();
                        Console.WriteLine("Unesite kolicnu koju zelite da dodate: ");
                        int dKolicina = int.Parse(Console.ReadLine());
                        for (int brojac = 0; brojac < artikal.Count; brojac++)
                        {
                            if (artikal[brojac].sifra.Equals(dSifra))
                            {
                                artikal[brojac] = ((artikal[brojac].ime, artikal[brojac].sifra, artikal[brojac].cena, artikal[brojac].kol + dKolicina));
                            }
                        }
                        
                        break;
                    case '5':

                        Console.WriteLine("Unesite sifru artikla koji zelite da izbrisete: ");
                        string unos2 = Console.ReadLine();

                        for (int brojac = 0; brojac < artikal.Count; brojac++) 
                        { 
                            if(artikal[brojac].sifra.Equals(unos2))
                            {
                                artikal.Remove(artikal[brojac]);
                            }
                        }
                    break;
                    case '6':
                        Console.WriteLine("Dovidjenja!");

                        File.Delete("artikal.txt");
                        foreach ((string ime, string sifra, int cena, int kol) Item in artikal)
                        {
                            File.AppendAllText ("artikal.txt",
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

