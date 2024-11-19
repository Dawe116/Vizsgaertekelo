using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vizsgaertekelo.Models;

namespace Vizsgaertekelo
{
    internal class Program
    {
        static List<Teszt> tesztek = new List<Teszt>();
        static void Main(string[] args)
        {

            int darabszam = BeolvasTesztek("tesztek.txt");
            if (darabszam > 0)
                Console.WriteLine($"A beolvasás sikeres. {3} db tesztet olvastam be.");
            else
            {
                Console.WriteLine("Sikertelen beolvasás");
            }
            FeltoltFeladatok("teszt1.txt", 1);
            string[] valasz1 = {"a", "b", "c","a","c", "a", "b", "c", "a", "c" };
            if (tesztek[0].Sikeres(valasz1))
                Console.WriteLine("Sikeres Vizsga!");
            else
                Console.WriteLine("Sikertelen Vizsga");

            Console.ReadLine();
        }

        static int BeolvasTesztek(string fileName)
        {
            try
            {
                string[] sorok = File.ReadAllLines(fileName);
                for (int i = 0; i < sorok.Length; i++)
                {
                    tesztek.Add(new Teszt());
                }
                return sorok.Length;
            }
            catch (FileNotFoundException fnfex)
            {
                Console.WriteLine(fnfex.Message);
                return -1;
            }
            catch (FormatException formex)
            {
                Console.WriteLine(formex.Message);
                return -1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        static void FeltoltFeladatok(string fileName, int id)
        {
            int index = 0;
            while(index < tesztek.Count && !(tesztek[index].Id == id))
                index++;
            if (index < tesztek.Count)
            {
                string[] lines = File.ReadAllLines(fileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    tesztek[index].Feladatok[i] = new Feladat
                    {
                        Megoldas = lines[i].Split(';')[0],

                    };
                }
            }
            string[] sorok = File.ReadAllLines(fileName);
        }
    }
}
