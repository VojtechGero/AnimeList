using AnimeList.Components;

namespace AnimeList.Forms
{
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
            listBox = new MyListBox();
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
            orderByToolStripMenuItem = new ToolStripMenuItem();
            nameToolStripMenuItem = new ToolStripMenuItem();
            scoreToolStripMenuItem = new ToolStripMenuItem();
            actualOrderToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            description = new Label();
            NameLabel = new Label();
            removeButton = new Button();
            RefreshButton = new Button();
            SwapButton = new Button();
            searchBox = new TextBox();
            WatchButton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox
            // 
            listBox.BorderStyle = BorderStyle.FixedSingle;
            listBox.Dock = DockStyle.Left;
            listBox.DrawMode = DrawMode.OwnerDrawFixed;
            listBox.Font = new Font("Segoe UI", 15F);
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 30;
            listBox.Location = new Point(0, 24);
            listBox.Margin = new Padding(2);
            listBox.Name = "listBox";
            listBox.SelectionMode = SelectionMode.MultiExtended;
            listBox.Size = new Size(367, 278);
            listBox.TabIndex = 1;
            listBox.DrawItem += listBox_DrawItem;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, utilitiesToolStripMenuItem, orderByToolStripMenuItem, exportToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(4, 1, 0, 1);
            menuStrip1.Size = new Size(961, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { manualToolStripMenuItem, textDumpToolStripMenuItem });
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(41, 22);
            addToolStripMenuItem.Text = "Add";
            // 
            // manualToolStripMenuItem
            // 
            manualToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { animeToolStripMenuItem, mangaToolStripMenuItem });
            manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            manualToolStripMenuItem.Size = new Size(127, 22);
            manualToolStripMenuItem.Text = "Manual";
            // 
            // animeToolStripMenuItem
            // 
            animeToolStripMenuItem.Name = "animeToolStripMenuItem";
            animeToolStripMenuItem.Size = new Size(111, 22);
            animeToolStripMenuItem.Text = "Anime";
            animeToolStripMenuItem.Click += animeToolStripMenuItem_Click;
            // 
            // mangaToolStripMenuItem
            // 
            mangaToolStripMenuItem.Name = "mangaToolStripMenuItem";
            mangaToolStripMenuItem.Size = new Size(111, 22);
            mangaToolStripMenuItem.Text = "Manga";
            mangaToolStripMenuItem.Click += mangaToolStripMenuItem_Click;
            // 
            // textDumpToolStripMenuItem
            // 
            textDumpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fromTextFileToolStripMenuItem, fromJsonToolStripMenuItem });
            textDumpToolStripMenuItem.Name = "textDumpToolStripMenuItem";
            textDumpToolStripMenuItem.Size = new Size(127, 22);
            textDumpToolStripMenuItem.Text = "File dump";
            // 
            // fromTextFileToolStripMenuItem
            // 
            fromTextFileToolStripMenuItem.Name = "fromTextFileToolStripMenuItem";
            fromTextFileToolStripMenuItem.Size = new Size(144, 22);
            fromTextFileToolStripMenuItem.Text = "From text file";
            fromTextFileToolStripMenuItem.Click += textFileToolStripMenuItem_Click;
            // 
            // fromJsonToolStripMenuItem
            // 
            fromJsonToolStripMenuItem.Name = "fromJsonToolStripMenuItem";
            fromJsonToolStripMenuItem.Size = new Size(144, 22);
            fromJsonToolStripMenuItem.Text = "From json";
            fromJsonToolStripMenuItem.Click += fromJsonToolStripMenuItem_Click;
            // 
            // utilitiesToolStripMenuItem
            // 
            utilitiesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { randomSelectToolStripMenuItem1, selecToolStripMenuItem, removeDuplicatesToolStripMenuItem1 });
            utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            utilitiesToolStripMenuItem.Size = new Size(58, 22);
            utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // randomSelectToolStripMenuItem1
            // 
            randomSelectToolStripMenuItem1.Name = "randomSelectToolStripMenuItem1";
            randomSelectToolStripMenuItem1.Size = new Size(174, 22);
            randomSelectToolStripMenuItem1.Text = "Random select";
            randomSelectToolStripMenuItem1.Click += randomSelectToolStripMenuItem_Click;
            // 
            // selecToolStripMenuItem
            // 
            selecToolStripMenuItem.Name = "selecToolStripMenuItem";
            selecToolStripMenuItem.Size = new Size(174, 22);
            selecToolStripMenuItem.Text = "Select all";
            selecToolStripMenuItem.Click += selectAllToolStripMenuItem_Click;
            // 
            // removeDuplicatesToolStripMenuItem1
            // 
            removeDuplicatesToolStripMenuItem1.Name = "removeDuplicatesToolStripMenuItem1";
            removeDuplicatesToolStripMenuItem1.Size = new Size(174, 22);
            removeDuplicatesToolStripMenuItem1.Text = "Remove duplicates";
            removeDuplicatesToolStripMenuItem1.Click += removeDuplicatesToolStripMenuItem_Click;
            // 
            // orderByToolStripMenuItem
            // 
            orderByToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nameToolStripMenuItem, scoreToolStripMenuItem, actualOrderToolStripMenuItem });
            orderByToolStripMenuItem.Name = "orderByToolStripMenuItem";
            orderByToolStripMenuItem.Size = new Size(65, 22);
            orderByToolStripMenuItem.Text = "Order by";
            // 
            // nameToolStripMenuItem
            // 
            nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            nameToolStripMenuItem.Size = new Size(180, 22);
            nameToolStripMenuItem.Text = "Name";
            nameToolStripMenuItem.Click += nameToolStripMenuItem_Click;
            // 
            // scoreToolStripMenuItem
            // 
            scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
            scoreToolStripMenuItem.Size = new Size(180, 22);
            scoreToolStripMenuItem.Text = "Score";
            scoreToolStripMenuItem.Click += scoreToolStripMenuItem_Click;
            // 
            // actualOrderToolStripMenuItem
            // 
            actualOrderToolStripMenuItem.Name = "actualOrderToolStripMenuItem";
            actualOrderToolStripMenuItem.Size = new Size(180, 22);
            actualOrderToolStripMenuItem.Text = "Actual order";
            actualOrderToolStripMenuItem.Click += actualOrderToolStripMenuItem_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(53, 22);
            exportToolStripMenuItem.Text = "Export";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Font = new Font("Segoe UI", 12F);
            description.Location = new Point(371, 84);
            description.Margin = new Padding(2, 0, 2, 0);
            description.Name = "description";
            description.Size = new Size(87, 21);
            description.TabIndex = 3;
            description.Text = "description";
            description.Visible = false;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 15F);
            NameLabel.ForeColor = SystemColors.ControlText;
            NameLabel.Location = new Point(371, 56);
            NameLabel.Margin = new Padding(2, 0, 2, 0);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(64, 28);
            NameLabel.TabIndex = 4;
            NameLabel.Text = "Name";
            NameLabel.Visible = false;
            NameLabel.MouseClick += NameLabel_MouseClick;
            // 
            // removeButton
            // 
            removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            removeButton.Font = new Font("Segoe UI", 14F);
            removeButton.Location = new Point(820, 262);
            removeButton.Margin = new Padding(2);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(132, 33);
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
            RefreshButton.Location = new Point(684, 262);
            RefreshButton.Margin = new Padding(2);
            RefreshButton.Name = "RefreshButton";
            RefreshButton.Size = new Size(132, 33);
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
            SwapButton.Location = new Point(684, 226);
            SwapButton.Margin = new Padding(2);
            SwapButton.Name = "SwapButton";
            SwapButton.Size = new Size(132, 33);
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
            searchBox.Location = new Point(367, 24);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(594, 29);
            searchBox.TabIndex = 8;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // WatchButton
            // 
            WatchButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            WatchButton.Font = new Font("Segoe UI", 14F);
            WatchButton.Location = new Point(820, 226);
            WatchButton.Margin = new Padding(2);
            WatchButton.Name = "WatchButton";
            WatchButton.Size = new Size(132, 33);
            WatchButton.TabIndex = 9;
            WatchButton.Text = "Watch";
            WatchButton.UseVisualStyleBackColor = true;
            WatchButton.Visible = false;
            WatchButton.Click += WatchButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 302);
            Controls.Add(removeButton);
            Controls.Add(WatchButton);
            Controls.Add(RefreshButton);
            Controls.Add(SwapButton);
            Controls.Add(searchBox);
            Controls.Add(NameLabel);
            Controls.Add(description);
            Controls.Add(listBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "THE LIST";
            DpiChanged += MainForm_DpiChanged;
            Resize += MainForm_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MyListBox listBox;
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
    }
}
