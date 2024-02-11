using AnimeList;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AnimeList
{
    public partial class MainForm : Form
    {
        List<AContent> Content = new List<AContent>();
        AddDialog AddForm;
        FileHandler file;
        bool hasScroll;

        public MainForm()
        {
            InitializeComponent();
            this.file = FileHandler.workFile();
            Content = file.GetContent();
            if (listBox.Size.Height >= listBox.ItemHeight * Content.Count)
            {
                hasScroll = false;
            }
            else
            {
                hasScroll = true;
            }
            writeList();
            
        }

        private bool needsChage()
        {
            bool n;
            if (listBox.Size.Height >= listBox.ItemHeight * Content.Count)
            {
                n = false;
            }
            else
            {
                n = true;
            }
            if (n != hasScroll)
            {
                hasScroll = n;
                return true;
            }
            else return false;
        }

        private void writeList()
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            int width=listBox.Width;
            foreach (AContent item in Content)
            {
                string name = item.name;
                listBox.Items.Add(name);
            }
            for(int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.Items[i]= StringOps.shorten(listBox.Items[i].ToString(), listBox);
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
            var openFile=new OpenFileDialog();
            openFile.InitialDirectory = SpecialDirectories.Desktop;
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.ShowDialog();
            string inputFile = openFile.FileName;
            var fileHandleDialog = new FileHandleDialog(inputFile);
            fileHandleDialog.MaximizeBox = false;
            fileHandleDialog.MinimizeBox = false;
            fileHandleDialog.ShowDialog();
        }


        private void animeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm = new AddDialog(this, true);
            AddForm.ShowDialog();
        }

        private void mangaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm = new AddDialog(this, false);
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
