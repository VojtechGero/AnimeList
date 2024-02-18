using Microsoft.VisualBasic.FileIO;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace AnimeList
{
    public partial class MainForm : Form
    {
        List<AContent> Content = new List<AContent>();
        AddDialog AddForm;
        FileHandler file;
        bool hasScroll;
        /*
         * misses:
         * revenge classroom -- not translated on mal
         * Sounan desu ka? -- japanese name
         * inobato -- cant search by synonym
         * Mahou Shoujo ni Akogarete -- japanese name
         * Oyasumi Punpun -- japanese name
         * Yuru Camp -- japanese name
        */
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
            int width = listBox.Width;
            foreach (AContent item in Content)
            {
                string name = item.name;
                listBox.Items.Add(name);
            }
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.Items[i] = StringOps.shorten(listBox.Items[i].ToString(), listBox);
            }

            listBox.EndUpdate();
        }

        private void updateDesc(AContent content)
        {
            NameLabel.Text = content.name;
            description.Text = StringOps.ContentDesc(content);
            if (content.otherName is not null)
            {
                SwapButton.Visible = true;
            }
            else SwapButton.Visible = false;
            description.Visible = true;
            NameLabel.Visible = true;
        }

        internal void addContent(AContent content)
        {
            Content.Add(content);
            file.writeContent(content);
            listBox.SelectedItems.Clear();
            listBox.Items.Add(StringOps.shorten(content.name, listBox));
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndices.Count > 1)
            {
                description.Visible = false;
                NameLabel.Visible = false;
                SwapButton.Visible = false;
                removeButton.Visible = true;
                RefreshButton.Visible = true;
            }
            else
            {
                int select = listBox.SelectedIndex;
                if (select != -1)
                {
                    updateDesc(Content[select]);
                    removeButton.Visible = true;
                    RefreshButton.Visible = true;
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            description.Visible = false;
            NameLabel.Visible = false;
            SwapButton.Visible = false;
            var selected = new List<int>(listBox.SelectedIndices.Cast<int>());
            selected.Reverse();
            listBox.SelectedItems.Clear();
            foreach (int x in selected)
            {
                Content.RemoveAt(x);
                listBox.Items.RemoveAt(x);
            }
            file.removeContents(selected);
            if (needsChage())
            {
                writeList();
            }
        }

        private void textDumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.InitialDirectory = SpecialDirectories.Desktop;
            openFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.ShowDialog();
            string inputFile = openFile.FileName;
            if (!string.IsNullOrWhiteSpace(inputFile))
            {
                var fileHandleDialog = new FileHandleDialog(inputFile, this);
                fileHandleDialog.MaximizeBox = false;
                fileHandleDialog.MinimizeBox = false;
                fileHandleDialog.ShowDialog();
            }
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


        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var selected = new List<int>(listBox.SelectedIndices.Cast<int>());
            List<AContent> list = new List<AContent>();
            foreach (int i in selected)
            {
                list.Add(Content[i]);
            }
            using (var form = new UpdateDialog(list))
            {
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var output = form.content;
                    for (int i = 0; i < output.Count; i++)
                    {
                        Content[selected[i]] = output[i];
                        listBox.Items[selected[i]] = output[i].name;
                    }
                }
            }
            if (selected.Count == 1)
            {
                updateDesc(Content[selected.First()]);
            }
            file.updateLines(selected, Content);
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            string temp = Content[index].name;
            Content[index].name = Content[index].otherName;
            Content[index].otherName = temp;
            listBox.Items[index] = Content[index].name;
            updateDesc(Content[index]);
            file.updateLine(index, Content[index]);
        }
    }
}
