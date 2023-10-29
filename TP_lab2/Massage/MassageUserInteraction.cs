namespace TP_lab2
{
    internal class MassageUserInteraction
    {
        MassageInformation info;

        public MassageUserInteraction(string massageFilePath)
        {
            info = new MassageInformation(massageFilePath);
        }

        private string GetInput()
        {
            while (true)
            {
                string enteredData = Console.ReadLine();
                if (enteredData != null && enteredData != "") { return enteredData; }
            }
        }

        public bool GetNeedForMassage()
        {
            string massageChoise;
            do
            {
                Console.Write("Желаете записаться на массаж? (да/нет): ");
                massageChoise = GetInput();
                Console.WriteLine();
                if (massageChoise == "да") return true;
                if (massageChoise == "нет") return false;
            }
            while (true);
        }

        public void OutputTypesOfMassage()
        {
            Console.WriteLine("У нас представленны следующие виды массажа:");
            foreach (string item in info.typeOfMassage) { Console.WriteLine($" - {item}"); }
        }

        public string GetSelectedMassageInput()
        {
            string selectedTypeOfMassage;

            do
            {
                Console.Write("Введите интересующий тип массажа: ");
                selectedTypeOfMassage = GetInput();
                Console.WriteLine();
                if (info.typeOfMassage.Contains(selectedTypeOfMassage)) { return selectedTypeOfMassage; }
            }
            while (true);
        }
    }
}
