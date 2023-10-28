namespace TP_lab2
{
    internal class ExtraServicesInformation
    {
        public Dictionary<string, List<bool>> extraServicesDictionary;

        public ExtraServicesInformation(string extraServicesFilePath)
        {
            ExtraServicesReader reader = new ExtraServicesReader();
            extraServicesDictionary = reader.LoadExtraServicesFromFile(extraServicesFilePath);
        }
    }
}

