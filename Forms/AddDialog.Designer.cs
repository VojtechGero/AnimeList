namespace AnimeList
{
    partial class AddDialog
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
            IdLabel = new Label();
            idField = new TextBox();
            errorLabel = new Label();
            label1 = new Label();
            searchBox = new TextBox();
            SuspendLayout();
            // 
            // IdLabel
            // 
            IdLabel.AutoSize = true;
            IdLabel.Font = new Font("Segoe UI", 15F);
            IdLabel.Location = new Point(8, 8);
            IdLabel.Margin = new Padding(2, 0, 2, 0);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(76, 28);
            IdLabel.TabIndex = 1;
            IdLabel.Text = "MAL ID";
            // 
            // idField
            // 
            idField.Font = new Font("Segoe UI", 12F);
            idField.Location = new Point(8, 35);
            idField.Margin = new Padding(2);
            idField.Name = "idField";
            idField.Size = new Size(160, 29);
            idField.TabIndex = 2;
            idField.TextChanged += idField_TextChanged;
            idField.KeyPress += idField_KeyPress;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 12F);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(8, 66);
            errorLabel.Margin = new Padding(2, 0, 2, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(45, 21);
            errorLabel.TabIndex = 3;
            errorLabel.Text = "Error";
            errorLabel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(202, 8);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(124, 28);
            label1.TabIndex = 4;
            label1.Text = "Name search";
            // 
            // searchBox
            // 
            searchBox.Font = new Font("Segoe UI", 12F);
            searchBox.Location = new Point(202, 35);
            searchBox.Margin = new Padding(2);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(555, 29);
            searchBox.TabIndex = 5;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // AddDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 368);
            Controls.Add(searchBox);
            Controls.Add(label1);
            Controls.Add(errorLabel);
            Controls.Add(idField);
            Controls.Add(IdLabel);
            Margin = new Padding(2);
            Name = "AddDialog";
            Text = "AnimeAddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label IdLabel;
        private TextBox idField;
        private Label errorLabel;
        private Label label1;
        private TextBox searchBox;
    }
}