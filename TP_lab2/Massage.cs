﻿namespace TP_lab2
{
    internal class Massage
    {
        public List<string> massageArray = new List<string>();

        public void LoadMassageTypesFromFile(string filePath)
        {
            string allLines = File.ReadAllLines($"{filePath}.txt")[0];
            foreach (string item in allLines.Split(","))
            {
                massageArray.Add(item);
            }
        }

        private string GetInput()
        {
            while (true)
            {
                string enteredData = Console.ReadLine();
                if (enteredData != null && enteredData != "") { return enteredData; }
            }
        }

        public string GetSelectedMassageInput()
        {
            string selectedTypeOfMassage;

            do
            {
                Console.Write("Введите интересующий тип массажа: ");
                selectedTypeOfMassage = GetInput();
                Console.WriteLine();
                if (massageArray.Contains(selectedTypeOfMassage)) { return selectedTypeOfMassage; }
            }
            while (true);
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
            foreach (string item in massageArray) { Console.WriteLine($" - {item}"); }
        }
    }
}