using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_lab2
{
    public class GroupTrainingFactory
    {
        public GroupTraining CreateGroupTraining(string type, string subtype, int currentCapacity, int maxCapacity)
        {
            return new GroupTraining { Type = type, Subtype = subtype, CurrentCapacity = currentCapacity, MaxCapacity = maxCapacity };
        }
    }
}
