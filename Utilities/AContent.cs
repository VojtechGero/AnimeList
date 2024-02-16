using System.Text.Json;

namespace AnimeList
{
    public class AContent
    {
        public bool IsAnime { get; set; }
        public long ID { get; set; }
        public string name { get; set; }
        public string otherName { get; set; }
        public int count { get; set; }
        public bool notOut { get; set; }
        public List<string> genres { get; set; }
        public List<string> authors { get; set; }
        public DateOnly startedAiring { get; set; }


        //required for json
        public AContent() { }

        internal string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
