﻿using Newtonsoft.Json;

namespace TP_lab2
{
    internal class TariffsReader
    {
        public List<Tariff> TariffsInfo { get; private set; }

        public TariffsReader(string tariffsFilePath)
        {
            TariffsInfo = new List<Tariff>();

            if (File.Exists(tariffsFilePath))
            {
                string json = File.ReadAllText(tariffsFilePath);
                TariffsInfo = JsonConvert.DeserializeObject<List<Tariff>>(json);
            }
        }
    }
}
