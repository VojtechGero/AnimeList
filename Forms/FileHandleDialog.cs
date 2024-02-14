using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AnimeList
{
    public partial class FileHandleDialog : Form
    {
        string path;
        List<string> names;
        MainForm mainForm;
        bool stopParsing;
        public FileHandleDialog(string path, MainForm main)
        {
            InitializeComponent();
            this.path = path;
            this.mainForm = main;
            fileNameLabel.Text = "Parsing: " + StringOps.getFileName(path);
            names = FileHandler.getLines(path);
            stopParsing = false;
            setupProgressBar();

        }

        void setupProgressBar()
        {
            progressBar.Value = 0;
            progressBar.Maximum = names.Count * 10;
        }

        AContent bestCandidate(List<AContent> content, string query)
        {
            if (!content.Any()) return null;
            content = StringOps.sortSearch(content, query);
            return content.First();
        }

        async Task parseLine(string name,MalInterface mal)
        {
            List<AContent> content = new List<AContent>();
            string query = name.Trim();
            CurrentNameLabel.Text = "Processing: " + query;
            content.Clear();
            content.AddRange(await mal.searchAnime(query));
            content.AddRange(await mal.searchManga(query));
            AContent candidate = bestCandidate(content, query);
            if (candidate != null)
            {
                mainForm.addContent(candidate);
            }
            progressBar.PerformStep();

        }

        private async void FileHandleDialog_Shown(object sender, EventArgs e)
        {
            MalInterface mal = new MalInterface();
            foreach (string name in names)
            {
                if (stopParsing) break;
                await parseLine(name,mal);
            }
            Close();
        }

        private void FileHandleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopParsing = true;
        }
    }
}
