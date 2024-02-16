using System;
using System.Text;
using System.Text.Json;

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
                var f=File.Create(file);
                f.Close();
            }
            return new FileHandler(file);
        }
        
        internal static List<string> getLines(string path)
        {
            return File.ReadAllLines(path).ToList();
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

        internal void writeAll()
        {
            File.WriteAllText(file, string.Empty);
            File.AppendAllLines(file, data);
        }

        internal void updateLines(List<int> indices,List<AContent> contents)
        {
            foreach (int i in indices)
            {
                data[i] = contents[i].ToJson();
            }
        }

        internal void removeContent(int index)
        {
            data.RemoveAt(index);
        }
    }
}
