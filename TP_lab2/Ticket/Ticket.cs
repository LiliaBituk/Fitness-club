namespace TP_lab2
{
    internal class Ticket
    {
        public void TypeTicketToFile(string[] data)
        {
            using (StreamWriter sw = new StreamWriter("ticket.txt", false))
            {
                sw.Write($"Тариф: {data[0]}\n" +
                        $"Абонемент на {data[1]} мес\n" +
                        $"Стоимость: {data[2]} руб\n" +
                        $"Тип тренировки: {data[3]}\n" +
                        $"Время тренировки: {data[4]}\n" +
                        $"Массаж: {data[5]}");
            }

            Console.WriteLine("Спасибо за покупку! Чек отправлен на почту.");
        }

        public string[] GetArrayOfDefinedLength(List<string> ListOfUserData, int length)
        {
            string[] data = new string[length];
            for (int i = 0; i < ListOfUserData.Count; i++)
            {
                data[i] = ListOfUserData[i];
            }

            for (int i = ListOfUserData.Count; i < length; i++)
            {
                data[i] = "-";
            }

            return data;
        }
    }
}
