namespace LINQ_04_Durchschnitt_von_Kategorien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Eintrag> list = new List<Eintrag>();
            string[] sammler;

            using (StreamReader sr = new StreamReader(@"C:\Users\ITA5-TN13\source\repos\LuSc15\LINQ 04 Durchschnitt von Kategorien\Produkte.txt"))
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
         
            foreach(Eintrag e in list)
            {
                Console.WriteLine(e.name+" "+e.price+" "+e.kategorie);
            }
               
        }
    }
}
