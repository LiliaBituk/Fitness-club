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
        //public Dictionary<string, List<int>> LoadTariffsFromFile(string filePath)
        //{
        //    string[] allLines = File.ReadAllLines(filePath);

        //    bool labels = true;

        //    Dictionary<string, List<int>> tariffsDictionary = new Dictionary<string, List<int>>();

        //    foreach (string i in allLines)
        //    {
        //        if (labels) { labels = false; }
        //        else
        //        {
        //            string[] line = i.Split(",");

        //            if (!tariffsDictionary.ContainsKey(line[0]))
        //            {
        //                tariffsDictionary[line[0]] = new List<int>();
        //            }

        //            for (int j = 1; j < line.Length; j++)
        //            {
        //                tariffsDictionary[line[0]].Add(Convert.ToInt32(line[j]));
        //            }
        //        }
        //    }

        //    return tariffsDictionary;
        //}

        //public List<string> LoadMonthsFroamFile(string filePath)
        //{
        //    string allLines = File.ReadAllLines(filePath)[0];
        //    List<string> monthsList = new List<string>();
        //    foreach (string item in allLines.Split(","))
        //    {
        //        monthsList.Add(item);
        //    }

        //    return monthsList;
        //}
    }
}
