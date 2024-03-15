using AnimeList.Data;
using AnimeList.Utilities;

namespace AnimeList.Forms
{
    public partial class AddDialog : Form
    {
        MainForm Form1;
        MalInterface MalI;
        List<Content> list;
        List<Label> Labels;
        List<Button> Buttons;
        bool Parsing, IdError,IsAnime;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public AddDialog(MainForm form, bool isAnime)
        {
            InitializeComponent();
            list = new List<Content>();
            Buttons = new List<Button>();
            Labels = new List<Label>();
            MalI = new MalInterface();
            addButtons();
            addLabels();
            this.Height = Buttons.Last().Bottom+Buttons.Last().Height*2;
            this.Form1 = form;
            IdError = Parsing = false;
            timer.Tick += new EventHandler(parseInput);
            timer.Interval = 500;
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
            else list.Clear();
            updateForm();
            Parsing = false;
        }

        private async Task parseId()
        {

            long id = long.Parse(idField.Text);
            Content contentFromId;
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
                list.Clear();
                list.Add(contentFromId);
                IdError = false;
            }
            else
            {
                IdError = true;
            }
        }

        private async Task parseSearch()
        {
            list.Clear();
            var content = new List<Content>();
            if (IsAnime)
            {
                content=await MalI.searchAnime(searchBox.Text);
            }
            else
            {
                content=await MalI.searchManga(searchBox.Text);
            }
            if(content is null)
            {
                MessageBox.Show("Server or internet error");
                this.Close();
            }
            else
            {
                list.AddRange(content);
                list = StringOps.sortSearch(list, searchBox.Text);
            }
        }

        private void updateForm()
        {
            ErrorCheck();
            reDrawButtons();
        }

        private void ErrorCheck()
        {
            if (IdError)
            {
                list.Clear();
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
            Content toAdd = list[index];
            Form1.addContent(toAdd);
            this.Dispose();
        }

        private void reDrawButtons()
        {
            int n = list.Count;
            for (int i = 0; i < 5; i++)
            {
                if (i < n)
                {
                    Buttons[i].Visible = true;
                    Labels[i].Text = list[i].name;
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

        private void idField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
