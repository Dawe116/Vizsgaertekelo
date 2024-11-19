using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaertekelo.Interfaces
{
    internal interface IOsztalyozhato 
    {
        bool Sikeres(string[] valaszok);
        int Osztalyozat();
    }
}
