using AnimeList.Utilities;
using AnimeList.Data;
using static AnimeList.Utilities.MainFormUtils;
namespace AnimeList.Forms;

public partial class MainForm : Form
{
    List<AContent> RawContent = new List<AContent>();
    List<AContent> Sorted = new List<AContent>();
    AddDialog AddForm;
    FileHandler fileHandler;
    string query;
    bool hasScroll;
    ToolTip NameToolTip;
    SortType sortOrder = SortType.None;
    public MainForm()
    {
        InitializeComponent();
        fileHandler = FileHandler.workFile();
        listBoxScaling(DeviceDpi, listBox);
        RawContent = fileHandler.GetContent();
        hasScroll = listBox.HasScroll();
        NameToolTip = new ToolTip();
        NameToolTip.SetToolTip(NameLabel, "Click to Copy");
        sortWrite();
        listBox.AutoEllipsis();
    }

    private void writeList()
    {
        List<AContent> list;
        if (!string.IsNullOrWhiteSpace(searchBox.Text))
        {
            query = searchBox.Text;
            Sorted = StringOps.sortSearch(RawContent, query);
            list = Sorted;
        }
        else list = Sorted;
        listBox.WriteContent(list);
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
        RawContent.Add(content);
        fileHandler.writeContent(content);
        var selected = new List<int>(listBox.SelectedIndices.Cast<int>());
        listBox.SelectedItems.Clear();
        listBox.Items.Add(listBox.FormatEllipsis(content.name));
        listBox.selectIndices(selected);
        sortWrite();
    }

    private void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox.SelectedIndices.Count > 1 || listBox.SelectedIndex == -1)
        {
            description.Visible = false;
            NameLabel.Visible = false;
            SwapButton.Visible = false;
            WatchButton.Visible = false;
        }
        else
        {
            int select = listBox.SelectedIndex;
            if (select != -1)
            {
                updateDesc(Sorted[select]);
            }
        }
        removeButton.Visible = true;
        RefreshButton.Visible = true;
    }

    private void removeButton_Click(object sender, EventArgs e)
    {
        description.Visible = false;
        NameLabel.Visible = false;
        SwapButton.Visible = false;
        List<int> selected = new List<int>();
        listBox.BeginUpdate();
        foreach (var i in listBox.SelectedIndices.Cast<int>().Reverse())
        {
            selected.Add(getIndex(Sorted[i].ID, RawContent));
            listBox.Items.RemoveAt(i);
        }
        selected.Sort();
        selected.Reverse();
        foreach (int x in selected)
        {
            RawContent.RemoveAt(x);
        }
        fileHandler.removeContents(selected);
        if (needsChage(hasScroll, listBox))
        {
            hasScroll = listBox.HasScroll();
        }
        listBox.EndUpdate();

        sortWrite();
    }

    private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string inputFile = ChooseFile("txt");
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
                selected.Add(getIndex(Sorted[i].ID, RawContent));
            }
        }
        foreach (int i in selected)
        {
            list.Add(RawContent[i]);
        }
        var form = new UpdateDialog(list);
        form.MaximizeBox = false;
        form.MinimizeBox = false;
        form.ShowDialog();
        var output = form.content;
        for (int i = 0; i < output.Count; i++)
        {
            RawContent[selected[i]] = output[i];
            listBox.Items[selected[i]] = listBox.FormatEllipsis(output[i].name);
        }
        sortWrite();
        fileHandler.updateLines(selected, RawContent);
    }

    private void SwapButton_Click(object sender, EventArgs e)
    {
        int index;
        int current = listBox.SelectedIndex;
        if (Sorted.Any())
        {
            index = getIndex(Sorted[current].ID, RawContent);
        }
        else index = current;
        (RawContent[index].name, RawContent[index].otherName) = (RawContent[index].otherName, RawContent[index].name);
        listBox.Items[current] = listBox.FormatEllipsis(RawContent[index].name);
        updateDesc(RawContent[index]);
        fileHandler.updateLine(index, RawContent[index]);
    }

    private void randomSelectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (RawContent.Any())
        {
            listBox.ClearSelected();
            var rand = new Random();
            listBox.SelectedIndex = rand.Next(RawContent.Count);
        }
    }

    private void searchBox_TextChanged(object sender, EventArgs e)
    {
        if (RawContent.Any())
        {
            sortWrite();
        }
    }

    private void removeDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        List<long> map = new List<long>();
        List<int> toRemove = new List<int>();
        for (int i = 0; i < RawContent.Count; i++)
        {
            if (map.Contains(RawContent[i].ID))
            {
                toRemove.Add(i);
            }
            else map.Add(RawContent[i].ID);
        }
        if (toRemove.Any())
        {
            if (listBox.SelectedIndices.Count == 1 && toRemove.Contains(listBox.SelectedIndex))
            {
                listBox.SelectedIndex = getDuplicate(RawContent[listBox.SelectedIndex].ID, RawContent);
            }
            toRemove.Reverse();
            foreach (int i in toRemove)
            {
                RawContent.RemoveAt(i);
            }
            fileHandler.removeContents(toRemove);
            sortWrite();
        }
    }

    private void NameLabel_MouseClick(object sender, MouseEventArgs e)
    {
        var index = listBox.SelectedIndex;
        Clipboard.SetText(Sorted[index].name);
        var Mouse = NameLabel.PointToClient(Cursor.Position);
        NameToolTip.Show($"Copied: {Sorted[index].name}", NameLabel,
            Mouse.X, Mouse.Y + Cursor.Size.Height / 2 - 2, 1000);
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
        listBox.SelectAll();
    }

    private void WatchButton_Click(object sender, EventArgs e)
    {
        int index = getIndex(Sorted[listBox.SelectedIndex].ID, RawContent);
        RawContent[index].inProgress = !RawContent[index].inProgress;
        WatchButtonUpdate(RawContent[index].inProgress);
        fileHandler.updateLine(index, RawContent[index]);
        sortWrite();
    }

    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        listBox.MyDrawItem(e, Sorted);
    }

    private void fromJsonToolStripMenuItem_Click(object sender, EventArgs e)
    {
        string inputFilePath = ChooseFile("json");
        if (!string.IsNullOrWhiteSpace(inputFilePath))
        {
            fileHandler.copyJson(inputFilePath);
        }
        RawContent = fileHandler.GetContent();
        sortWrite();
    }

    private void MainForm_DpiChanged(object sender, DpiChangedEventArgs e)
    {
        listBoxScaling(DeviceDpi, listBox);
    }

    private void sortWrite()
    {
        AContent? selected = null;
        if (listBox.SelectedIndices.Count == 1)
        {
            selected = Sorted[listBox.SelectedIndex];
        }
        if (string.IsNullOrWhiteSpace(searchBox.Text))
        {
            Sorted = SortBy(RawContent, sortOrder);
        }
        writeList();
        if (selected is not null)
        {
            var index = getIndex(selected.ID, Sorted);
            listBox.ClearSelected();
            listBox.SetSelected(index, true);
        }
    }
    private void nameToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sortOrder = SortType.Aplhabetical;
        sortWrite();
    }
    private void scoreToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sortOrder = SortType.Score;
        sortWrite();
    }
    private void actualOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sortOrder = SortType.None;
        sortWrite();
    }
    private void yearAiredToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sortOrder = SortType.Aired;
        sortWrite();
    }
    private void finishedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sortOrder = SortType.Finished;
        sortWrite();
    }

    private void toJsonToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var openFolder = new FolderBrowserDialog();
        DialogResult result = openFolder.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFolder.SelectedPath))
        {
            string path = openFolder.SelectedPath;
            fileHandler.exportJson(path);
        }
    }

    private void toTxtToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var openFolder = new FolderBrowserDialog();
        DialogResult result = openFolder.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFolder.SelectedPath))
        {
            string path = openFolder.SelectedPath;
            var names = RawContent.Select(x => x.name).ToList();
            fileHandler.exportTxt(path, names);
        }
    }

    private void statsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        StatsDialog stats=new StatsDialog(RawContent);
        stats.ShowDialog();
    }
}
