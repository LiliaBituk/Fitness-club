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
    }
}
