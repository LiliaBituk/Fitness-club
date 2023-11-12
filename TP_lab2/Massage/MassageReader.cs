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
    }
}
