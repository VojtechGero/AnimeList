﻿using System;
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
        public FileHandleDialog(string path)
        {
            InitializeComponent();
            this.path = path;
            fileNameLabel.Text = "Parsing: " + StringOps.getFileName(path);
            names = FileHandler.getLines(path);
            setupProgressBar();

        }

        void setupProgressBar()
        {
            progressBar.Value = 0;
            progressBar.Maximum = names.Count * 10;
        }

        void parseList()
        {
            List<Anime> animes = new List<Anime>();
            List<Manga> mangas = new List<Manga>();
            foreach (string name in names)
            {
                //Application.DoEvents();
                //MessageBox.Show(name);
                animes.Clear();
                mangas.Clear();
                CurrentNameLabel.Text = "Processing: " + name;
                progressBar.PerformStep();
                
            }
        }


        private void FileHandleDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FileHandleDialog_Shown(object sender, EventArgs e)
        {
            parseList();
            Close();
        }
    }
}