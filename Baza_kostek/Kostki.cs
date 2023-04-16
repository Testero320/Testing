using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baza_kostek
{
    class Kostki
    {
        string nazwa;
        List<float> czasy_ulozen = new List<float>();
        string dataDodania;


        public string Nazwa
        {
            get;
        }

        public Kostki(string nazwa, string dataDodania)
        {
            this.nazwa = nazwa;
            this.dataDodania = dataDodania;
        }

        public Kostki(string nazwa, float czas, string dataDodania)
        {
            this.nazwa = nazwa;
            this.czasy_ulozen.Add(czas);
            this.dataDodania = dataDodania;
        }

        public Kostki(string nazwa, List<float> czasy_ulozen, string dataDodania) 
        {
            this.nazwa = nazwa;
            this.czasy_ulozen = czasy_ulozen;
            this.dataDodania = dataDodania;
        }


        public override string ToString()
        {
            return $"Kostka {nazwa}, ułożona {czasy_ulozen.Count}, z najlepszym czasem" +
                $"{czasy_ulozen.Min()}, dodana {dataDodania}";
        }
    }
}
