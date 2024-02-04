using JikanDotNet.Exceptions;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JikanDotNet.Config;
using AnimeList.Utilities;

namespace AnimeList.Utills
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

        internal async void pullAnimeId(long id, AddForm add)
        {
            try
            {
                var anime = await jikan.GetAnimeAsync(id);
                add.handleAnime(new Anime(
                    id: (long)anime.Data.MalId,
                    name: getTitle(anime.Data.Titles),
                    episodes: anime.Data.Episodes,
                    airing: anime.Data.Airing));
            }
            catch (JikanValidationException)
            {
                add.idExceptionHandle();
            }
            catch (JikanRequestException)
            {
                pullAnimeId(id, add);
            }
        }

        internal async void searchAnime(string query, AddForm add)
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
                    Anime a = new Anime(
                        id: (long)item.MalId,
                        name: getTitle(item.Titles),
                        episodes: item.Episodes,
                        airing: item.Airing
                        );
                    animeList.Add(a);
                }
                animeList= StringOps.sortSearch(animeList,query);
                add.handleAnimes(animeList);
            }
            catch (JikanRequestException)
            {
                searchAnime(query, add);
            }
        }
    }
}
