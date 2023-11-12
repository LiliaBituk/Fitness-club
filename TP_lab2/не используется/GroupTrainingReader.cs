using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_lab2
{
    internal class GroupTrainingReader
    {
        public List<GroupTraining> ReadGroupTrainins(string groupTrainingsFilePath)
        {
            string json = File.ReadAllText(groupTrainingsFilePath);
            var data = JsonConvert.DeserializeObject<List<Dictionary<string, Dictionary<string, List<object>>>>>(json);

            var groupTrainings = new List<GroupTraining>();
            var factory = new GroupTrainingFactory();

            if (data != null)
            {
                foreach (var item in data) // словари из json
                {
                    foreach (var group in item) 
                        // "аэробные" "силовые" "низкоинтенсивные" ...
                    {
                        foreach(var type in group.Value)
                        /* для аэробных - "aerobic" "step_aerobic" "kickboxing" ...
                         * для силовых - "body_sculpt" "lower_body" ...
                         * ...
                         */
                        {
                            //foreach (var placesData in type.Value)
                            //{
                                /* для "aerobic" - [ 19, 20 ]
                                 * для "step_aerobic" - [ 25, 25 ]
                                 * ...
                                 */

                                if (type.Value.Count == 2 &&
                                    int.TryParse((string)type.Value[0], out int currentCapacity) &&
                                    int.TryParse((string)type.Value[1], out int maxCapacity))
                                {
                                    groupTrainings.Add(factory.CreateGroupTraining(Convert.ToString(group), Convert.ToString(type), currentCapacity, maxCapacity));
                                }
                            //}
                        }
                    }
                }
            }

            return groupTrainings;
        }
    }
}
