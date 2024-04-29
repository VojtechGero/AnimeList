namespace AnimeList.Forms
{
    partial class StatsDialog
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
            StatsLabel = new Label();
            SuspendLayout();
            // 
            // StatsLabel
            // 
            StatsLabel.AutoSize = true;
            StatsLabel.Font = new Font("Segoe UI", 15F);
            StatsLabel.Location = new Point(12, 9);
            StatsLabel.Name = "StatsLabel";
            StatsLabel.Size = new Size(97, 41);
            StatsLabel.TabIndex = 0;
            StatsLabel.Text = "label1";
            // 
            // StatsDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StatsLabel);
            Name = "StatsDialog";
            Text = "Stats";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label StatsLabel;
    }
}