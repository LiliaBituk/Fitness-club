﻿using BusinessLogic;

namespace TP_lab2
{
    public class MassageUserInteraction
    {
        public List<Massage> massageList;

        public MassageUserInteraction(List<Massage> massageList)
        {
            this.massageList = massageList;
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
            foreach (var item in massageList) { Console.WriteLine($" - {item.Type}"); }
        }

        public void OutputMastersOfMassage(string selectedTypeOfMassage)
        {
            Massage massage = massageList.FirstOrDefault(massage => massage.Type.Equals(selectedTypeOfMassage));

            Console.WriteLine("У нас есть следующие мастера: ");
            foreach (var item in massage.Master) { Console.WriteLine($" - {item}"); }
        }

        public void OutputTimesOfMassage(string selectedTypeOfMassage)
        {
            Massage massage = massageList.FirstOrDefault(massage => massage.Type.Equals(selectedTypeOfMassage));
            Console.WriteLine("Доступно время: ");
            foreach (var item in massage.Times) { Console.WriteLine($" - {item}"); }
        }

        public string GetSelectedMassageInput()
        {
            string selectedTypeOfMassage;

            do
            {
                Console.Write("Введите интересующий тип массажа: ");
                selectedTypeOfMassage = GetInput();
                Console.WriteLine();
            }
            while (!massageList.Any(massage => massage.Type.Equals(selectedTypeOfMassage)));

            return selectedTypeOfMassage;
        }

        public string GetMasterOfMassage(string selectedTypeOfMassage)
        {
            string selectedMasterOfMassage;
            Massage massage = massageList.FirstOrDefault(massage => massage.Type.Equals(selectedTypeOfMassage));

            do
            {
                Console.Write("Введите мастера: ");
                selectedMasterOfMassage = GetInput();
                Console.WriteLine();
            }
            while (!massage.Master.Contains(selectedMasterOfMassage));

            return selectedMasterOfMassage;
        }

        public string GetTimeOfMassage(string selectedTypeOfMassage)
        {
            string selectedTimeOfMassage;
            Massage massage = massageList.FirstOrDefault(massage => massage.Type.Equals(selectedTypeOfMassage));

            do
            {
                Console.Write("Введите время: ");
                selectedTimeOfMassage = GetInput();
                Console.WriteLine();
            }
            while (!massage.Times.Contains(selectedTimeOfMassage));

            return selectedTimeOfMassage;
        }
    }
}
