namespace TP_lab2
{
    internal class TariffsInformation
    {
        public Dictionary<string, List<int>> tariffs;
        public List<string> months;
        
        public TariffsInformation(string tariffsFilePath)
        {
            TariffsReader reader = new TariffsReader(tariffsFilePath);

            if (reader.TariffsInfo.Count > 0)
            {
                var info = reader.TariffsInfo[0];
                tariffs = info.tariffs;
                months = info.months;
            }
        }
    }
}
