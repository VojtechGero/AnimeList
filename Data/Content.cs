using System.Text.Json;

namespace AnimeList.Data
{
    /// <summary>
    /// Class <c>Content</c> represents either manga or anime;
    /// </summary>
    public class Content
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


        /// <summary>
        /// <c>Content</c> constructor required for json deserialization
        /// Do not use
        /// </summary>
        public Content() { }


        /// <summary>
        /// <c>ToAnime</c> mathod returns an Anime object
        /// </summary>
        internal static Content ToAnime(long id, List<string> names, int? episodes, bool notOut,
                       List<string> genres, int? year)
        {
            return new Content(id,names, episodes, notOut, genres, year);
        }

        /// <summary>
        /// <c>Content</c> constructs an Anime object
        /// </summary>
        private Content(long id, List<string> names, int? episodes, bool notOut,
                       List<string> genres, int? year)
        {
            IsAnime = true;
            ID = id;
            name = names.Last();
            if (episodes is not null)
            {
                this.count = (int)episodes;
            }
            this.notOut = notOut;
            this.genres = genres;
            started = year;
            if (names.Count > 1)
            {
                otherName = names.First();
            }
            else otherName = null;
        }

        /// <summary>
        /// <c>ToManga</c> mathod returns an Manga object
        /// </summary>
        internal static Content ToManga(long id, List<string> names, int? count, bool notOut,
                       List<string> genres, List<string> authors, int? year)
        {
            return new Content(id, names, count, notOut, genres, authors, year);
        }

        /// <summary>
        /// <c>Content</c> constructs an Manga object
        /// </summary>
        private Content(long id, List<string> names, int? count, bool notOut,
                       List<string> genres, List<string> authors, int? year)
        {
            IsAnime = false;
            ID = id;
            name = names.Last();
            if (count is not null)
            {
                this.count = (int)count;
            }
            this.notOut = notOut;
            this.genres = genres;
            if (authors.Count > 3)
            {
                List<string> a = new List<string>();
                for (int i = 0; i < 3; i++)
                {
                    a.Add(authors[i]);
                }
                this.authors = a;
            }
            else this.authors = authors;
            started = year;
            if (names.Count > 1)
            {
                otherName = names.First();
            }
            else otherName = null;
        }

        internal string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
