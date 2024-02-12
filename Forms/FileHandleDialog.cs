using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeList
{
    public partial class FileHandleDialog : Form
    {
        string path;
        List<string> names;
        MainForm mainForm;
        public FileHandleDialog(string path,MainForm main)
        {
            InitializeComponent();
            this.path = path;
            this.mainForm = main;
            fileNameLabel.Text = "Parsing: " + StringOps.getFileName(path);
            names = FileHandler.getLines(path);
            setupProgressBar();

        }

        void setupProgressBar()
        {
            progressBar.Value = 0;
            progressBar.Maximum = names.Count * 10;
        }

        AContent bestCandidate(List<AContent> content,string query)
        {
            if (!content.Any()) return null;
            content = StringOps.sortSearch(content,query);
            return content.First();
        }

        async Task parseList()
        {
            MalInterface mal=new MalInterface();
            List<AContent> content = new List<AContent>();
            foreach (string name in names)
            {
                string query = name.Trim();
                CurrentNameLabel.Text = "Processing: " + query;
                content.Clear();
                content.AddRange(await mal.searchAnime(query));
                content.AddRange(await mal.searchManga(query));
                AContent candidate = bestCandidate(content,query);
                if (candidate != null)
                {
                    mainForm.addContent(candidate);
                }
                progressBar.PerformStep();
            }
            progressBar.PerformStep();
        }


        private void FileHandleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private async void FileHandleDialog_Shown(object sender, EventArgs e)
        {
            await parseList();
            Close();
        }
    }
}
