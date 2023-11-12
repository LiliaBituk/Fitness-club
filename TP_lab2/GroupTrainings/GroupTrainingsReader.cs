using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace TP_lab2
{
    internal class GroupTrainingsReader
    {

        public List<GroupTrainingsInformation> GroupTrainingInfo { get; set; }


        public GroupTrainingsReader(string groupTrainingFilePath)
        {
            GroupTrainingsInfoReader(groupTrainingFilePath);
        }

        private void GroupTrainingsInfoReader(string groupTrainingFilePath)
        {
            GroupTrainingInfo = new List<GroupTrainingsInformation>();

            if (File.Exists(groupTrainingFilePath))
            {
                string json = File.ReadAllText(groupTrainingFilePath, Encoding.UTF8);
                GroupTrainingInfo = JsonConvert.DeserializeObject<List<GroupTrainingsInformation>>(json);
            }
        }
    }
}
