using TP_lab2;

internal class Program
{
    public static void Main(string[] args)
    {
        TariffsUserInteraction tariffUserInteraction = new TariffsUserInteraction(args[0]);
        TariffObject tariffObject = new TariffObject();
        MassageObject massageObject = new MassageObject();

        // Вывод приветствия и тарифов
        tariffUserInteraction.OutputTarifs();

        // Получение выбранного тарифа от пользователя
        string selectedTariff = tariffUserInteraction.GetSelectedTraifInput();
        tariffObject.typeOfTariff = selectedTariff;

        // Вывод месяцев и цен для выбранного тарифа
        tariffUserInteraction.OutputMonthsAndPrices(selectedTariff);

        // Получение выбранной длительности (мес) от пользователя
        string selectedDurationOfTariff = tariffUserInteraction.GetSelectedMonthInput();
        tariffObject.durationOfTariff = selectedDurationOfTariff;

        // Получение цены для выбранного тарифа в зависимости от длительнсти
        string priceOfSelectedDuration = tariffUserInteraction.GetPriceOfSelectedMonth(selectedTariff, selectedDurationOfTariff).ToString();
        tariffObject.priseOfTariff = priceOfSelectedDuration;

        SelectedGroupTrainingObject selectedGroupTrainingObject = new SelectedGroupTrainingObject(args[4]);
        BusinessLogic bl = new BusinessLogic(args[4]);
        ExtraServicesFlow extraServices = new ExtraServicesFlow(selectedGroupTrainingObject, massageObject);

        // Выбор групповых тренировок, если они доступны
        if (bl.GroupTrainingsAreAvaliable(selectedTariff, args[1]))
        {
            extraServices.ChoosingGroupTrainings(args[3], args[4]);
        }

        // Выбор массажей, если они доступны
        if (bl.MassageIsAvaliable(selectedTariff, args[1]))
        {
            extraServices.ChoosingMassage(args[2]);
        }

        // Генерация билета из собранных данных
        Ticket ticket = new Ticket();
        GroupTraining groupTrain = new GroupTraining();
        ticket.TypeTicketToFile(tariffObject,groupTrain, selectedGroupTrainingObject, massageObject);
    }
}