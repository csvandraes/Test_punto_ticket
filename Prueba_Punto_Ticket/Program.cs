namespace PuntoTicket // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("********************--Start--********************\n");
                Console.WriteLine("Ingrese especie o sub especie a mostrar");
                ReadTxtFile(Console.ReadLine());
                Console.WriteLine("\n");
                Console.WriteLine("********************--End--********************\n");
            }

        }
        public static void ReadTxtFile(string regularMatch)
        {

            //Read file and save in array
            string[] lines = System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\InputData.txt"));
            //Delete text after "," character
            for (int i = 0; i < lines.Length; i++) lines[i] = lines[i].Substring(0, lines[i].IndexOf(","));
            //Sort lines array, contain tree phylogenetic
            Array.Sort(lines);
            //Declare new list of founds nodes
            List<string> listFounds = new List<string>();
            //Find in sorted lines array match input regularMatch and if is true, add to listFounds
            int indice = Array.IndexOf(lines, regularMatch);
            for (int i = indice; i < lines.Length; i++)
            {
                if (lines[i].StartsWith(regularMatch)) listFounds.Add(lines[i]);
            }
            //Count numbers of point in phrase, for print
            foreach (string phrase in listFounds)
            {
                int numberOfPoint = phrase.Split('.').Length - 1;
                PrintResultSearch(numberOfPoint, phrase);
            }
        }
        public static void PrintResultSearch(int numberOfPoint, string phrase)
        {
            //If root
            if (phrase.Length == 1)
            {
                Console.WriteLine($"Especie,{phrase}");
                return;
            }
            //Nodes and sub-nodes
            string sub = "";
            for (int i = 0; i < numberOfPoint; i++)
            {
                if (i > 0) sub = sub.Insert(0, "\t");
                sub = sub + "Sub-";
            }
            sub = sub + $"Especie {phrase}";
            //print result
            Console.WriteLine(sub);
        }

    }
}
