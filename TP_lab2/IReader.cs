namespace TP_lab2
{
    internal interface IReader
    {
        string[] GetArrayFromFile(string arg);
        Dictionary<string, string[]> GetDictionaryFromFile(string arg);
    }
}
