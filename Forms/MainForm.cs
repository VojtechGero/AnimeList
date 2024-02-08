using AnimeList;
using System.Windows.Forms;

namespace AnimeList
{
    public partial class MainForm : Form
    {
        List<AContent> Content = new List<AContent>();
        AddForm AddForm;
        FileHandler file;

        public MainForm()
        {
            InitializeComponent();
            this.file = FileHandler.workFile();
            Content = file.GetContent();
            writeList();
        }

        private void writeList()
        {

            listBox.BeginUpdate();
            listBox.Items.Clear();
            foreach (AContent item in Content)
            {
                string name = item.name;
                if (name.Length > 29)
                {
                    name = StringOps.shorten(name);
                }
                listBox.Items.Add(name);
            }
            listBox.EndUpdate();
        }

        private void updateDesc(AContent content)
        {
            description.Text = StringOps.ContentDesc(content);
            description.Visible = true;
        }

        internal void addContent(AContent content)
        {
            Content.Add(content);
            file.writeContent(content);
            listBox.SelectedItems.Clear();
            writeList();
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int select = listBox.SelectedIndex;
            if (select != -1)
            {
                updateDesc(Content[select]);
                removeButton.Visible = true;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            int toRemove = listBox.SelectedIndex;
            Content.RemoveAt(toRemove);
            file.removeContent(toRemove);
            description.Visible = false;
            writeList();
        }

        private void textDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void animeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm = new AddForm(this, true);
            AddForm.ShowDialog();
        }

        private void mangaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm = new AddForm(this, false);
            AddForm.ShowDialog();
        }
    }
}
