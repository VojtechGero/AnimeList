namespace AnimeList
{
    partial class AddForm
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
            saveButton = new Button();
            label = new Label();
            idField = new TextBox();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Dock = DockStyle.Bottom;
            saveButton.Font = new Font("Segoe UI", 15F);
            saveButton.Location = new Point(0, 150);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(481, 68);
            saveButton.TabIndex = 0;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 15F);
            label.Location = new Point(12, 14);
            label.Name = "label";
            label.Size = new Size(115, 41);
            label.TabIndex = 1;
            label.Text = "MAL ID";
            // 
            // idField
            // 
            idField.Font = new Font("Segoe UI", 12F);
            idField.Location = new Point(12, 58);
            idField.Name = "idField";
            idField.Size = new Size(227, 39);
            idField.TabIndex = 2;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 218);
            Controls.Add(idField);
            Controls.Add(label);
            Controls.Add(saveButton);
            Name = "AddForm";
            Text = "AddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private Label label;
        private TextBox idField;
    }
}