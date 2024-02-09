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
            IdLabel.Location = new Point(12, 14);
            IdLabel.Name = "IdLabel";
            IdLabel.Size = new Size(115, 41);
            IdLabel.TabIndex = 1;
            IdLabel.Text = "MAL ID";
            // 
            // idField
            // 
            idField.Font = new Font("Segoe UI", 12F);
            idField.Location = new Point(12, 58);
            idField.Name = "idField";
            idField.Size = new Size(227, 39);
            idField.TabIndex = 2;
            idField.TextChanged += idField_TextChanged;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 12F);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(12, 110);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(64, 32);
            errorLabel.TabIndex = 3;
            errorLabel.Text = "Error";
            errorLabel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(289, 14);
            label1.Name = "label1";
            label1.Size = new Size(190, 41);
            label1.TabIndex = 4;
            label1.Text = "Name search";
            // 
            // searchBox
            // 
            searchBox.Font = new Font("Segoe UI", 12F);
            searchBox.Location = new Point(289, 58);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(791, 39);
            searchBox.TabIndex = 5;
            searchBox.TextChanged += searchBox_TextChanged;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1092, 506);
            Controls.Add(searchBox);
            Controls.Add(label1);
            Controls.Add(errorLabel);
            Controls.Add(idField);
            Controls.Add(IdLabel);
            Name = "AddForm";
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