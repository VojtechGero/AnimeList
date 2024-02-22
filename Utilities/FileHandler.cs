using System.Text.Json;

namespace AnimeList
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
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string file = path + "\\AnimeList.json";
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
                string temp = s.Trim();
                if (temp == "[" || temp == "]") continue;
                if(temp.Remove(0,temp.Length - 1) == ",")
                {
                    temp = temp.Remove(temp.Length - 1);
                }
                AContent content = JsonSerializer.Deserialize<AContent>(temp);
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
                if (t== data.Count - 2&&t!=2)
                {
                    data[t -1]= data[t -1].Remove(data[t - 1].Length-1);
                }
                data.RemoveAt(t);
            }
            writeAll();
        }
    }
}
