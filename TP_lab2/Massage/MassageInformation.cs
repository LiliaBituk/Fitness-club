namespace TP_lab2
{
    internal class MassageInformation
    {
        public List<Massage> massageList = new List<Massage>();

        public MassageInformation(string[] massageFilePaths)
        {
            foreach (string file in massageFilePaths)
            {
                MassageReader reader = new MassageReader();
                Massage massage = reader.Read(file);
                massageList.Add(massage);
            }
        }
        //public List<string> typeOfMassage { get; set; }


        //public MassageInformation(string massageFilePath)
        //{
        //    MassageReader reader = new MassageReader(massageFilePath);

        //    if (reader.MassageInformation.Count > 0)
        //    {
        //        var massage = reader.MassageInformation[0];
        //        typeOfMassage = massage.typeOfMassage;
        //    }
        //}
    }
}

    

