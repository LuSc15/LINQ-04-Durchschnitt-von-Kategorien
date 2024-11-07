using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_04_Durchschnitt_von_Kategorien
{
    internal class Eintrag
    {
        public string name {  get; set; }
        public decimal preis { get; set; }
        public string kategorie { get; set; }
        public Eintrag(string name,decimal preis,string kategorie)
        {
            this.name = name;
            this.preis = preis;
            this.kategorie = kategorie;
        }
        
    }
}
