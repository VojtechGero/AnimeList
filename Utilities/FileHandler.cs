using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using static System.Windows.Forms.LinkLabel;

namespace AnimeList
{
    public class FileHandler
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
            string file = path + "\\AnimeList.json";
            if (!File.Exists(file))
            {
                File.Create(file);
            }
            return new FileHandler(file);
        }

        void readContent()
        {
            data = File.ReadAllLines(file).ToList();
        }

        internal List<AContent> GetContent()
        {
            List<AContent> contents = new List<AContent>();
            readContent();
            foreach (string s in data)
            {
                AContent content = JsonSerializer.Deserialize<AContent>(s.Trim());
                if(content.IsAnime)
                {
                    contents.Add(new Anime(content));
                }
                else
                {
                    contents.Add(new Manga(content));
                }
            }
            return contents;
        }

        internal void writeContent(AContent a)
        {
            string newLine = a.ToJson();
            File.AppendAllText(file, newLine + Environment.NewLine);
            data.Add(newLine);
        }

        internal void removeContent(int index)
        {
            using (StreamWriter output = new StreamWriter(file))
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (i != index)
                    {
                        output.WriteLine(data[i]);
                    }
                }
            }
            data.RemoveAt(index);
        }


    }
}
