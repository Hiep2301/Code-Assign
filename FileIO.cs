using Newtonsoft.Json;
class FileIO
{
    public void WriteFile<Type>(List<Type> person, string path)
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(person));
    }

    public List<Type> ReadFile<Type>(string path)
    {
        List<Type>? person = JsonConvert.DeserializeObject<List<Type>>(File.ReadAllText(path));

        return person!;
    }
}