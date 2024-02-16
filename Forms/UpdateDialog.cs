using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeList
{
    public partial class UpdateDialog : Form
    {
        public List<AContent> content;
        bool stopParsing;
        public UpdateDialog(List<AContent> content)
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

        private async Task<AContent> update(AContent a,MalInterface m)
        {
            ContentNameLabel.Text = $"Updating {a.name}";
            AContent temp;
            if (a.IsAnime)
            {
                temp = await m.pullAnimeId(a.ID);
            }
            else
            {
                temp = await m.pullMangaId(a.ID);
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
