using Newtonsoft.Json;

namespace TP_lab2
{
    internal class ExtraServicesReader
    {
        public List<ExtraServicesInformation> ExtraServicesInfo { get; }

        public ExtraServicesReader(string extraServicesFilePath)
        {
            ExtraServicesInfo = new List<ExtraServicesInformation>();

            if (File.Exists(extraServicesFilePath))
            {
                string json = File.ReadAllText(extraServicesFilePath);
                ExtraServicesInfo = JsonConvert.DeserializeObject<List<ExtraServicesInformation>>(json);
            }
        }
        //public MassageReader(string massageFilePath)
        //{
        //    MassageInformation = new List<MassageInformation>();

        //    if (File.Exists(massageFilePath))
        //    {
        //        string json = File.ReadAllText(massageFilePath);
        //        MassageInformation = JsonConvert.DeserializeObject<List<MassageInformation>>(json);
        //    }
        //}
        //public Dictionary<string, List<bool>> LoadExtraServicesFromFile(string extraServicesFilePath)
        //{
        //    string[] allLines = File.ReadAllLines(extraServicesFilePath);

        //    bool labels = true;

        //    Dictionary<string, List<bool>> extraServicesDictionary = new Dictionary<string, List<bool>>();

        //    foreach (string i in allLines)
        //    {
        //        if (labels) { labels = false; }
        //        else
        //        {
        //            string[] line = i.Split(",");

        //            if (!extraServicesDictionary.ContainsKey(line[0]))
        //            {
        //                extraServicesDictionary[line[0]] = new List<bool>();
        //            }

        //            for (int j = 1; j < line.Length; j++)
        //            {
        //                extraServicesDictionary[line[0]].Add(Convert.ToBoolean(line[j]));
        //            }
        //        }
        //    }

        //    return extraServicesDictionary;
        //}
    }
}
