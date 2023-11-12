namespace TP_lab2
{
    internal class VacantPlacesGroupTrainingUserInteraction
    {
        private VacantPlacesInGroupTrainingsInformation vacantPlacesInGroupTrainingsInfo = new VacantPlacesInGroupTrainingsInformation();
        private VacantPlacesInGroupTrainingsReader vacantPlacesInGroupTrainingsReader;
        private BusinessLogic bl;

        public VacantPlacesGroupTrainingUserInteraction(string filePath)
        {
            vacantPlacesInGroupTrainingsReader = new VacantPlacesInGroupTrainingsReader(filePath);
            vacantPlacesInGroupTrainingsInfo = vacantPlacesInGroupTrainingsReader.VacantPlacesData.FirstOrDefault();
            bl = new BusinessLogic(filePath);
        }

        private string GetInput()
        {
            while (true)
            {
                string enteredData = Console.ReadLine();
                if (enteredData != null && enteredData != "") { return enteredData; }
            }
        }

        public void OutputVacantPlacesOfSelectedTraining(string selectedGroupTraining)
        {
            switch (selectedGroupTraining)
            {
                case "аэробные":
                    OutputAEROBICtrainings(selectedGroupTraining);                    
                    break;
                case "низкоинтенсивные":
                    OutputLOWINTENSITYtrainings(selectedGroupTraining);
                    break;
                case "силовые":
                    OutputSTRENGTHtrainings(selectedGroupTraining);
                    break;
                case "смешанные":
                    OutputMIXEDtrainings(selectedGroupTraining);
                    break;
                case "танцевальные":
                    OutputDANCEtrainings(selectedGroupTraining);
                    break;
            }
        }

        public string GetSelectedSubtypeInput()
        {
            string selectedSubtype;
            do
            {
                Console.Write("Введите интересующий тип тренировки: ");
                selectedSubtype = GetInput();
                Console.WriteLine();

                if (bl.CheckAerobicIsAvailable(selectedSubtype))
                {
                    return selectedSubtype;
                }
                else if (bl.CheckDanceIsAvailable(selectedSubtype))
                {
                    return selectedSubtype;
                }
                else if (bl.CheckStrengthIsAvailable(selectedSubtype))
                {
                    return selectedSubtype;
                }
                else if (bl.CheckLowIntensityIsAvailable(selectedSubtype))
                {
                    return selectedSubtype;
                }
                else if (bl.CheckMixedIsAvailable(selectedSubtype))
                {
                    return selectedSubtype;
                }
                else
                {
                    Console.WriteLine("Выбранный тип тренировки недоступен. Пожалуйста, выберите другой тип.");
                    Console.WriteLine();
                }
            }
            while (true);
        }

        public void OutputAEROBICtrainings(string selectedGroupTraining)
        {
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            foreach (var entry in vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Aerobics)
            {
                string trainingName = entry.Key;
                int[] vacantCurrentMax = entry.Value;
                Console.WriteLine($" - {trainingName} {vacantCurrentMax[0]}/{vacantCurrentMax[1]}");
            }
        }



        public void OutputLOWINTENSITYtrainings(string selectedGroupTraining)
        {
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            foreach (var entry in vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.LowIntensity)
            {
                string trainingName = entry.Key;
                int[] vacantCurrentMax = entry.Value;
                Console.WriteLine($" - {trainingName} {vacantCurrentMax[0]}/{vacantCurrentMax[1]}");
            }
        }

        public void OutputDANCEtrainings(string selectedGroupTraining)
        {
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            foreach (var entry in vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Dance)
            {
                string trainingName = entry.Key;
                int[] vacantCurrentMax = entry.Value;
                Console.WriteLine($" - {trainingName} {vacantCurrentMax[0]}/{vacantCurrentMax[1]}");
            }
        }

        public void OutputMIXEDtrainings(string selectedGroupTraining)
        {
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            foreach (var entry in vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Mixed)
            {
                string trainingName = entry.Key;
                int[] vacantCurrentMax = entry.Value;
                Console.WriteLine($" - {trainingName} {vacantCurrentMax[0]}/{vacantCurrentMax[1]}");
            }
        }

        public void OutputSTRENGTHtrainings(string selectedGroupTraining)
        {
            Console.WriteLine($"Подвиды категории '{selectedGroupTraining}' (свободно/всего мест):");

            foreach (var entry in vacantPlacesInGroupTrainingsInfo.VacantPlacesInGroupTrainings.Strength)
            {
                string trainingName = entry.Key;
                int[] vacantCurrentMax = entry.Value;
                Console.WriteLine($" - {trainingName} {vacantCurrentMax[0]}/{vacantCurrentMax[1]}");
            }
        }
    }
}
