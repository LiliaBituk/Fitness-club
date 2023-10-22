namespace TP_lab2
{
    public class Reader : IReader
    {
        private string[] GetAllLines(string arg) => File.ReadAllLines($"{arg}.txt");

        public string[] GetArrayFromFile(string arg) => GetAllLines(arg)[0].Split(",");

        public Dictionary<string, string[]> GetDictionaryFromFile(string arg)
        {
            string[] getArrayOfTextAndTarifsPrices = GetAllLines(arg);

            var tarifs = new Dictionary<string, string[]> { };
            bool labels = true;

            foreach (string i in getArrayOfTextAndTarifsPrices)
            {
                if (labels) { labels = false; }
                else
                {
                    string[] line = i.Split(",");
                    List<string> prices = new List<string>();

                    for (int j = 1; j < line.Length; j++)
                    {
                        prices.Add(line[j]);
                    }
                    tarifs[line[0]] = prices.ToArray();
                }
            }

            return tarifs;
        }
    }

}
