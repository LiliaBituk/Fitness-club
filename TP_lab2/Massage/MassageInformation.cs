namespace TP_lab2
{
    internal class MassageInformation
    {
        public List<string> typeOfMassage { get; set; }


        public MassageInformation(string massageFilePath)
        {
            MassageReader reader = new MassageReader(massageFilePath);

            if (reader.MassageInformation.Count > 0)
            {
                var massage = reader.MassageInformation[0];
                typeOfMassage = massage.typeOfMassage;
            }
        }
    }
}

    

