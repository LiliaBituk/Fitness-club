namespace TP_lab2
{
    internal class Tariffs 
    {
        private Dictionary<string, List<int>> tariffsDictionary = new Dictionary<string, List<int>> ();
        private List<string> monthsList = new List<string> ();

        public void LoadTariffsFromFile(string filePath)
        {
            string[] allLines = File.ReadAllLines($"{filePath}.txt");

            bool labels = true;

            foreach (string i in allLines)
            {
                if (labels) { labels = false; }
                else
                {
                    string[] line = i.Split(",");

                    if (!tariffsDictionary.ContainsKey(line[0]))
                    {
                        tariffsDictionary[line[0]] = new List<int>();
                    }

                    for (int j = 1; j < line.Length; j++)
                    {
                        tariffsDictionary[line[0]].Add(Convert.ToInt32(line[j]));
                    }
                }
            }
        }

        public void LoadMonthsFroamFile(string filePath)
        {
            string allLines = File.ReadAllLines($"{filePath}.txt")[0];

            foreach (string item in allLines.Split(","))
            {
                monthsList.Add(item);
            }
        }

        public int GetPriceOfSelectedMonth(string selectedTariff, string selectedMonth)
        {
            return tariffsDictionary[selectedTariff][monthsList.FindIndex(month => month == selectedMonth)];
        }

        public void OutputTarifs()
        {
            Console.WriteLine("Добро пожаловать в фитнес клуб!");
            Console.WriteLine("Наши тарифы:");
            foreach (string key in tariffsDictionary.Keys) { Console.WriteLine($" - {key}"); }
            Console.WriteLine();
        }

        public void OutputMonthsAndPrices(string selectedTariff)
        {
            Console.WriteLine($"Расценки тарифа '{selectedTariff}':");
            for (int j = 0; j < monthsList.Count ; j++)
            {
                Console.WriteLine($" - {monthsList[j]} мес {tariffsDictionary[selectedTariff][j]} руб");
            }
        }

        private string GetInput()
        {
            while (true)
            {
                string enteredData = Console.ReadLine();
                if (enteredData != null && enteredData != "") { return enteredData; }
            }
        }

        public string GetSelectedTraifInput()
        {
            string selectedTarif;
            do
            {
                Console.Write("Введите интересующий тариф: ");
                selectedTarif = GetInput();
                Console.WriteLine();

                if (tariffsDictionary.ContainsKey(selectedTarif))
                {
                    return selectedTarif;
                }
            }
            while (true) ;
        }

        public string GetSelectedMonthInput()
        {
            string selectedMonth;
            do
            {
                Console.Write("Введите кол-во месяцев: ");
                selectedMonth = GetInput();
                Console.WriteLine();

                if (monthsList.Contains(selectedMonth))
                {
                    return selectedMonth;
                }
            }
            while (true);
        }
    }
}
