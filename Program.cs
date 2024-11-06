using System.Collections.Generic;

namespace LINQ_04_Durchschnitt_von_Kategorien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Eintrag> list = new List<Eintrag>();
            string[] sammler;

            using (StreamReader sr = new StreamReader(@"C:\Users\Luca\source\repos\LuSc15\LINQ-04-Durchschnitt-von-Kategorien\Produkte.txt"))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    sammler = line.Replace('.', ',').Trim().Split(';');
                    Eintrag e = new Eintrag(sammler[0], Convert.ToDecimal(sammler[1]), sammler[2]);
                    list.Add(e);
                }
                sr.Close();
            }

            Console.WriteLine("Produktliste ausgeben:");
            foreach(Eintrag e in list)
            {
                Console.WriteLine(e.name+" "+e.price+" "+e.kategorie);
            }

            var linqKat = list.Select(g => new
            {
                Name = g.name,
                Kat = g.kategorie,
                Pr = g.price,
            }
            ).GroupBy(x => x.Kat);
            Console.WriteLine();
            Console.WriteLine("Kategorie mit Produkten und Preis:");
            foreach(var v in linqKat)
            {
                Console.WriteLine(v.Key+":");
                foreach(var a in v)
                {
                    Console.WriteLine(a.Name + " - " + a.Pr);
                }
                Console.WriteLine();
            }



            var linqAvg = list.GroupBy(e => e.kategorie).Select(g => new
            {
                Kategorie = g.Key,
                Durchschnittspreis = g.Average(e => e.price)
            });
            Console.WriteLine("Durchschnittpreise:");
            foreach (var e in linqAvg)
            {
                Console.WriteLine($"{e.Kategorie} Ø {e.Durchschnittspreis:F2} EUR");

            }
            Console.ReadLine();
        }
       


        
    }
}
