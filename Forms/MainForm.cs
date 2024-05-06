using AnimeList.Data;
using AnimeList.Utilities;
using System.Diagnostics;
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
    ToolTip LinkToolTip;
    SortType sortOrder = SortType.None;
    public MainForm()
    {
        InitializeComponent();
        fileHandler = FileHandler.workFile();
        listBoxScaling(DeviceDpi, ContentListBox);
        RawContent = fileHandler.GetContent();
        hasScroll = ContentListBox.HasScroll();
        NameToolTip = new ToolTip();
        NameToolTip.SetToolTip(NameLabel, "Click to Copy");
        LinkToolTip = new ToolTip();
        LinkToolTip.SetToolTip(MalLogo, "My Anime List");
        sortWrite();
        ContentListBox.AutoEllipsis();
    }

    private void writeList()
    {
        AContent? selected = null;
        if (ContentListBox.SelectedIndices.Count == 1)
        {
            selected = Sorted[ContentListBox.SelectedIndex];
        }
        List<AContent> list;
        if (!string.IsNullOrWhiteSpace(searchBox.Text))
        {
            query = searchBox.Text;
            Sorted = StringOps.sortSearch(RawContent, query);
            list = Sorted;
        }
        else list = Sorted;
        if (selected is not null)
        {
            var index = getIndex(selected.Id, Sorted);
            ContentListBox.ClearSelected();
            ContentListBox.SetSelected(index, true);
        }
        ContentListBox.WriteContent(list);
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
        showDescription(true);
        WatchButton.Text = WatchButtonUpdate(content.inProgress);
    }

    internal void addContent(AContent content)
    {
        RawContent.Add(content);
        fileHandler.writeContent(content);
        var selected = new List<int>(ContentListBox.SelectedIndices.Cast<int>());
        ContentListBox.SelectedItems.Clear();
        ContentListBox.Items.Add(ContentListBox.FormatEllipsis(content.name));
        ContentListBox.selectIndices(selected);
        sortWrite();
    }

    private void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ContentListBox.SelectedIndices.Count > 1 || ContentListBox.SelectedIndex == -1)
        {
            showDescription(false);
            SwapButton.Visible = false;
            WatchButton.Visible = false;
        }
        else
        {
            int select = ContentListBox.SelectedIndex;
            if (select != -1) updateDesc(Sorted[select]);
        }
        removeButton.Visible = true;
        RefreshButton.Visible = true;
    }

    private void showDescription(bool show)
    {
        description.Visible = show;
        NameLabel.Visible = show;
        MalLogo.Visible = show;
    }

    private void removeButton_Click(object sender, EventArgs e)
    {
        showDescription(false);
        SwapButton.Visible = false;
        List<int> selected = new List<int>();
        ContentListBox.BeginUpdate();
        foreach (var i in ContentListBox.SelectedIndices.Cast<int>().Reverse())
        {
            selected.Add(getIndex(Sorted[i].Id, RawContent));
            ContentListBox.Items.RemoveAt(i);
        }
        selected.Sort();
        selected.Reverse();
        foreach (int x in selected)
        {
            RawContent.RemoveAt(x);
        }
        fileHandler.removeContents(selected);
        if (needsChage(hasScroll, ContentListBox))
        {
            hasScroll = ContentListBox.HasScroll();
        }
        ContentListBox.EndUpdate();
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
        if (needsChage(hasScroll, ContentListBox))
        {
            hasScroll = ContentListBox.HasScroll();
            writeList();
        }
    }

    private async void RefreshButton_Click(object sender, EventArgs e)
    {
        var selected = new List<int>(ContentListBox.SelectedIndices.Cast<int>());
        List<AContent> list = new List<AContent>();
        if (Sorted.Any())
        {
            List<int> temp = new List<int>(selected);
            selected.Clear();
            foreach (var i in temp)
            {
                selected.Add(getIndex(Sorted[i].Id, RawContent));
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
            ContentListBox.Items[selected[i]] = ContentListBox.FormatEllipsis(output[i].name);
        }
        sortWrite();
        fileHandler.updateLines(selected, RawContent);
    }

    private void SwapButton_Click(object sender, EventArgs e)
    {
        int index;
        int current = ContentListBox.SelectedIndex;
        if (Sorted.Any())
        {
            index = getIndex(Sorted[current].Id, RawContent);
        }
        else index = current;
        (RawContent[index].name, RawContent[index].otherName) = (RawContent[index].otherName, RawContent[index].name);
        ContentListBox.Items[current] = ContentListBox.FormatEllipsis(RawContent[index].name);
        updateDesc(RawContent[index]);
        fileHandler.updateLine(index, RawContent[index]);
    }

    private void randomSelectToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (RawContent.Any())
        {
            ContentListBox.ClearSelected();
            var rand = new Random();
            ContentListBox.SelectedIndex = rand.Next(RawContent.Count);
        }
    }

    private void searchBox_TextChanged(object sender, EventArgs e)
    {
        if (RawContent.Any()) sortWrite();
    }

    private void removeDuplicatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        List<long> map = new List<long>();
        List<int> toRemove = new List<int>();
        for (int i = 0; i < RawContent.Count; i++)
        {
            if (map.Contains(RawContent[i].Id))
            {
                toRemove.Add(i);
            }
            else map.Add(RawContent[i].Id);
        }
        if (toRemove.Any())
        {
            if (ContentListBox.SelectedIndices.Count == 1 && toRemove.Contains(ContentListBox.SelectedIndex))
            {
                ContentListBox.SelectedIndex = getDuplicate(RawContent[ContentListBox.SelectedIndex].Id, RawContent);
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
        var index = ContentListBox.SelectedIndex;
        Clipboard.SetText(Sorted[index].name);
        var Mouse = NameLabel.PointToClient(Cursor.Position);
        NameToolTip.Show($"Copied: {Sorted[index].name}", NameLabel,
            Mouse.X, Mouse.Y + Cursor.Size.Height / 2 - 2, 1000);
    }

    private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ContentListBox.SelectAll();
    }

    private void WatchButton_Click(object sender, EventArgs e)
    {
        int index = getIndex(Sorted[ContentListBox.SelectedIndex].Id, RawContent);
        RawContent[index].inProgress = !RawContent[index].inProgress;
        WatchButtonUpdate(RawContent[index].inProgress);
        fileHandler.updateLine(index, RawContent[index]);
        sortWrite();
    }

    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        ContentListBox.MyDrawItem(e, Sorted);
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
        listBoxScaling(DeviceDpi, ContentListBox);
    }

    private void sortWrite()
    {
        AContent? selected = null;
        if (ContentListBox.SelectedIndices.Count == 1)
        {
            selected = Sorted[ContentListBox.SelectedIndex];
        }
        if (string.IsNullOrWhiteSpace(searchBox.Text))
        {
            Sorted = SortBy(RawContent, sortOrder);
        }
        writeList();
        if (selected is not null)
        {
            var index = getIndex(selected.Id, Sorted);
            ContentListBox.ClearSelected();
            ContentListBox.SetSelected(index, true);
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
        sortOrder = SortType.AiredDescending;
        sortWrite();
    }
    private void newestToOldestToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sortOrder = SortType.AiredAscending;
        sortWrite();
    }

    private void finishedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        sortOrder = SortType.Finished;
        sortWrite();
    }

    private void toJsonToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var path = ChooseFolder();
        if (path is not null)
        {
            fileHandler.exportJson(path);
        }
    }

    private void toTxtToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var path = ChooseFolder();
        if (path is not null)
        {
            var names = RawContent.Select(x => x.name).ToList();
            fileHandler.exportTxt(path, names);
        }
    }

    private void statsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        StatsDialog stats = new StatsDialog(RawContent);
        stats.ShowDialog();
    }

    private void MalLogo_Click(object sender, EventArgs e)
    {
        var content = Sorted[ContentListBox.SelectedIndex];
        Process.Start(new ProcessStartInfo
        {
            FileName = StringOps.GetLink(content),
            UseShellExecute = true
        });
    }

    private void MalLogo_MouseEnter(object sender, EventArgs e)
    {
        MalLogo.Cursor = Cursors.Hand;
    }

    private void MalLogo_MouseLeave(object sender, EventArgs e)
    {
        MalLogo.Cursor = Cursors.Default;
    }

    private void NameLabel_MouseEnter(object sender, EventArgs e)
    {
        NameLabel.Cursor = Cursors.Hand;
    }

    private void NameLabel_MouseLeave(object sender, EventArgs e)
    {
        NameLabel.Cursor = Cursors.Default;
    }
}
