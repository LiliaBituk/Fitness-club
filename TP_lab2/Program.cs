using TP_lab2;

internal class Program
{
    public static void Main(string[] args)
    {
        Tariffs tariffs = new Tariffs();
        tariffs.LoadTariffsFromFile(args[0]);
        tariffs.LoadMonthsFroamFile(args[1]);

        // Список для сбора пользовательской информации
        List<string> dataEnteredByUser = new List<string> { };

        // Вывод приветствие и тарифы
        tariffs.OutputTarifs();

        // Получение выбранного тарифа от пользователя
        string selectedTariff = tariffs.GetSelectedTraifInput();
        dataEnteredByUser.Add(selectedTariff);

        // Вывод месяцев и цен для выбранного тарифа
        tariffs.OutputMonthsAndPrices(selectedTariff);

        // Получение выбранного месяца от пользователя
        string selectedMonth = tariffs.GetSelectedMonthInput();
        dataEnteredByUser.Add(selectedMonth);

        // Получение цены для выбранного тарифа и месяца
        string priceOfSelectedMonth = tariffs.GetPriceOfSelectedMonth(selectedTariff, selectedMonth).ToString();
        dataEnteredByUser.Add(priceOfSelectedMonth);

        ExtraServices extraServices = new ExtraServices();
        extraServices.LoadExtraServicesFromFile(args[2]);

        // Выбор групповых тренировок, если они доступны
        if (extraServices.GroupTrainingsAreAvaliable(selectedTariff))
        {
            dataEnteredByUser = extraServices.ChoosingGroupTrainings(dataEnteredByUser);
        }

        // Выбор массажей, если они доступны
        if (extraServices.MassageIsAvaliable(selectedTariff))
        {
            dataEnteredByUser = extraServices.ChoosingMassage(dataEnteredByUser);
        }

        // Генерация билета из собранных данных
        Ticket ticket = new Ticket();
        string[] data = ticket.GetArrayOfDefinedLength(dataEnteredByUser, 6);
        ticket.TypeTicketToFile(data);
        //}
        //catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}"); }
    }
}