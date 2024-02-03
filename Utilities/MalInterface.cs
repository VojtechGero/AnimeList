using JikanDotNet.Exceptions;
using JikanDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeList.Utills
{
    internal class MalInterface
    {
        internal async static void pullAnime(long id, AddForm add)
        {
            try
            {
                IJikan jikan = new Jikan();
                var anime = await jikan.GetAnimeAsync(id);
                add.handleAnime(new Anime(
                    id: (long)anime.Data.MalId,
                    name: anime.Data.Title,
                    episodes: (int)anime.Data.Episodes,
                    airing: anime.Data.Airing));
            }
            catch (JikanValidationException)
            {
                throw new ArgumentException("Invalid Id");
            }
        }
    }
}
