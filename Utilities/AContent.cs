using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AnimeList
{
    public class AContent
    {
        public bool IsAnime { get; set; }
        public long ID { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public bool notOut { get; set; }
        public List<string> genres { get; set; }
        public List<string> authors { get; set; }

        public AContent()
        {

        }
        public AContent(bool isAnime, long iD, string name, int count, bool notOut, List<string> genres, List<string> authors)
        {
            IsAnime = isAnime;
            ID = iD;
            this.name = name;
            this.count = count;
            this.notOut = notOut;
            this.genres = genres;
            this.authors = authors;
        }

        internal string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
