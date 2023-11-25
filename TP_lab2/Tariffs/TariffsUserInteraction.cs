namespace TP_lab2
{
    internal class TariffsUserInteraction
    {
        public Dictionary<string, List<int>> tariffs;
        public List<string> months;

        public TariffsUserInteraction(Dictionary<string, List<int>> tariffs, List<string> months)
        {
            this.tariffs = tariffs;
            this.months = months;
        }

        public void OutputTarifs()
        {
            Console.WriteLine("Добро пожаловать в фитнес клуб!");
            Console.WriteLine("Наши тарифы:");
            foreach (string key in tariffs.Keys) { Console.WriteLine($" - {key}"); }
            Console.WriteLine();
        }

        public void OutputMonthsAndPrices(string selectedTariff)
        {
            Console.WriteLine($"Расценки тарифа '{selectedTariff}':");
            for (int j = 0; j < months.Count; j++)
            {
                Console.WriteLine($" - {months[j]} мес {tariffs[selectedTariff][j]} руб");
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

        public int GetPriceOfSelectedMonth(string selectedTariff, string selectedMonth)
        {
            return tariffs[selectedTariff][months.FindIndex(month => month == selectedMonth)];
        }

        public string GetSelectedTraifInput()
        {
            string selectedTarif;
            do
            {
                Console.Write("Введите интересующий тариф: ");
                selectedTarif = GetInput();
                Console.WriteLine();

                if (tariffs.ContainsKey(selectedTarif))
                {
                    return selectedTarif;
                }
            }
            while (true);
        }

        public string GetSelectedMonthInput()
        {
            string selectedMonth;
            do
            {
                Console.Write("Введите кол-во месяцев: ");
                selectedMonth = GetInput();
                Console.WriteLine();

                if (months.Contains(selectedMonth))
                {
                    return selectedMonth;
                }
            }
            while (true);
        }
    }
}
