using TP_lab2;
using BusinessLogic;
using DataAccess;

internal class Program
{
    public static void Main(string[] args)
    {
        string[] groupTrainingFilePaths = new string[] { args[3], args[4], args[5], args[6], args[7] };
        string[] massageFilePaths = new string[] { args[8], args[9], args[10] };

        FitnessClub fitnessClub = new FitnessClub();

        // Read info about tariffs
        TariffsReader readerTariffs = new TariffsReader(args[0]);
        readerTariffs.ReadTariffs(fitnessClub);

        // Read info about extra services
        ExtraServicesReader readerExtraServices = new ExtraServicesReader(args[1]);
        readerExtraServices.ReadExtraServices(fitnessClub);

        // Read info about group trainings
        GroupTrainingReader groupTrainingReader = new GroupTrainingReader();
        groupTrainingReader.ReadGroupTrainings(groupTrainingFilePaths, fitnessClub);

        // Read info about massages
        MassageReader massageReader = new MassageReader();
        massageReader.ReadMassage(massageFilePaths, fitnessClub);

        TariffsUserInteraction tariffUserInteraction = new TariffsUserInteraction(fitnessClub.tariffs, fitnessClub.months);
        TariffSelectedByUser tariffObject = new TariffSelectedByUser();

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

        GroupTrainingSelectedByUser selectedGroupTrainingObject = new GroupTrainingSelectedByUser();
        MassageSelectedByUser massageObject = new MassageSelectedByUser();
        ExtraServicesFlow extraServices = new ExtraServicesFlow(selectedGroupTrainingObject, massageObject);

        // Выбор групповых тренировок, если они доступны
        if (fitnessClub.GroupTrainingsAreAvaliable(selectedTariff))
        {
            extraServices.ChoosingGroupTrainings(fitnessClub.groupTrainingList);
        }

        // Выбор массажей, если они доступны
        if (fitnessClub.MassageIsAvaliable(selectedTariff))
        {
            extraServices.ChoosingMassage(fitnessClub.massageList);
        }

        // Генерация билета из собранных данных
        TicketGenerator ticket = new TicketGenerator();
        ticket.TypeTicketToFile(tariffObject, selectedGroupTrainingObject, massageObject);
        Console.WriteLine("Спасибо за покупку! Чек отправлен на почту.");
    }
}