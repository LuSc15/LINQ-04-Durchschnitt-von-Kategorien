using System.Collections.Generic;

namespace LINQ_04_Durchschnitt_von_Kategorien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Eintrag> produkte = new List<Eintrag>();
            string[] sammler;

            using (StreamReader sr = new StreamReader(@"Produkte.txt"))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    sammler = line.Replace('.', ',').Trim().Split(';');
                    Eintrag e = new Eintrag(sammler[0], Convert.ToDecimal(sammler[1]), sammler[2]);
                    produkte.Add(e);
                }
                sr.Close();
            }
            #region weitere Ausgaben
            Console.WriteLine("Produktliste ausgeben:");
            foreach(Eintrag e in produkte)
            {
                Farbe(e.kategorie);
                Console.WriteLine($"{e.name,-18} {e.preis+" EUR",10:F2}\t {e.kategorie,1}");
                Console.ResetColor();
            }

            var linqKat = produkte.Select(g => new
            {
                Name = g.name,
                Kat = g.kategorie,
                Pr = g.preis,
            }
            ).GroupBy(x => x.Kat);
            Console.WriteLine();
            Console.WriteLine("Kategorie mit Produkten und Preis:");
            foreach(var v in linqKat)
            {
                Farbe(v.Key);
                Console.WriteLine(v.Key+":");
                Console.ResetColor();
                foreach(var a in v)
                {
                    Console.WriteLine($"{a.Name,-18} - { a.Pr,7:F2} EUR");
                }
                Console.WriteLine();
            }
#endregion


            var linqAvg = produkte.GroupBy(x => x.kategorie).Select(group => new
            {
                Kategorie = group.Key,
                Durchschnittspreis = group.Average(x => x.preis)
            });
            Console.WriteLine("Durchschnittpreise:");
            foreach (var eintrag in linqAvg)
            {

                //Console.WriteLine($"{e.Kategorie,-8} Ø {e.Durchschnittspreis,7:F2} EUR");
                Farbe(eintrag.Kategorie);
                Console.Write($"{eintrag.Kategorie,-8}");
                Console.ResetColor();
                Console.Write($" Ø ");
                Console.Write($"{eintrag.Durchschnittspreis,7:F2} EUR\n");

            }
            Console.ReadLine();
        }
       
        public static void Farbe(string eingabe)
        {
            switch(eingabe)
            {
                case "Software":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "Hardware":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "Mobile":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
        }

        
    }
}
