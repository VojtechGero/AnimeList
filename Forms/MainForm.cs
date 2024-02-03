using AnimeList;
using AnimeList.Utills;
using System.Windows.Forms;

namespace AnimeList
{
    public partial class MainForm : Form
    {
        List<Anime> list = new List<Anime>();
        AddForm AddForm;
        FileHandler file;

        public MainForm()
        {
            InitializeComponent();
            this.file = FileHandler.workFile();
            list = file.GetAnimes();
            writeList();
        }

        private void writeList()
        {

            listBox.BeginUpdate();
            listBox.Items.Clear();
            foreach (Anime item in list)
            {
                listBox.Items.Add(item.name);
            }
            listBox.EndUpdate();
        }

        private void updateDesc(Anime anime)
        {
            string toShow = "";
            toShow += $"Name: {anime.name}\n";
            if (anime.episodes > 0) toShow += $"Episodes: {anime.episodes}\n";
            if (anime.airing) toShow += "Currently Airing\n";
            else toShow += "Finished Airing";
            description.Visible = true;
            description.Text = toShow;
        }

        internal void addAnime(Anime anime)
        {
            list.Add(anime);
            file.writeAnime(anime);
            listBox.SelectedItems.Clear();
            writeList();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = listBox.SelectedIndex;
            if (select != -1)
            {
                updateDesc(list[select]);
                removeButton.Visible = true;
            }
        }

        private void myAnimeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm = new AddForm(this);
            AddForm.Show();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            list.RemoveAt(listBox.SelectedIndex);
            writeList();
        }
    }
}
