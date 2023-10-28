namespace TP_lab2
{
    internal class TariffsInformation
    {
        public Dictionary<string, List<int>> tariffsDictionary;
        public List<string> monthsList;

        public TariffsInformation(string tariffsFilePath, string monthsFilePath) 
        {
            TariffsReader reader = new TariffsReader();
            tariffsDictionary = reader.LoadTariffsFromFile(tariffsFilePath);
            monthsList = reader.LoadMonthsFroamFile(monthsFilePath);
        }
    }
}
