using BusinessLogic;

namespace TP_lab2
{
    /// <summary>
    /// Flow-Класс для user-interaction-методов, используемых для подбора дополнительных сервисов, таких как групповые тренировки и массажи
    /// </summary>
    
    public class ExtraServicesFlow
    {
        GroupTrainingSelectedByUser selectedGroupTrainingObject;
        MassageSelectedByUser massageObject;

        public ExtraServicesFlow(GroupTrainingSelectedByUser selectedGroupTrainingObj, MassageSelectedByUser massageObj)
        {
            selectedGroupTrainingObject = selectedGroupTrainingObj;
            massageObject = massageObj;
        }

        public void ChoosingGroupTrainings(List<GroupTraining> groupTrainingList)
        {
            GroupTrainingsUserInteraction groupTrainingUserInteraction = new GroupTrainingsUserInteraction(groupTrainingList);

            if (groupTrainingUserInteraction.GetNeedForGroupTraining())
            {
                groupTrainingUserInteraction.OutputTypeOfGroupTrainings();

                string selectedGroupTraining = groupTrainingUserInteraction.GetSelectedGroupTrainingInput();

                groupTrainingUserInteraction.OutputTimeOfGroupTrainings(selectedGroupTraining);

                string timeOfSelectedTraining = groupTrainingUserInteraction.GetSelectedTimeInput(selectedGroupTraining);

                groupTrainingUserInteraction.OutputVacantPlaces(selectedGroupTraining);

                string selectedSubtype = groupTrainingUserInteraction.GetSelectedSubtypeInput(selectedGroupTraining);

                selectedGroupTrainingObject.subtype = selectedSubtype;
                selectedGroupTrainingObject.time = timeOfSelectedTraining;
            }
        }

        public void ChoosingMassage(List<Massage> massageList)
        {
            MassageUserInteraction userInteraction = new MassageUserInteraction(massageList);

            if (userInteraction.GetNeedForMassage())
            {
                userInteraction.OutputTypesOfMassage();

                string selectedTypeOfMassage = userInteraction.GetSelectedMassageInput();
                massageObject.Type = selectedTypeOfMassage;

                userInteraction.OutputMastersOfMassage(selectedTypeOfMassage);

                massageObject.Master = userInteraction.GetMasterOfMassage(selectedTypeOfMassage);

                userInteraction.OutputTimesOfMassage(selectedTypeOfMassage);

                massageObject.Time = userInteraction.GetTimeOfMassage(selectedTypeOfMassage);
            }
        }
    }
}
