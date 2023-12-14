using Newtonsoft.Json;
using BusinessLogic;

namespace DataAccess
{
    public class ExtraServicesReader
    {
        public List<ExtraService> ExtraServicesInfo { get; }

        public ExtraServicesReader(string extraServicesFilePath)
        {
            ExtraServicesInfo = new List<ExtraService>();

            if (File.Exists(extraServicesFilePath))
            {
                string json = File.ReadAllText(extraServicesFilePath);
                ExtraServicesInfo = JsonConvert.DeserializeObject<List<ExtraService>>(json);
            }
        }

        public void ReadExtraServices(FitnessClub fitnessClub)
        {
            if (ExtraServicesInfo.Count > 0)
            {
                var info = ExtraServicesInfo[0];
                fitnessClub.ExtraServices = info.ExtraServices;
            }
        }
    }
}
