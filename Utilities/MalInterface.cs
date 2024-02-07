using JikanDotNet.Exceptions;
using JikanDotNet.Config;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList
{
    internal class MalInterface
    {
        IJikan jikan;
        internal MalInterface()
        {
            JikanClientConfiguration config = new JikanClientConfiguration()
            {
                LimiterConfigurations = TaskLimiterConfiguration.None
            };
            jikan = new Jikan(config);
        }

        private string getTitle(ICollection<TitleEntry> entries)
        {
            if(entries.Count > 1)
            {
                string def = "";
                foreach(TitleEntry entry in entries)
                {
                    if(entry.Type=="English") return entry.Title;
                    if (entry.Type == "Default") def = entry.Title;
                }
                return def;
            }else return entries.First().Title;
        }

        private List<string> getGerners(ICollection<MalUrl> toParse)
        {
            var gerners = new List<string>();
            if(toParse.Count == 0)
            {
                foreach (var g in toParse)
                {
                    gerners.Add(g.Name);
                }
            }
            return gerners;
        }

        private Anime toAnime (JikanDotNet.Anime input)
        {
            var genres = getGerners(input.Genres);
            Anime anime = new Anime(
                    id: (long)input.MalId,
                    name: getTitle(input.Titles),
                    episodes: input.Episodes,
                    airing: input.Airing,
                    genres: genres);
            return anime;
        }

        internal async Task<Anime> pullAnimeId(long id)
        {
            try
            {
                var res = await jikan.GetAnimeAsync(id);
                return toAnime(res.Data);
            }
            catch (JikanRequestException)
            {
                return null;
            }
            catch (JikanValidationException)
            {
                return null;
            }
        }

        internal async Task<List<Anime>> searchAnime(string query)
        {
            try
            {
                var animes = await jikan.SearchAnimeAsync(query);
                List<Anime> animeList = new List<Anime>();
                int i = 0;
                foreach (var item in animes.Data)
                {
                    if (i > 4) break;
                    i++;
                    Anime a = toAnime(item);
                    animeList.Add(a);
                }
                animeList= StringOps.sortSearch(animeList,query);
                return animeList;
            }
            catch (JikanRequestException)
            {
                return await searchAnime(query);
            }
        }
    }
}
