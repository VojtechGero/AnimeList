using AnimeList.Utills;
using AnimeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnimeList
{
    public partial class AddForm : Form
    {
        MainForm Form1 { get; set; }
        MalInterface MalI;
        List<Anime> animeList;
        List<Label> labels;
        List<Button> buttons;
        bool idError;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();


        public AddForm(MainForm f)
        {
            InitializeComponent();
            animeList = new List<Anime>();
            buttons = new List<Button>();
            labels = new List<Label>();
            MalI=new MalInterface();
            addButtons();
            addLabels();
            this.Form1 = f;
            idError = false;

            timer.Tick += new EventHandler(parseInput);
            timer.Interval = 200;

            
        }

        private void parseInput(object? sender, EventArgs e)
        {
            timer.Stop();
            if (string.IsNullOrWhiteSpace(idField.Text))
            {
                MalI.searchAnime(searchBox.Text, this);
            }
            else parseId();
        }

        void parseId()
        {
            if (long.TryParse(idField.Text, out long id))
            {
                MalI.pullAnimeId(id, this);
            }
            animeList.Clear();
            updateForm();
        }

        private void updateForm()
        {
            reDrawButtons();
            idErrorCheck();
        }

        internal void handleAnime(Anime anime)
        {
            animeList.Clear();
            animeList.Add(anime);
            idError = false;
            updateForm();
        }

        internal void handleAnimes(List<Anime> animes)
        {
            animeList.Clear();
            animeList.AddRange(animes);
            updateForm();
        }

        private void idErrorCheck()
        {
            if (idError)
            {
                errorLabel.Text = "Invalid Id";
                errorLabel.Visible = true;
            }
            else errorLabel.Visible = false;
        }

        internal void idExceptionHandle()
        {
            idError = true;
            updateForm();
        }

        private void addButtons()
        {
            for (int i = 0; i < 5; i++)
            {
                Button button = new Button()
                {
                    Text = "Save",
                    Font = new Font("Segoe UI", 12F),
                    Size = new Size(120, 50),
                    Location = new Point(20, 160 + i * 60),
                    Visible = false
                };
                button.Click += Button_Click;
                buttons.Add(button);
                Controls.Add(button);
            }
        }

        private void addLabels()
        {
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label()
                {
                    Font = new Font("Segoe UI", 15F),
                    Location = new Point(120 + 20, 163 + i * 60),
                    Visible = false,
                    AutoSize = true
                };
                labels.Add(label);
                Controls.Add(label);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int index = buttons.IndexOf(clickedButton);
            Form1.addAnime(animeList[index]);
            this.Dispose();
        }

        private void reDrawButtons()
        {
            int n = animeList.Count;
            for (int i = 0; i < 5; i++)
            {
                if (i < n)
                {
                    buttons[i].Visible = true;
                    labels[i].Text = animeList[i].name;
                    labels[i].Visible = true;
                }
                else
                {
                    buttons[i].Visible = false;
                    labels[i].Visible = false;
                }
            }
        }

        private void idField_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
    }
}
