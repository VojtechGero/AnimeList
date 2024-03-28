using Microsoft.VisualBasic.FileIO;
using AnimeList.Utilities;
using AnimeList.Data;
using static AnimeList.Utilities.MainFormUtils;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
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
        SortType sortOrder = SortType.None;
        public MainForm()
        {
            InitializeComponent();
            fileHandler = FileHandler.workFile();
            listBoxScaling(this.DeviceDpi, listBox);
            Content = fileHandler.GetContent();
            Sorted = SortBy(Content, sortOrder);
            hasScroll = listBox.HasScroll();
            var NameToolTip = new ToolTip();
            NameToolTip.SetToolTip(NameLabel, "Click to Copy");
            writeList();
            listBox.AutoEllipsis();
        }

        private void writeList()
        {
            listBox.BeginUpdate();
            int selected = -1;
            if (listBox.SelectedIndices.Count == 1)
            {
                selected = listBox.SelectedIndex;
            }
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
            listBox.AutoEllipsis();
            listBox.EndUpdate();
            if (selected != -1)
            {
                listBox.SetSelected(selected, true);
            }
        }

        private void updateDesc(AContent content)
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
            WatchButton.Text = WatchButtonUpdate(content.inProgress);
        }

        internal void addContent(AContent content)
        {
            Content.Add(content);
            fileHandler.writeContent(content);
            listBox.SelectedItems.Clear();
            listBox.Items.Add(listBox.FormatEllipsis(content.name));
            Sorted = SortBy(Content, SortType.None);
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
                    if (Sorted.Any()) updateDesc(Sorted[select]);
                    else updateDesc(Content[select]);
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
            if (Sorted.Any())
            {
                List<int> temp = new List<int>(selected);
                selected.Clear();
                foreach (var i in temp)
                {
                    selected.Add(getIndex(Sorted[i].ID, Content));
                }
            }
            listBox.SelectedItems.Clear();
            foreach (int x in selected)
            {
                Content.RemoveAt(x);
                listBox.Items.RemoveAt(x);
            }
            fileHandler.removeContents(selected);
            if (needsChage(hasScroll, listBox))
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
            if (needsChage(hasScroll, listBox))
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
                    selected.Add(getIndex(Sorted[i].ID, Content));
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
                        listBox.Items[selected[i]] = listBox.FormatEllipsis(output[i].name);
                    }
                }
            }
            sort(sortOrder);
            if (selected.Count == 1)
            {
                updateDesc(Content[selected.First()]);
                listBox.SetSelected(selected.First(),true);
            }
            fileHandler.updateLines(selected, Content);
        }

        private void SwapButton_Click(object sender, EventArgs e)
        {
            int index;
            int current = listBox.SelectedIndex;
            if (Sorted.Any())
            {
                index = getIndex(Sorted[current].ID, Content);
            }
            else index = current;
            (Content[index].name, Content[index].otherName) = (Content[index].otherName, Content[index].name);
            listBox.Items[current] = listBox.FormatEllipsis(Content[index].name);
            updateDesc(Content[index]);
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
                        listBox.SelectedIndex = getDuplicate(Content[listBox.SelectedIndex].ID, Content);
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
            listBox.SelectAll();
        }

        private void WatchButton_Click(object sender, EventArgs e)
        {
            int index = getIndex(Sorted[listBox.SelectedIndex].ID, Content);
            Content[index].inProgress = !Content[index].inProgress;
            WatchButtonUpdate(Content[index].inProgress);
            fileHandler.updateLine(index, Content[index]);
            sort(sortOrder);
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
            listBoxScaling(this.DeviceDpi, listBox);
        }

        private void sort(SortType sortType)
        {
            AContent selected = null;
            if (listBox.SelectedIndices.Count==1)
            {
                selected = Sorted[listBox.SelectedIndex];
            }
            Sorted = SortBy(Content, sortType);
            if(selected is not null)
            {
                listBox.SetSelected(getIndex(selected.ID, Sorted), true);
            }
            writeList();
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortOrder = SortType.Aplhabetical;
            sort(sortOrder);
        }

        private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortOrder = SortType.Score;
            sort(sortOrder);
        }

        private void actualOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sortOrder = SortType.None;
            sort(sortOrder);
        }
    }
}
