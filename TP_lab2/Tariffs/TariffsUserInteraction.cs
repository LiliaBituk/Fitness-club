namespace TP_lab2
{
    internal class TariffsUserInteraction
    {
        private TariffsInformation info;

        public TariffsUserInteraction(string tariffsFilePath)//, string monthsFilePath)
        {
            info = new TariffsInformation(tariffsFilePath);//, monthsFilePath);
        }

        public void OutputTarifs()
        {
            Console.WriteLine("Добро пожаловать в фитнес клуб!");
            Console.WriteLine("Наши тарифы:");
            foreach (string key in info.tariffs.Keys) { Console.WriteLine($" - {key}"); }
            Console.WriteLine();
        }

        public void OutputMonthsAndPrices(string selectedTariff)
        {
            Console.WriteLine($"Расценки тарифа '{selectedTariff}':");
            for (int j = 0; j < info.months.Count; j++)
            {
                Console.WriteLine($" - {info.months[j]} мес {info.tariffs[selectedTariff][j]} руб");
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
            return info.tariffs[selectedTariff][info.months.FindIndex(month => month == selectedMonth)];
        }

        public string GetSelectedTraifInput()
        {
            string selectedTarif;
            do
            {
                Console.Write("Введите интересующий тариф: ");
                selectedTarif = GetInput();
                Console.WriteLine();

                if (info.tariffs.ContainsKey(selectedTarif))
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

                if (info.months.Contains(selectedMonth))
                {
                    return selectedMonth;
                }
            }
            while (true);
        }
    }
}
