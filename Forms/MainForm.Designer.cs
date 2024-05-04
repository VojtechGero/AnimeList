using AnimeList.Components;

namespace AnimeList.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ContentListBox = new MyListBox();
        menuStrip1 = new MenuStrip();
        addToolStripMenuItem = new ToolStripMenuItem();
        manualToolStripMenuItem = new ToolStripMenuItem();
        animeToolStripMenuItem = new ToolStripMenuItem();
        mangaToolStripMenuItem = new ToolStripMenuItem();
        textDumpToolStripMenuItem = new ToolStripMenuItem();
        fromTextFileToolStripMenuItem = new ToolStripMenuItem();
        fromJsonToolStripMenuItem = new ToolStripMenuItem();
        utilitiesToolStripMenuItem = new ToolStripMenuItem();
        randomSelectToolStripMenuItem1 = new ToolStripMenuItem();
        selecToolStripMenuItem = new ToolStripMenuItem();
        removeDuplicatesToolStripMenuItem1 = new ToolStripMenuItem();
        statsToolStripMenuItem = new ToolStripMenuItem();
        orderByToolStripMenuItem = new ToolStripMenuItem();
        nameToolStripMenuItem = new ToolStripMenuItem();
        scoreToolStripMenuItem = new ToolStripMenuItem();
        yearAiredToolStripMenuItem = new ToolStripMenuItem();
        newestToOldestToolStripMenuItem = new ToolStripMenuItem();
        finishedToolStripMenuItem = new ToolStripMenuItem();
        actualOrderToolStripMenuItem = new ToolStripMenuItem();
        exportToolStripMenuItem = new ToolStripMenuItem();
        toJsonToolStripMenuItem = new ToolStripMenuItem();
        toTxtToolStripMenuItem = new ToolStripMenuItem();
        description = new Label();
        NameLabel = new Label();
        removeButton = new Button();
        RefreshButton = new Button();
        SwapButton = new Button();
        searchBox = new TextBox();
        WatchButton = new Button();
        MalLogo = new PictureBox();
        menuStrip1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MalLogo).BeginInit();
        SuspendLayout();
        // 
        // ContentListBox
        // 
        ContentListBox.BorderStyle = BorderStyle.FixedSingle;
        ContentListBox.Dock = DockStyle.Left;
        ContentListBox.DrawMode = DrawMode.OwnerDrawFixed;
        ContentListBox.Font = new Font("Segoe UI", 15F);
        ContentListBox.FormattingEnabled = true;
        ContentListBox.ItemHeight = 30;
        ContentListBox.Location = new Point(0, 33);
        ContentListBox.Name = "ContentListBox";
        ContentListBox.SelectionMode = SelectionMode.MultiExtended;
        ContentListBox.Size = new Size(523, 491);
        ContentListBox.TabIndex = 1;
        ContentListBox.DrawItem += listBox_DrawItem;
        ContentListBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
        // 
        // menuStrip1
        // 
        menuStrip1.ImageScalingSize = new Size(24, 24);
        menuStrip1.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, utilitiesToolStripMenuItem, orderByToolStripMenuItem, exportToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1373, 33);
        menuStrip1.TabIndex = 2;
        menuStrip1.Text = "menuStrip1";
        // 
        // addToolStripMenuItem
        // 
        addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manualToolStripMenuItem, textDumpToolStripMenuItem });
        addToolStripMenuItem.Name = "addToolStripMenuItem";
        addToolStripMenuItem.Size = new Size(62, 29);
        addToolStripMenuItem.Text = "Add";
        // 
        // manualToolStripMenuItem
        // 
        manualToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { animeToolStripMenuItem, mangaToolStripMenuItem });
        manualToolStripMenuItem.Name = "manualToolStripMenuItem";
        manualToolStripMenuItem.Size = new Size(193, 34);
        manualToolStripMenuItem.Text = "Manual";
        // 
        // animeToolStripMenuItem
        // 
        animeToolStripMenuItem.Name = "animeToolStripMenuItem";
        animeToolStripMenuItem.Size = new Size(169, 34);
        animeToolStripMenuItem.Text = "Anime";
        animeToolStripMenuItem.Click += animeToolStripMenuItem_Click;
        // 
        // mangaToolStripMenuItem
        // 
        mangaToolStripMenuItem.Name = "mangaToolStripMenuItem";
        mangaToolStripMenuItem.Size = new Size(169, 34);
        mangaToolStripMenuItem.Text = "Manga";
        mangaToolStripMenuItem.Click += mangaToolStripMenuItem_Click;
        // 
        // textDumpToolStripMenuItem
        // 
        textDumpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fromTextFileToolStripMenuItem, fromJsonToolStripMenuItem });
        textDumpToolStripMenuItem.Name = "textDumpToolStripMenuItem";
        textDumpToolStripMenuItem.Size = new Size(193, 34);
        textDumpToolStripMenuItem.Text = "File dump";
        // 
        // fromTextFileToolStripMenuItem
        // 
        fromTextFileToolStripMenuItem.Name = "fromTextFileToolStripMenuItem";
        fromTextFileToolStripMenuItem.Size = new Size(218, 34);
        fromTextFileToolStripMenuItem.Text = "From text file";
        fromTextFileToolStripMenuItem.Click += textFileToolStripMenuItem_Click;
        // 
        // fromJsonToolStripMenuItem
        // 
        fromJsonToolStripMenuItem.Name = "fromJsonToolStripMenuItem";
        fromJsonToolStripMenuItem.Size = new Size(218, 34);
        fromJsonToolStripMenuItem.Text = "From json";
        fromJsonToolStripMenuItem.Click += fromJsonToolStripMenuItem_Click;
        // 
        // utilitiesToolStripMenuItem
        // 
        utilitiesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { randomSelectToolStripMenuItem1, selecToolStripMenuItem, removeDuplicatesToolStripMenuItem1, statsToolStripMenuItem });
        utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
        utilitiesToolStripMenuItem.Size = new Size(85, 29);
        utilitiesToolStripMenuItem.Text = "Utilities";
        // 
        // randomSelectToolStripMenuItem1
        // 
        randomSelectToolStripMenuItem1.Name = "randomSelectToolStripMenuItem1";
        randomSelectToolStripMenuItem1.Size = new Size(263, 34);
        randomSelectToolStripMenuItem1.Text = "Random select";
        randomSelectToolStripMenuItem1.Click += randomSelectToolStripMenuItem_Click;
        // 
        // selecToolStripMenuItem
        // 
        selecToolStripMenuItem.Name = "selecToolStripMenuItem";
        selecToolStripMenuItem.Size = new Size(263, 34);
        selecToolStripMenuItem.Text = "Select all";
        selecToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
        // 
        // removeDuplicatesToolStripMenuItem1
        // 
        removeDuplicatesToolStripMenuItem1.Name = "removeDuplicatesToolStripMenuItem1";
        removeDuplicatesToolStripMenuItem1.Size = new Size(263, 34);
        removeDuplicatesToolStripMenuItem1.Text = "Remove duplicates";
        removeDuplicatesToolStripMenuItem1.Click += removeDuplicatesToolStripMenuItem_Click;
        // 
        // statsToolStripMenuItem
        // 
        statsToolStripMenuItem.Name = "statsToolStripMenuItem";
        statsToolStripMenuItem.Size = new Size(263, 34);
        statsToolStripMenuItem.Text = "Stats";
        statsToolStripMenuItem.Click += statsToolStripMenuItem_Click;
        // 
        // orderByToolStripMenuItem
        // 
        orderByToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nameToolStripMenuItem, scoreToolStripMenuItem, yearAiredToolStripMenuItem, newestToOldestToolStripMenuItem, finishedToolStripMenuItem, actualOrderToolStripMenuItem });
        orderByToolStripMenuItem.Name = "orderByToolStripMenuItem";
        orderByToolStripMenuItem.Size = new Size(99, 29);
        orderByToolStripMenuItem.Text = "Order by";
        // 
        // nameToolStripMenuItem
        // 
        nameToolStripMenuItem.Name = "nameToolStripMenuItem";
        nameToolStripMenuItem.Size = new Size(248, 34);
        nameToolStripMenuItem.Text = "Name";
        nameToolStripMenuItem.Click += nameToolStripMenuItem_Click;
        // 
        // scoreToolStripMenuItem
        // 
        scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
        scoreToolStripMenuItem.Size = new Size(248, 34);
        scoreToolStripMenuItem.Text = "Score";
        scoreToolStripMenuItem.Click += scoreToolStripMenuItem_Click;
        // 
        // yearAiredToolStripMenuItem
        // 
        yearAiredToolStripMenuItem.Name = "yearAiredToolStripMenuItem";
        yearAiredToolStripMenuItem.Size = new Size(248, 34);
        yearAiredToolStripMenuItem.Text = "Oldest to newest";
        yearAiredToolStripMenuItem.Click += yearAiredToolStripMenuItem_Click;
        // 
        // newestToOldestToolStripMenuItem
        // 
        newestToOldestToolStripMenuItem.Name = "newestToOldestToolStripMenuItem";
        newestToOldestToolStripMenuItem.Size = new Size(248, 34);
        newestToOldestToolStripMenuItem.Text = "Newest to oldest";
        newestToOldestToolStripMenuItem.Click += newestToOldestToolStripMenuItem_Click;
        // 
        // finishedToolStripMenuItem
        // 
        finishedToolStripMenuItem.Name = "finishedToolStripMenuItem";
        finishedToolStripMenuItem.Size = new Size(248, 34);
        finishedToolStripMenuItem.Text = "Finished";
        finishedToolStripMenuItem.Click += finishedToolStripMenuItem_Click;
        // 
        // actualOrderToolStripMenuItem
        // 
        actualOrderToolStripMenuItem.Name = "actualOrderToolStripMenuItem";
        actualOrderToolStripMenuItem.Size = new Size(248, 34);
        actualOrderToolStripMenuItem.Text = "Actual order";
        actualOrderToolStripMenuItem.Click += actualOrderToolStripMenuItem_Click;
        // 
        // exportToolStripMenuItem
        // 
        exportToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toJsonToolStripMenuItem, toTxtToolStripMenuItem });
        exportToolStripMenuItem.Name = "exportToolStripMenuItem";
        exportToolStripMenuItem.Size = new Size(79, 29);
        exportToolStripMenuItem.Text = "Export";
        // 
        // toJsonToolStripMenuItem
        // 
        toJsonToolStripMenuItem.Name = "toJsonToolStripMenuItem";
        toJsonToolStripMenuItem.Size = new Size(170, 34);
        toJsonToolStripMenuItem.Text = "To json";
        toJsonToolStripMenuItem.Click += toJsonToolStripMenuItem_Click;
        // 
        // toTxtToolStripMenuItem
        // 
        toTxtToolStripMenuItem.Name = "toTxtToolStripMenuItem";
        toTxtToolStripMenuItem.Size = new Size(170, 34);
        toTxtToolStripMenuItem.Text = "To txt";
        toTxtToolStripMenuItem.Click += toTxtToolStripMenuItem_Click;
        // 
        // description
        // 
        description.AutoSize = true;
        description.Font = new Font("Segoe UI", 12F);
        description.Location = new Point(530, 149);
        description.Name = "description";
        description.Size = new Size(132, 32);
        description.TabIndex = 3;
        description.Text = "description";
        description.Visible = false;
        // 
        // NameLabel
        // 
        NameLabel.AutoSize = true;
        NameLabel.Font = new Font("Segoe UI", 15F);
        NameLabel.ForeColor = SystemColors.ControlText;
        NameLabel.Location = new Point(591, 91);
        NameLabel.Name = "NameLabel";
        NameLabel.Size = new Size(97, 41);
        NameLabel.TabIndex = 4;
        NameLabel.Text = "Name";
        NameLabel.Visible = false;
        NameLabel.MouseClick += NameLabel_MouseClick;
        // 
        // removeButton
        // 
        removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        removeButton.Font = new Font("Segoe UI", 14F);
        removeButton.Location = new Point(1171, 458);
        removeButton.Name = "removeButton";
        removeButton.Size = new Size(189, 55);
        removeButton.TabIndex = 5;
        removeButton.Text = "Remove";
        removeButton.UseVisualStyleBackColor = true;
        removeButton.Visible = false;
        removeButton.Click += removeButton_Click;
        // 
        // RefreshButton
        // 
        RefreshButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        RefreshButton.Font = new Font("Segoe UI", 14F);
        RefreshButton.Location = new Point(977, 458);
        RefreshButton.Name = "RefreshButton";
        RefreshButton.Size = new Size(189, 55);
        RefreshButton.TabIndex = 6;
        RefreshButton.Text = "Refresh";
        RefreshButton.UseVisualStyleBackColor = true;
        RefreshButton.Visible = false;
        RefreshButton.Click += RefreshButton_Click;
        // 
        // SwapButton
        // 
        SwapButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        SwapButton.Font = new Font("Segoe UI", 14F);
        SwapButton.Location = new Point(977, 398);
        SwapButton.Name = "SwapButton";
        SwapButton.Size = new Size(189, 55);
        SwapButton.TabIndex = 7;
        SwapButton.Text = "Swap names";
        SwapButton.UseVisualStyleBackColor = true;
        SwapButton.Visible = false;
        SwapButton.Click += SwapButton_Click;
        // 
        // searchBox
        // 
        searchBox.BorderStyle = BorderStyle.FixedSingle;
        searchBox.Dock = DockStyle.Top;
        searchBox.Font = new Font("Segoe UI", 12F);
        searchBox.Location = new Point(523, 33);
        searchBox.Margin = new Padding(4, 5, 4, 5);
        searchBox.Name = "searchBox";
        searchBox.Size = new Size(850, 39);
        searchBox.TabIndex = 8;
        searchBox.TextChanged += searchBox_TextChanged;
        // 
        // WatchButton
        // 
        WatchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        WatchButton.Font = new Font("Segoe UI", 14F);
        WatchButton.Location = new Point(1171, 398);
        WatchButton.Name = "WatchButton";
        WatchButton.Size = new Size(189, 55);
        WatchButton.TabIndex = 9;
        WatchButton.Text = "Watch";
        WatchButton.UseVisualStyleBackColor = true;
        WatchButton.Visible = false;
        WatchButton.Click += WatchButton_Click;
        // 
        // MalLogo
        // 
        MalLogo.Image = Properties.Resources.MyAnimeList_Logo;
        MalLogo.Location = new Point(530, 91);
        MalLogo.Name = "MalLogo";
        MalLogo.Size = new Size(55, 55);
        MalLogo.SizeMode = PictureBoxSizeMode.StretchImage;
        MalLogo.TabIndex = 10;
        MalLogo.TabStop = false;
        MalLogo.Visible = false;
        MalLogo.Click += MalLogo_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1373, 524);
        Controls.Add(MalLogo);
        Controls.Add(removeButton);
        Controls.Add(WatchButton);
        Controls.Add(RefreshButton);
        Controls.Add(SwapButton);
        Controls.Add(searchBox);
        Controls.Add(NameLabel);
        Controls.Add(description);
        Controls.Add(ContentListBox);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "MainForm";
        Text = "THE LIST";
        DpiChanged += MainForm_DpiChanged;
        Resize += MainForm_Resize;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)MalLogo).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private MyListBox ContentListBox;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem addToolStripMenuItem;
    private ToolStripMenuItem manualToolStripMenuItem;
    private ToolStripMenuItem textDumpToolStripMenuItem;
    private Label description;
    private Label NameLabel;
    private Button removeButton;
    private ToolStripMenuItem animeToolStripMenuItem;
    private ToolStripMenuItem mangaToolStripMenuItem;
    private Button RefreshButton;
    private Button SwapButton;
    private TextBox searchBox;
    private Button WatchButton;
    private ToolStripMenuItem fromTextFileToolStripMenuItem;
    private ToolStripMenuItem fromJsonToolStripMenuItem;
    private ToolStripMenuItem utilitiesToolStripMenuItem;
    private ToolStripMenuItem randomSelectToolStripMenuItem1;
    private ToolStripMenuItem selecToolStripMenuItem;
    private ToolStripMenuItem removeDuplicatesToolStripMenuItem1;
    private ToolStripMenuItem exportToolStripMenuItem;
    private ToolStripMenuItem orderByToolStripMenuItem;
    private ToolStripMenuItem nameToolStripMenuItem;
    private ToolStripMenuItem scoreToolStripMenuItem;
    private ToolStripMenuItem actualOrderToolStripMenuItem;
    private ToolStripMenuItem yearAiredToolStripMenuItem;
    private ToolStripMenuItem finishedToolStripMenuItem;
    private ToolStripMenuItem toJsonToolStripMenuItem;
    private ToolStripMenuItem toTxtToolStripMenuItem;
    private ToolStripMenuItem statsToolStripMenuItem;
    private ToolStripMenuItem newestToOldestToolStripMenuItem;
    private PictureBox MalLogo;
}
