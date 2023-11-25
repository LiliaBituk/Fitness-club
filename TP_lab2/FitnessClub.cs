
namespace TP_lab2
{
    internal class FitnessClub
    {
        public Dictionary<string, List<int>> tariffs;
        public List<string> months;

        public Dictionary<string, List<bool>> ExtraServices;

        public List<GroupTraining> groupTrainingList = new List<GroupTraining>();

        public List<Massage> massageList = new List<Massage>(); 

        public FitnessClub(string tariffsFilePath,
                           string extraServicesFilePath,
                           string[] groupTrainingFilePaths,
                           string[] massageFilePaths)
        {
            // read info about tariffs
            TariffsReader readerTariffs = new TariffsReader(tariffsFilePath);

            if (readerTariffs.TariffsInfo.Count > 0)
            {
                var info = readerTariffs.TariffsInfo[0];
                tariffs = info.tariffs;
                months = info.months;
            }

            // read info about extra services
            ExtraServicesReader readerExtraServices = new ExtraServicesReader(extraServicesFilePath);
            if (readerExtraServices.ExtraServicesInfo.Count > 0)
            {
                var info = readerExtraServices.ExtraServicesInfo[0];
                ExtraServices = info.ExtraServices;
            }

            // read info about group trainings
            foreach (string file in groupTrainingFilePaths)
            {
                GroupTrainingReader reader = new GroupTrainingReader();
                GroupTraining groupTrainig = reader.Read(file);
                groupTrainingList.Add(groupTrainig);
            }

            // read info about massages
            foreach (string file in massageFilePaths)
            {
                MassageReader readerMassage = new MassageReader();
                Massage massage = readerMassage.Read(file);
                massageList.Add(massage);
            }
        }

        public bool GroupTrainingsAreAvaliable(string selectedTariff)
        {
            return ExtraServices[selectedTariff][0];
        }

        public bool MassageIsAvaliable(string selectedTariff)
        {
            return ExtraServices[selectedTariff][1];
        }

        public void TypeTicketToFile(TariffSelectedByUser tariff,
                                    GroupTrainingSelectedByUser selectedGroupTrainingObject,
                                    MassageSelectedByUser massage)
        {
            using (StreamWriter sw = new StreamWriter("ticket.txt", false))
            {
                sw.Write($"Тариф: {tariff.typeOfTariff}\n" +
                        $"Абонемент на {tariff.durationOfTariff} мес\n" +
                        $"Стоимость: {tariff.priseOfTariff} руб\n" +
                        $"Тип тренировки: {selectedGroupTrainingObject.subtype}\n" +
                        $"Время тренировки: {selectedGroupTrainingObject.time}\n" +
                        $"Массаж: {massage.Type}\n" +
                        $"Массажист: {massage.Master}\n" +
                        $"Время массажа: {massage.Time}");
            }
        }
    }
}
