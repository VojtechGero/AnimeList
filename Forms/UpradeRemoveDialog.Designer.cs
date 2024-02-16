namespace AnimeList
{
    partial class UpradeRemoveDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            progressBar = new ProgressBar();
            fileNameLabel = new Label();
            CurrentNameLabel = new Label();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(12, 167);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(633, 37);
            progressBar.TabIndex = 0;
            // 
            // fileNameLabel
            // 
            fileNameLabel.Dock = DockStyle.Top;
            fileNameLabel.Font = new Font("Segoe UI", 15F);
            fileNameLabel.Location = new Point(0, 0);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(657, 41);
            fileNameLabel.TabIndex = 1;
            fileNameLabel.Text = "Parsing";
            fileNameLabel.UseMnemonic = false;
            // 
            // CurrentNameLabel
            // 
            CurrentNameLabel.Dock = DockStyle.Top;
            CurrentNameLabel.Font = new Font("Segoe UI", 12F);
            CurrentNameLabel.Location = new Point(0, 41);
            CurrentNameLabel.Margin = new Padding(15, 0, 15, 0);
            CurrentNameLabel.Name = "CurrentNameLabel";
            CurrentNameLabel.Size = new Size(657, 88);
            CurrentNameLabel.TabIndex = 3;
            CurrentNameLabel.Text = "Processing";
            CurrentNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            CurrentNameLabel.UseMnemonic = false;
            // 
            // UpradeRemoveDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 236);
            Controls.Add(CurrentNameLabel);
            Controls.Add(fileNameLabel);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "UpradeRemoveDialog";
            Text = "FileHandleDialog";
            FormClosing += UpradeRemoveDialog_FormClosing;
            Shown += UpradeRemoveDialog_Shown;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
        private Label fileNameLabel;
        private Label CurrentNameLabel;

    }
}