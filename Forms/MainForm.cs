using Microsoft.VisualBasic.FileIO;
using AnimeList.Utilities;
using AnimeList.Data;
namespace AnimeList.Forms
{
    public partial class MainForm : Form
    {
        List<AContent> Content = new List<AContent>();
        List<AContent> Sorted = new List<AContent>();
        AddDialog AddForm;
        FileHandler fileHandler;
        string query;
        bool hasScroll;
        public MainForm()
        {
            InitializeComponent();
            fileHandler = FileHandler.workFile();
            MainFormUtils.listBoxScaling(this.DeviceDpi, listBox);
            Content = fileHandler.GetContent();
            Sorted = Content.OrderByDescending(content => content.inProgress).ToList();
            hasScroll = listBox.HasScroll();
            var NameToolTip = new ToolTip();
            NameToolTip.SetToolTip(NameLabel, "Click to Copy");
            writeList();
        }

        private void writeList()
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            var list = new List<AContent>();
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                query = searchBox.Text;
                Sorted = StringOps.sortSearch(Content, query);
                list = Sorted;
            }
            else list = Sorted;
            foreach (AContent item in list)
            {
                string name = item.name;
                listBox.Items.Add(name);
            }
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.Items[i] = StringOps.listBoxAutoEllipsis(listBox.Items[i].ToString(), listBox);
            }
            listBox.EndUpdate();
        }

        private void updateDesc(AContent content, int index)
        {
            NameLabel.Text = content.name;
            description.Text = content.Description();
            if (content.otherName is not null)
            {
                SwapButton.Visible = true;
            }
            else SwapButton.Visible = false;
            WatchButton.Visible = true;
            description.Visible = true;
            NameLabel.Visible = true;
            watchButtonUpdate(content.inProgress, index);
        }

        internal void addContent(AContent content)
        {
            Content.Add(content);
            fileHandler.writeContent(content);
            listBox.SelectedItems.Clear();
            listBox.Items.Add(StringOps.listBoxAutoEllipsis(content.name, listBox));
            Sorted = Content.OrderByDescending(content => content.inProgress).ToList();
            if (!string.IsNullOrWhiteSpace(searchBox.Text))
            {
                query = searchBox.Text;
                Sorted = StringOps.sortSearch(Content, query);
                writeList();
            }
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
                WatchButton.Visible = false;
            }
            else
            {
                int select = listBox.SelectedIndex;
                if (select != -1)
                {
                    if (Sorted.Any()) updateDesc(Sorted[select], select);
                    else updateDesc(Content[select], select);
                    removeButton.Visible = true;
                    RefreshButton.Visible = true;
                }
            }
        }

        private void watchButtonUpdate(bool inProgress, int index)
        {
            if (inProgress)
            {
                WatchButton.Text = "UnWatch";
            }
            else
            {
                WatchButton.Text = "Watch";
            }
        }
        private void removeButton_Click(object sender, EventArgs e)
        {
            description.Visible = false;
            NameLabel.Visible = false;
            SwapButton.Visible = false;
            var selected = new List<int>(listBox.SelectedIndices.Cast<int>());
            selected.Reverse();
            if (Sorted.Any())
            {
                List<int> temp = new List<int>(selected);
                selected.Clear();
                foreach (var i in temp)
                {
                    selected.Add(MainFormUtils.getIndex(Sorted[i].ID, Content));
                }
            }
            listBox.SelectedItems.Clear();
            foreach (int x in selected)
            {
                MessageBox.Show(Content[x].name);
                Content.RemoveAt(x);
                listBox.Items.RemoveAt(x);
            }
            fileHandler.removeContents(selected);
            if (MainFormUtils.needsChage(hasScroll, listBox))
            {
                hasScroll = listBox.HasScroll();
                writeList();
            }
        }

        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
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
            if (MainFormUtils.needsChage(hasScroll,listBox))
            {
                hasScroll = listBox.HasScroll();
                writeList();
            }
        }


        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            var selected = new List<int>(listBox.SelectedIndices.Cast<int>());
            List<AContent> list = new List<AContent>();
            if (Sorted.Any())
            {
                List<int> temp = new List<int>(selected);
                selected.Clear();
                foreach (var i in temp)
                {
                    selected.Add(MainFormUtils.getIndex(Sorted[i].ID, Content));
                }
            }
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
                        listBox.Items[selected[i]] = StringOps.listBoxAutoEllipsis(output[i].name, listBox);
                    }
                }
            }
            if (selected.Count == 1)
            {
                updateDesc(Content[selected.First()], selected.First());
            }
            fileHandler.updateLines(selected, Content);

        }


        private void SwapButton_Click(object sender, EventArgs e)
        {
            int index;
            int current = listBox.SelectedIndex;
            if (Sorted.Any())
            {
                index = MainFormUtils.getIndex(Sorted[current].ID,Content);
            }
            else index = current;
            (Content[index].name, Content[index].otherName) = (Content[index].otherName, Content[index].name);
            listBox.Items[current] = StringOps.listBoxAutoEllipsis(Content[index].name, listBox);
            updateDesc(Content[index], index);
            fileHandler.updateLine(index, Content[index]);
        }

        private void randomSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Content.Any())
            {
                listBox.ClearSelected();
                var rand = new Random();
                listBox.SelectedIndex = rand.Next(Content.Count);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (Content.Any())
            {
                writeList();
            }
        }

        private int getDuplicate(long id)
        {
            int output = -1;
            for (int i = 0; i < Content.Count; i++)
            {
                if (Content[i].ID == id) return i;
            }
            return output;
        }

        private void removeDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<long> map = new List<long>();
            List<int> toRemove = new List<int>();
            for (int i = 0; i < Content.Count; i++)
            {
                if (map.Contains(Content[i].ID))
                {
                    toRemove.Add(i);
                }
                else map.Add(Content[i].ID);
            }
            if (toRemove.Any())
            {
                if (listBox.SelectedIndices.Count == 1)
                {
                    if (toRemove.Contains(listBox.SelectedIndex))
                    {
                        listBox.SelectedIndex = getDuplicate(Content[listBox.SelectedIndex].ID);
                    }
                }
                toRemove.Reverse();
                foreach (int i in toRemove)
                {
                    Content.RemoveAt(i);
                }
                fileHandler.removeContents(toRemove);
                writeList();
            }
        }

        private void NameLabel_MouseClick(object sender, MouseEventArgs e)
        {
            var index = listBox.SelectedIndex;
            Clipboard.SetText(Content[index].name);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox.BeginUpdate();
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetSelected(i, true);
            }
            listBox.EndUpdate();
        }

        private void WatchButton_Click(object sender, EventArgs e)
        {
            int index = MainFormUtils.getIndex(Sorted[listBox.SelectedIndex].ID,Content);
            Content[index].inProgress = !Content[index].inProgress;
            watchButtonUpdate(Content[index].inProgress, index);
            fileHandler.updateLine(index, Content[index]);
            listBox.Update();
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            var selectedColor = new SolidBrush(Color.FromArgb(0, 120, 215));
            var watchedColor = Brushes.Green;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(selectedColor, e.Bounds);
                e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
            }
            else
            {
                if (Sorted[e.Index].inProgress)
                {
                    e.Graphics.FillRectangle(watchedColor, e.Bounds);
                    e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
                }
                else
                {
                    e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
                }
            }
            e.DrawFocusRectangle();
        }

        private void fromJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.InitialDirectory = SpecialDirectories.Desktop;
            openFile.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.ShowDialog();
            string inputFilePath = openFile.FileName;
            if (!string.IsNullOrWhiteSpace(inputFilePath))
            {
                fileHandler.copyJson(inputFilePath);
            }
            Content = fileHandler.GetContent();
            writeList();
        }

        private void MainForm_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            MainFormUtils.listBoxScaling(this.DeviceDpi, listBox);
        }
    }
}
