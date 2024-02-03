﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AnimeList.Utills
{
    internal class FileHandler
    {
        string file;
        List<string> data;

        FileHandler(string file)
        {
            this.file = file;
            data = new List<string>();
        }

        internal static FileHandler workFile()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string file = path + "\\AnimeList.txt";
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            return new FileHandler(file);
        }

        void readAnime()
        {
            data = File.ReadAllLines(file).ToList();
        }

        internal List<Anime> GetAnimes()
        {
            List<Anime> animes = new List<Anime>();
            readAnime();
            foreach (string s in data)
            {
                animes.Add(new Anime(s));
            }
            return animes;
        }

        internal void writeAnime(Anime a)
        {
            string newLine = a.ToString();
            File.AppendAllText(file, newLine + Environment.NewLine);
            data.Add(newLine);
        }

    }
}