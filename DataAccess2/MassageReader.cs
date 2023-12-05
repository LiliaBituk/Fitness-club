using Newtonsoft.Json;
using BusinessLogic;

namespace DataAccess
{
    public class MassageReader
    {
        public Massage Read(string massageFilePath)
        {
            if (File.Exists(massageFilePath))
            {
                var json = File.ReadAllText(massageFilePath);
                Massage mJson = JsonConvert.DeserializeObject<Massage>(json);

                return mJson;
            }

            return new Massage();
        }

        public void ReadMassage(string[] massageFilePaths, FitnessClub fitnessClub)
        {
            foreach (string file in massageFilePaths)
            {
                Massage massage = Read(file);
                fitnessClub.massageList.Add(massage);
            }
        }
    }
}
