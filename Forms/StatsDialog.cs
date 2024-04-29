using AnimeList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeList.Forms
{
    public partial class StatsDialog : Form
    {
        public StatsDialog(List<AContent> list)
        {
            InitializeComponent();
            StatsLabel.Text = Stats(list);
        }

        private static string Stats(List<AContent> list)
        {
            string output = "";
            output += $"Total count: {list.Count}\n";
            int animes=list.Where(x=>x.IsAnime).Count();
            int mangas=list.Where(x=>!x.IsAnime).Count();
            output += $"Animes: {animes}\nMangas: {mangas}";
            return output;
        }

    }
}
