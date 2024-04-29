using AnimeList.Data;
using AnimeList.Utilities;
namespace AnimeList.Forms;

public partial class UpdateDialog : Form
{
    public List<AContent> content;
    bool stopParsing;
    public UpdateDialog(List<AContent> content)
    {
        InitializeComponent();
        stopParsing = false;
        this.content = content;
        setupProgressBar();
        
    }

    void setupProgressBar()
    {
        progressBar.Value = 0;
        progressBar.Maximum = content.Count * 10;
    }

    private async Task<AContent> update(AContent toUpdate,MalInterface m)
    {
        ContentNameLabel.Text = $"Updating {toUpdate.name}";
        AContent newContent;
        if (toUpdate.IsAnime)
        {
            newContent = await m.pullAnimeId(toUpdate.ID);
        }
        else
        {
            newContent = await m.pullMangaId(toUpdate.ID);
        }
        if (newContent.otherName == toUpdate.name)
        {
            (newContent.name, newContent.otherName) = (newContent.otherName, newContent.name);
        }
        newContent.inProgress = toUpdate.inProgress;
        progressBar.PerformStep();
        return newContent;
    }

    private void UpradeRemoveDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
        stopParsing = true;
    }

    private async void UpdateDialog_Shown(object sender, EventArgs e)
    {
        
        MalInterface mal = new MalInterface();
        ContentNameLabel.Visible = true;
        for(int i=0;i<content.Count;i++)
        {
            if (stopParsing) break;
            content[i] = await update(content[i],mal);
        }
        this.DialogResult = DialogResult.OK;
    }
}
