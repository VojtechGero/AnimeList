using AnimeList.Data;
using System.Data;

namespace AnimeList.Forms;

public partial class StatsDialog : Form
{
    public StatsDialog(List<AContent> list)
    {
        InitializeComponent();
        StatsLabel.Text = Stats(list);
    }

    private static string Stats(List<AContent> list)
    {
        string output = "";
        output += $"Total count: {list.Count}\n";
        int animes = list.Where(x => x.IsAnime).Count();
        int mangas = list.Where(x => !x.IsAnime).Count();
        output += $"Animes: {animes}\nMangas: {mangas}";
        return output;
    }

}
