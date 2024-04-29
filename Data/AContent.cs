using System.Text.Json;

namespace AnimeList.Data;

public abstract class AContent
{
    public bool IsAnime { get; set; }
    public long ID { get; set; }
    public string name { get; set; }
    public string otherName { get; set; }
    public int count { get; set; }
    public bool notOut { get; set; }
    public List<string> genres { get; set; }
    public List<string> authors { get; set; }
    public int? started { get; set; }
    public bool inProgress { get; set; }
    public float? Score { get; set; }


    internal string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    internal abstract string Description();
}
