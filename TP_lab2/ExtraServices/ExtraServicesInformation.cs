namespace TP_lab2
{
    internal class ExtraServicesInformation
    {
        public Dictionary<string, List<bool>> ExtraServices { get; set; }


        public ExtraServicesInformation(string extraServicesFilePath)
        {
            ExtraServicesReader reader = new ExtraServicesReader(extraServicesFilePath);

            if (reader.ExtraServicesInfo.Count > 0 )
            {
                var info = reader.ExtraServicesInfo[0];
                ExtraServices = info.ExtraServices;
            }
        }
        //public List<string> typeOfMassage { get; set; }


        //public ExtraServicesInformation(string extraServicesFilePath)
        //{
        //    ExtraServicesReader reader = new ExtraServicesReader(extraServicesFilePath);

        //    ExtraServices = reader.ExtraServicesInfo.

        //    //if (reader.ExtraServicesInfo.coun)
        //    //{
        //    //    var info = reader.ExtraServicesInfo[0];
        //    //    ExtraServices = info
        //    //}
        //}
    }
}

