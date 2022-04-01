namespace PuntoTicket // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitApp = false;

            while (!exitApp)
            {
                try
                {

                    Console.WriteLine("Ingresa 1 para mostrar Especies y sub especies");
                    Console.WriteLine("Ingresa 2 Salir");

                    int option = Convert.ToInt32(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("****************************************\n");
                            Console.WriteLine("Ingrese especie o sub especie a mostrar");
                            string inputMatch = Console.ReadLine();
                            SearchMatchNodes(inputMatch);
                            Console.WriteLine("\n");
                            Console.WriteLine("****************************************\n");
                            break;
                        case 2:
                            exitApp = true;
                            break;
                        default:
                            Console.WriteLine("Opcion no válida");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static void SearchMatchNodes(string inputMatch)
        {
            string[] InputTxtFileArray = ReadInputTxtFile();
            string[] CleanFileArray = CleanInputTxtFile(InputTxtFileArray);
            string[] SortFileArray = SortCleanArray(CleanFileArray);
            List<string> listMatchNodeFound = MatchNodes(SortFileArray, inputMatch);

            foreach (var phraseNode in listMatchNodeFound)
            {
                string phraseNodePrint = FactoryPhrase(GetNumberOfSpaces(phraseNode), phraseNode);
                PrintResult(phraseNodePrint);
            }
        }
        public static string[] ReadInputTxtFile()
        {
            string[] txtFileArray = System.IO.File.ReadAllLines(System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\InputData.txt"));
            return txtFileArray;
        }
        public static string[] CleanInputTxtFile(string[] InputTxtFileArray)
        {
            for (int i = 0; i < InputTxtFileArray.Length; i++) InputTxtFileArray[i] = InputTxtFileArray[i].Substring(0, InputTxtFileArray[i].IndexOf(","));
            return InputTxtFileArray;
        }
        public static string[] SortCleanArray(string[] CleanFileArray)
        {
            Array.Sort(CleanFileArray);
            return CleanFileArray;
        }
        public static List<string> MatchNodes(string[] SortFileArray, string inputMatch)
        {
            List<string> listMatchNodeFound = new List<string>();
            int indice = Array.IndexOf(SortFileArray, inputMatch);
            for (int i = indice; i < SortFileArray.Length; i++) if (SortFileArray[i].StartsWith(inputMatch)) listMatchNodeFound.Add(SortFileArray[i]);
            return listMatchNodeFound;
        }
        public static int GetNumberOfSpaces(string node)
        {
            int numberOfSpaces = 0;
            numberOfSpaces = node.Split('.').Length - 1;
            return numberOfSpaces;
        }
        public static string FactoryPhrase(int drawNumbersOfSpaces, string matchNodeFound)
        {
            string subSeparator = "";
            if (matchNodeFound.Length == 1)
            {
                subSeparator = subSeparator + $"Especie,{matchNodeFound}";
                return subSeparator;

            }
            else
            {
                for (int i = 0; i < drawNumbersOfSpaces; i++)
                {
                    if (i > 0) subSeparator = subSeparator.Insert(0, "\t");
                    subSeparator = subSeparator + "Sub-";
                }
                subSeparator = subSeparator + $"Especie {matchNodeFound}";
                return subSeparator;
            }
        }
        public static void PrintResult(string phraseNode)
        {
            Console.WriteLine(phraseNode);
        }
    }
}
