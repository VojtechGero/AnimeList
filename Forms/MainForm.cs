using AnimeList;
using AnimeList.Utilities;
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
            description.Text = StringOps.animeDesc(anime);
            description.Visible = true;
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
            int toRemove = listBox.SelectedIndex;
            list.RemoveAt(toRemove);
            file.removeAnime(toRemove);
            description.Visible = false;
            writeList();
        }
    }
}
