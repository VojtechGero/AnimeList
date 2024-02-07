using AnimeList;
using JikanDotNet;
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
        MainForm Form1;
        MalInterface MalI;
        List<Anime> animeList;
        List<Label> labels;
        List<Button> buttons;
        bool parsing;
        bool idError;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public AddForm(MainForm form)
        {
            InitializeComponent();
            animeList = new List<Anime>();
            buttons = new List<Button>();
            labels = new List<Label>();
            MalI = new MalInterface();
            addButtons();
            addLabels();
            this.Form1 = form;
            idError = parsing = false;
            timer.Tick += new EventHandler(parseInput);
            timer.Interval = 300;
        }

        private async void parseInput(object? sender, EventArgs e)
        {
            parsing = true;
            timer.Stop();
            if (string.IsNullOrWhiteSpace(idField.Text) && !string.IsNullOrWhiteSpace(searchBox.Text))
            {
                await parseSearch();
            }
            else if (!string.IsNullOrWhiteSpace(idField.Text))
            {
                await parseId();
            }
            else animeList.Clear();
            updateForm();
            parsing = false;
        }

        private async Task parseId()
        {
            
            if (long.TryParse(idField.Text, out long id))
            {
                Anime animeFromId = await MalI.pullAnimeId(id);
                if (animeFromId != null)
                {
                    animeList.Clear();
                    animeList.Add(animeFromId);
                    idError = false;
                }
                else
                {
                    idError = true;
                }
            }
        }

        private async Task parseSearch()
        {
            animeList.Clear();
            animeList.AddRange(await MalI.searchAnime(searchBox.Text));
        }

        private void updateForm()
        {
            idErrorCheck();
            reDrawButtons();
        }

        private void idErrorCheck()
        {
            if (idError)
            {
                animeList.Clear();
                errorLabel.Text = "Invalid Id";
                errorLabel.Visible = true;
            }
            else errorLabel.Visible = false;
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

        private async void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int index = buttons.IndexOf(clickedButton);
            Anime toAdd = animeList[index];
            Form1.addAnime(toAdd);
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
            if (!parsing)
            {
                timer.Stop();
                timer.Start();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if(!parsing)
            {
                timer.Stop();
                timer.Start();
            }
        }
    }
}
