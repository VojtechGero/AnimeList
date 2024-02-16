namespace AnimeList
{
    partial class UpdateDialog
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
            ContentNameLabel = new Label();
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
            // ContentNameLabel
            // 
            ContentNameLabel.Dock = DockStyle.Top;
            ContentNameLabel.Font = new Font("Segoe UI", 12F);
            ContentNameLabel.Location = new Point(0, 0);
            ContentNameLabel.Name = "ContentNameLabel";
            ContentNameLabel.Size = new Size(657, 146);
            ContentNameLabel.TabIndex = 1;
            ContentNameLabel.Text = "Parsing";
            ContentNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            ContentNameLabel.UseMnemonic = false;
            // 
            // UpdateDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 236);
            Controls.Add(ContentNameLabel);
            Controls.Add(progressBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "UpdateDialog";
            Text = "FileHandleDialog";
            FormClosing += UpradeRemoveDialog_FormClosing;
            Shown += UpdateDialog_Shown;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
        private Label ContentNameLabel;

    }
}