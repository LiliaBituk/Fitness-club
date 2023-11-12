
namespace TP_lab2
{
    internal class Ticket
    {
        public void TypeTicketToFile(TariffObject tariff, 
                                    GroupTraining groupTraining, 
                                    SelectedGroupTrainingObject selectedGroupTrainingObject,
                                    MassageObject massage)
        {
            using (StreamWriter sw = new StreamWriter("ticket.txt", false))
            {
                sw.Write($"Тариф: {tariff.typeOfTariff}\n" +
                        $"Абонемент на {tariff.durationOfTariff} мес\n" +
                        $"Стоимость: {tariff.priseOfTariff} руб\n" +
                        $"Тип тренировки: {selectedGroupTrainingObject.SubtypeOfSelectedGroupTraining}\n" +
                        $"Время тренировки: {selectedGroupTrainingObject.TimeOfSelectedGroupTraining}\n" +
                        $"Массаж: {massage.typeOfMassage}");
            }

            Console.WriteLine("Спасибо за покупку! Чек отправлен на почту.");
        }
    }
}
