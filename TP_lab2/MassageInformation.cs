namespace TP_lab2
{
    internal class MassageInformation
    {
        public List<string> massageArray;

        public MassageInformation()
        {
            MassageReader reader = new MassageReader();
            massageArray = reader.LoadMassageTypesFromFile("massage.txt");
        }
    }
}

    

