using AnimeList.Components;
using AnimeList.Data;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace AnimeList.Utilities;

internal static class MainFormUtils
{
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
            if (Content[i].Id == id) return i;
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
            if (Content[i].Id == id) return i;
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

    internal static string? ChooseFolder()
    {
        var openFolder = new FolderBrowserDialog();
        DialogResult result = openFolder.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFolder.SelectedPath))
        {
            return openFolder.SelectedPath;
        }
        return null;
    }

    private static IEnumerable<AContent> SortContent(IEnumerable<AContent> list,SortType s)
    {
        return s switch
        {
            SortType.Aplhabetical => list.OrderBy(content => content.name),
            SortType.Score => list.OrderByDescending(content => content.Score),
            SortType.Finished => list.OrderBy(content => content.notOut),
            SortType.AiredDescending => list.OrderBy(content => content.started),
            SortType.AiredAscending => list.OrderByDescending (content => content.started),
            _ => list
        };
    }

    internal static List<AContent> SortBy(List<AContent> Content, SortType s)
    {
        IEnumerable<AContent> Sorted = SortContent(Content, s);
        return Sorted.OrderByDescending(content => content.inProgress).ToList();
    }

}
