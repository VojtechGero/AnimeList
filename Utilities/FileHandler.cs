using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
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
            string file = path + "\\AnimeList.txt";
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
                AContent c;
                if (s[0] == 'A')
                {
                    c = new Anime(s);
                }
                else c=new Manga(s);
                contents.Add(c);
            }
            return contents;
        }

        internal void writeContent(AContent a)
        {
            string newLine = a.ToString();
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
