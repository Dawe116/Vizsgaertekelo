using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Vizsgaertekelo.Interfaces;

namespace Vizsgaertekelo.Models
{
    internal class Teszt : Vizsga, IOsztalyozhato
    {
        public Feladat[] Feladatok { get; set; }
        public double Hatar { get; set; }
        public Teszt() { }
        public Teszt(int id, string megnevezes, int feladatszam, int pontszam = 0 )
        {
            Id = id;
            Megnevezes = megnevezes;
            Pontszam  = pontszam;
            Feladatok = new Feladat[feladatszam];
        }

        public Teszt(string sor)
        {
            string[] bontas = sor.Split(';');
            Id = int.Parse(bontas[0]);
            Megnevezes = bontas[1];
            Pontszam = int.Parse(bontas[2]);
            Feladatok = new Feladat[int.Parse(bontas[3])]; 
        }
        public int Osztalyozat()
        {
            throw new NotImplementedException();
        }

        public bool Sikeres(string[] valaszok)
        {
            Hatar = 60.0;
            int osszpont = 0;
            for (int i = 0; i < valaszok.Length; i++)
            {
                if (valaszok[i] == Feladatok[i].Megoldas)
                {
                    osszpont += Feladatok[i].Pontertek;
                }
            }
            return osszpont >= Pontszam * Hatar / 100;
        }
    }
}
