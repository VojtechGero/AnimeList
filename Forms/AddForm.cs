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
        List<AContent> List;
        List<Label> Labels;
        List<Button> Buttons;
        bool Parsing;
        bool IdError;
        bool IsAnime;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public AddForm(MainForm form, bool isAnime)
        {
            InitializeComponent();
            List = new List<AContent>();
            Buttons = new List<Button>();
            Labels = new List<Label>();
            MalI = new MalInterface();
            addButtons();
            addLabels();
            this.Form1 = form;
            IdError = Parsing = false;
            timer.Tick += new EventHandler(parseInput);
            timer.Interval = 300;
            IsAnime = isAnime;
        }

        private async void parseInput(object? sender, EventArgs e)
        {
            Parsing = true;
            timer.Stop();
            if (string.IsNullOrWhiteSpace(idField.Text) && !string.IsNullOrWhiteSpace(searchBox.Text))
            {
                await parseSearch();
            }
            else if (!string.IsNullOrWhiteSpace(idField.Text))
            {
                await parseId();
            }
            else List.Clear();
            updateForm();
            Parsing = false;
        }

        private async Task parseId()
        {

            long id=long.Parse(idField.Text);
            AContent contentFromId;
            if (IsAnime)
            {
                contentFromId = await MalI.pullAnimeId(id);
            }
            else
            {
                contentFromId = await MalI.pullMangaId(id);
            }
            if (contentFromId != null)
            {
                List.Clear();
                List.Add(contentFromId);
                IdError = false;
            }
            else
            {
                IdError = true;
            }
        }

        private async Task parseSearch()
        {
            List.Clear();
            if (IsAnime)
            {
                List.AddRange(await MalI.searchAnime(searchBox.Text));
            }
            else
            {
                List.AddRange(await MalI.searchManga(searchBox.Text));
            }

        }

        private void updateForm()
        {
            idErrorCheck();
            reDrawButtons();
        }

        private void idErrorCheck()
        {
            if (IdError)
            {
                List.Clear();
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
                Buttons.Add(button);
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
                Labels.Add(label);
                Controls.Add(label);
            }
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int index = Buttons.IndexOf(clickedButton);
            AContent toAdd = List[index];
            Form1.addContent(toAdd);
            this.Dispose();
        }

        private void reDrawButtons()
        {
            int n = List.Count;
            for (int i = 0; i < 5; i++)
            {
                if (i < n)
                {
                    Buttons[i].Visible = true;
                    Labels[i].Text = List[i].name;
                    Labels[i].Visible = true;
                }
                else
                {
                    Buttons[i].Visible = false;
                    Labels[i].Visible = false;
                }
            }
        }

        private void idField_TextChanged(object sender, EventArgs e)
        {
            if (!Parsing)
            {
                timer.Stop();
                timer.Start();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (!Parsing)
            {
                timer.Stop();
                timer.Start();
            }
        }

        //allow only digits
        private void idField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled= true;
            }
        }
    }
}
