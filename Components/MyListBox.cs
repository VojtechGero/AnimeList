using AnimeList.Data;
namespace AnimeList.Components;

internal class MyListBox : ListBox
{
    public MyListBox()
    {
        SetStyle(
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.UserPaint,
            true);
        this.DoubleBuffered = true;

        DrawMode = DrawMode.OwnerDrawFixed;
    }
    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        if (Items.Count > 0)
        {
            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, new SolidBrush(ForeColor), new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawBackground();
        }
        base.OnDrawItem(e);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Region iRegion = new Region(e.ClipRectangle);
        e.Graphics.FillRegion(new SolidBrush(BackColor), iRegion);
        if (Items.Count > 0)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                Rectangle irect = GetItemRectangle(i);
                if (e.ClipRectangle.IntersectsWith(irect))
                {
                    if (SelectionMode == SelectionMode.One && SelectedIndex == i
                    || SelectionMode == SelectionMode.MultiSimple && SelectedIndices.Contains(i)
                    || SelectionMode == SelectionMode.MultiExtended && SelectedIndices.Contains(i))
                    {
                        OnDrawItem(new DrawItemEventArgs(e.Graphics, Font,
                            irect, i,
                            DrawItemState.Selected, ForeColor,
                            BackColor));
                    }
                    else
                    {
                        OnDrawItem(new DrawItemEventArgs(e.Graphics, Font,
                            irect, i,
                            DrawItemState.Default, ForeColor,
                            BackColor));
                    }
                    iRegion.Complement(irect);
                }
            }
        }
        base.OnPaint(e);
    }

    public void AutoEllipsis()
    {
        BeginUpdate();
        for (int i = 0; i < Items.Count; i++)
        {
            Items[i] = FormatEllipsis(Items[i].ToString());
        }
        EndUpdate();
    }

    public void MyDrawItem(DrawItemEventArgs e, List<AContent> Sorted)
    {
        if (e.Index < 0) return;
        e.DrawBackground();
        var selectedColor = new SolidBrush(Color.FromArgb(0, 120, 215));
        var watchedColor = Brushes.Green;
        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        {
            e.Graphics.FillRectangle(selectedColor, e.Bounds);
            e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
        }
        else
        {
            if (Sorted[e.Index].InProgress)
            {
                e.Graphics.FillRectangle(watchedColor, e.Bounds);
                e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, Brushes.White, e.Bounds, StringFormat.GenericDefault);
            }
            else
            {
                e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            }
        }
        e.DrawFocusRectangle();
    }
    public string FormatEllipsis(string inputString)
    {
        if (string.IsNullOrWhiteSpace(inputString)) return "";
        int listBoxWidth = ClientSize.Width;
        Graphics g = CreateGraphics();
        float maxLength = g.MeasureString(inputString, Font).Width;
        if (maxLength > listBoxWidth)
        {
            float availableLength = listBoxWidth;
            string shortenedString = "";
            foreach (char c in inputString)
            {
                string temp = shortenedString + c;
                if (g.MeasureString(temp, Font).Width > availableLength * 0.96) break;
                shortenedString += c;
            }
            return shortenedString.Trim() + "...";
        }
        else
        {
            return inputString;
        }
    }
    public bool HasScroll()
    {
        if (Size.Height >= ItemHeight * Items.Count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void WriteContent(List<AContent> list)
    {
        BeginUpdate();
        Items.Clear();
        foreach (AContent item in list)
        {
            string name = item.Name;
            Items.Add(name);
        }
        AutoEllipsis();
        EndUpdate();
    }

    public void selectIndices(List<int> list)
    {
        BeginUpdate();
        foreach (int i in list)
        {
            SetSelected(i, true);
        }
        EndUpdate();
    }

    public void SelectAll()
    {
        BeginUpdate();
        for (int i = 0; i < Items.Count; i++)
        {
            SetSelected(i, true);
        }
        EndUpdate();
    }
}
