namespace AnimeList
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
            label1 = new Label();
            listBox = new ListBox();
            menuStrip1 = new MenuStrip();
            addToolStripMenuItem = new ToolStripMenuItem();
            manualToolStripMenuItem = new ToolStripMenuItem();
            myAnimeListToolStripMenuItem = new ToolStripMenuItem();
            textDumpToolStripMenuItem = new ToolStripMenuItem();
            description = new Label();
            label2 = new Label();
            removeButton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 43);
            label1.Name = "label1";
            label1.Size = new Size(110, 41);
            label1.TabIndex = 0;
            label1.Text = "Anime:";
            // 
            // listBox
            // 
            listBox.Font = new Font("Segoe UI", 15F);
            listBox.FormattingEnabled = true;
            listBox.ItemHeight = 41;
            listBox.Location = new Point(12, 106);
            listBox.Name = "listBox";
            listBox.Size = new Size(444, 332);
            listBox.TabIndex = 1;
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1130, 33);
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
            manualToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { myAnimeListToolStripMenuItem });
            manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            manualToolStripMenuItem.Size = new Size(270, 34);
            manualToolStripMenuItem.Text = "Manual";
            // 
            // myAnimeListToolStripMenuItem
            // 
            myAnimeListToolStripMenuItem.Name = "myAnimeListToolStripMenuItem";
            myAnimeListToolStripMenuItem.Size = new Size(270, 34);
            myAnimeListToolStripMenuItem.Text = "MyAnimeList";
            myAnimeListToolStripMenuItem.Click += malToolStripMenuItem_Click;
            // 
            // textDumpToolStripMenuItem
            // 
            textDumpToolStripMenuItem.Name = "textDumpToolStripMenuItem";
            textDumpToolStripMenuItem.Size = new Size(270, 34);
            textDumpToolStripMenuItem.Text = "Text dump";
            // 
            // description
            // 
            description.AutoSize = true;
            description.Font = new Font("Segoe UI", 12F);
            description.Location = new Point(543, 106);
            description.Name = "description";
            description.Size = new Size(132, 32);
            description.TabIndex = 3;
            description.Text = "description";
            description.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(543, 43);
            label2.Name = "label2";
            label2.Size = new Size(169, 41);
            label2.TabIndex = 4;
            label2.Text = "Description";
            // 
            // removeButton
            // 
            removeButton.Font = new Font("Segoe UI", 15F);
            removeButton.Location = new Point(929, 387);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(189, 55);
            removeButton.TabIndex = 5;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Visible = false;
            removeButton.Click += removeButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 454);
            Controls.Add(removeButton);
            Controls.Add(label2);
            Controls.Add(description);
            Controls.Add(listBox);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "THE LIST";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox listBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem manualToolStripMenuItem;
        private ToolStripMenuItem textDumpToolStripMenuItem;
        private Label description;
        private Label label2;
        private ToolStripMenuItem myAnimeListToolStripMenuItem;
        private Button removeButton;
    }
}
