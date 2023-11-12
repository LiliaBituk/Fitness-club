using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_lab2
{
    internal class VacantPlacesInGroupTrainingsReader
    {
        public List<VacantPlacesInGroupTrainingsInformation> VacantPlacesData { get; set; }

        public VacantPlacesInGroupTrainingsReader(string vacantPlacesFilePath)
        {
            VacantPlacesReader(vacantPlacesFilePath);
        }

        private void VacantPlacesReader(string vacantPlacesFilePath)
        {
            VacantPlacesData = new List<VacantPlacesInGroupTrainingsInformation>();

            if (File.Exists(vacantPlacesFilePath))
            {
                string json = File.ReadAllText(vacantPlacesFilePath);
               
                // Десериализация в список объектов VacantPlacesInGroupTrainingsInformation
                VacantPlacesData = JsonConvert.DeserializeObject<List<VacantPlacesInGroupTrainingsInformation>>(json);
            }
        }
    }
}
