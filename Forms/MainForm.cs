using AnimeList;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnimeList
{
    public partial class MainForm : Form
    {
        List<AContent> Content = new List<AContent>();
        AddForm AddForm;
        FileHandler file;
        int textLimit = 33;

        public MainForm()
        {
            InitializeComponent();
            this.file = FileHandler.workFile();
            Content = file.GetContent();
            writeList();
        }

        private bool needsChage()
        {
            int n;
            MessageBox.Show(listBox.Size.Height.ToString());
            if (listBox.Size.Height >= listBox.ItemHeight * Content.Count)
            {
                n = 36;
            }
            else
            {
                n = 33;
            }
            if (n != textLimit)
            {
                textLimit = n;
                return true;
            }
            else return false;
        }
        private void writeList()
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            foreach (AContent item in Content)
            {
                string name = item.name;
                name = StringOps.shorten(name, textLimit);
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

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (needsChage())
            {
                writeList();
            }
        }
    }
}
