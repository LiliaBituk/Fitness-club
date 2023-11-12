using Newtonsoft.Json;

namespace TP_lab2
{
    internal class TariffsReader
    {
        public List<TariffsInformation> TariffsInfo;

        public TariffsReader(string tariffsFilePath)
        {
            TariffsInfo = new List<TariffsInformation>();

            if (File.Exists(tariffsFilePath))
            {
                string json = File.ReadAllText(tariffsFilePath);
                TariffsInfo = JsonConvert.DeserializeObject<List<TariffsInformation>>(json);
            }
        }
    }
}
