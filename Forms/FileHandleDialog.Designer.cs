namespace AnimeList
{
    partial class FileHandleDialog
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
            button1 = new Button();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Bottom;
            progressBar.Location = new Point(0, 202);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(657, 34);
            progressBar.TabIndex = 0;
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Font = new Font("Segoe UI", 15F);
            fileNameLabel.Location = new Point(51, 14);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(114, 41);
            fileNameLabel.TabIndex = 1;
            fileNameLabel.Text = "Parsing";
            // 
            // button1
            // 
            button1.Location = new Point(281, 75);
            button1.Name = "button1";
            button1.Size = new Size(262, 68);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FileHandleDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 236);
            Controls.Add(button1);
            Controls.Add(fileNameLabel);
            Controls.Add(progressBar);
            Name = "FileHandleDialog";
            Text = "FileHandleDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar;
        private Label fileNameLabel;
        private Button button1;
    }
}