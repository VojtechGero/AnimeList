using AnimeList.Data;
using AnimeList.Utilities;
using System;
using System.Reflection;
namespace AnimeList.Forms
{
    public partial class UpdateDialog : Form
    {
        public List<Content> content;
        bool stopParsing;
        public UpdateDialog(List<Content> content)
        {
            InitializeComponent();
            stopParsing = false;
            this.content = content;
            setupProgressBar();
            
        }

        void setupProgressBar()
        {
            progressBar.Value = 0;
            progressBar.Maximum = content.Count * 10;
        }

        private async Task<Content> update(Content a,MalInterface m)
        {
            ContentNameLabel.Text = $"Updating {a.name}";
            Content temp;
            if (a.IsAnime)
            {
                temp = await m.pullAnimeId(a.ID);
            }
            else
            {
                temp = await m.pullMangaId(a.ID);
            }
            if (temp.otherName == a.name)
            {
                (temp.name, temp.otherName) = (temp.otherName, temp.name);
            }
            progressBar.PerformStep();
            return temp;
        }

        private void UpradeRemoveDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopParsing = true;
        }

        private async void UpdateDialog_Shown(object sender, EventArgs e)
        {
            
            MalInterface mal = new MalInterface();
            ContentNameLabel.Visible = true;
            for(int i=0;i<content.Count;i++)
            {
                if (stopParsing) break;
                content[i] = await update(content[i],mal);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
