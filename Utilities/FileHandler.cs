using System.Text.Json;
using AnimeList.Data;

namespace AnimeList.Utilities
{
    public class FileHandler
    {
        string file;
        List<string> data;
        private static readonly string[] start = { "[", "]" };

        FileHandler(string file)
        {
            this.file = file;
            data = new List<string>();
        }

        internal static FileHandler workFile()
        {
            string file = ".\\AnimeList.json";
            if (!File.Exists(file))
            {
                File.AppendAllLines(file,start);
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
                string temp = s.Trim().Trim(',');
                if (temp == "[" || temp == "]" || string.IsNullOrWhiteSpace(temp)) continue;
                UnclassifiedContent content = JsonSerializer.Deserialize<UnclassifiedContent>(temp);
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
            if(data.Count-2 > 0)
            {
                data[data.Count - 2] = data[data.Count - 2] + ",";
            }
            data.Insert(data.Count-1,newLine);
            writeAll();
        }

        private void writeAll()
        {
            File.WriteAllLines(file, data);
        }

        internal void updateLines(List<int> indices,List<AContent> contents)
        {
            foreach (int i in indices)
            {
                int t = i + 1;
                if (t == data.Count - 2)
                {
                    data[t] = contents[t-1].ToJson();
                }
                else
                {
                    data[t] = contents[t-1].ToJson()+",";
                }
            }
            writeAll();
        }

        internal void updateLine(int index, AContent content)
        {
            int t = index + 1;
            if (t == data.Count - 2)
            {
                data[t] = content.ToJson();
            }
            else
            {
                data[t] = content.ToJson() + ",";
            }
            writeAll();
        }

        internal void removeContents(List<int> indices)
        {
            foreach(int i in indices)
            {
                int t = i + 1;
                if (t== data.Count - 2&&t>2)
                {
                    data[t -1]= data[t -1].Remove(data[t - 1].Length-1);
                }
                data.RemoveAt(t);
            }
            writeAll();
        }

        internal void copyJson(string path)
        {
            string[] newText=File.ReadAllLines(path);
            for(int i=1;i<newText.Length-1;i++)
            {
                if (data.Count - 2 > 0&& data[data.Count - 2].Last()!=',')
                {
                    data[data.Count - 2] = data[data.Count - 2] + ",";
                }
                if (newText[i].Last() != ',' && i!=newText.Length - 2) newText[i] += ',';
                data.Insert(data.Count - 1, newText[i]);
            }
            writeAll();
        }

        internal void exportJson(string path)
        {
            string filePath = path + "\\AnimeList.json";
            int i = 1;
            while (File.Exists(filePath))
            {
                filePath = path + $"\\AnimeList({i}).json";
                i++;
            }
            File.WriteAllLines(filePath, data);
        }
    }
}
