using Newtonsoft.Json;

namespace TP_lab2
{
    internal class MassageReader
    {
        public List<MassageInformation> MassageInformation { get; }

        public MassageReader(string massageFilePath)
        {
            MassageInformation = new List<MassageInformation>();

            if (File.Exists(massageFilePath))
            {
                string json = File.ReadAllText(massageFilePath);
                MassageInformation = JsonConvert.DeserializeObject<List<MassageInformation>>(json);
            }
        }
        //public List<string> LoadMassageTypesFromFile(string massageFilePath)
        //{
        //    List<string> massageArray = new List<string>();
        //    string allLines = File.ReadAllLines(massageFilePath)[0];
        //    foreach (string item in allLines.Split(","))
        //    {
        //        massageArray.Add(item);
        //    }

        //    return massageArray;
        //}
    }
}
