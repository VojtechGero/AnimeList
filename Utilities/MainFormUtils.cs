using AnimeList.Components;
using AnimeList.Data;
using Microsoft.VisualBasic.FileIO;

namespace AnimeList.Utilities;

internal static class MainFormUtils
{
    internal enum SortType
    {
        None,
        Aplhabetical,
        Score,
        Finished,
        Aired
    }

    internal static void listBoxScaling(int dpi,MyListBox listBox)
    {
        double scale = (double)dpi / 96;
        var scaled = listBox.ItemHeight * scale;
        listBox.ItemHeight = (int)scaled;
    }

    internal static int getIndex(long id,List<AContent> Content)
    {
        for (int i = 0; i < Content.Count; i++)
        {
            if (Content[i].ID == id) return i;
        }
        return -1;
    }

    internal static bool needsChage(bool hasScroll,MyListBox listBox)
    {
        bool n = listBox.HasScroll();
        if (n != hasScroll)
        {
            return true;
        }
        else return false;
    }

    internal static int getDuplicate(long id,List<AContent> Content)
    {
        for (int i = 0; i < Content.Count; i++)
        {
            if (Content[i].ID == id) return i;
        }
        return -1;
    }

    internal static string WatchButtonUpdate(bool watching)
    {
        return watching ? "UnWatch" : "Watch";
    }
    
    internal static string ChooseFile(string fileType)
    {
        var openFile = new OpenFileDialog();
        openFile.InitialDirectory = SpecialDirectories.Desktop;
        openFile.Filter = $"{fileType} files (*.{fileType})|*.{fileType}|All files (*.*)|*.*";
        openFile.CheckFileExists = true;
        openFile.CheckPathExists = true;
        openFile.ShowDialog();
        return openFile.FileName;
    }

    internal static List<AContent> SortBy(List<AContent> Content, SortType s)
    {
        IEnumerable<AContent> Sorted = Content;
        switch (s)
        {
            case SortType.Aplhabetical:
                Sorted=Sorted.OrderBy(content => content.name);
                break;
            case SortType.Score:
                Sorted = Sorted.OrderByDescending(content => content.Score);
                break;
            case SortType.Finished:
                Sorted = Sorted.OrderBy(content => content.notOut);
                break;
            case SortType.Aired:
                Sorted = Sorted.OrderBy(content => content.started);
                break;
        }
        return Sorted.OrderByDescending(content => content.inProgress).ToList();
    }
}
