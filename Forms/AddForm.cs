using AnimeList.Utills;
using AnimeList;
using JikanDotNet.Exceptions;
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
    public partial class AddForm : Form
    {
        MainForm Form1 { get; set; }
        public AddForm(MainForm f)
        {
            InitializeComponent();
            this.Form1 = f;
        }
        internal void handleAnime(Anime anime)
        {
            Form1.addAnime(anime);
            this.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            long id = long.Parse(idField.Text);
            try
            {
                MalInterface.pullAnime(id,this);
            }
            catch (JikanValidationException)
            {
                throw new ArgumentException("Invalid Id");
            }
        }
    }
}
