﻿namespace TP_lab2
{
    internal class MassageReader
    {
        public List<string> LoadMassageTypesFromFile(string filePath)
        {
            List<string> massageArray = new List<string>();
            string allLines = File.ReadAllLines(filePath)[0];
            foreach (string item in allLines.Split(","))
            {
                massageArray.Add(item);
            }

            return massageArray;
        }
    }
}