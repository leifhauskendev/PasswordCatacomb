namespace PasswordCatacomb
{
    partial class Form1
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
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.passwordNameLabel = new System.Windows.Forms.Label();
            this.passwordStringLabel = new System.Windows.Forms.Label();
            this.passwordNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordStringTextBox = new System.Windows.Forms.TextBox();
            this.autoGenerateLabel = new System.Windows.Forms.Label();
            this.autoGenerateCheckBox = new System.Windows.Forms.CheckBox();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.deleteRadioButton = new System.Windows.Forms.RadioButton();
            this.retrieveRadioButton = new System.Windows.Forms.RadioButton();
            this.updateRadioButton = new System.Windows.Forms.RadioButton();
            this.addRadioButton = new System.Windows.Forms.RadioButton();
            this.enterButton = new System.Windows.Forms.Button();
            this.passwordNameComboBox = new System.Windows.Forms.ComboBox();
            this.optionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleTextBox
            // 
            this.titleTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(0, 0);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ReadOnly = true;
            this.titleTextBox.Size = new System.Drawing.Size(800, 44);
            this.titleTextBox.TabIndex = 0;
            this.titleTextBox.Text = "Password Catacomb";
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // passwordNameLabel
            // 
            this.passwordNameLabel.AutoSize = true;
            this.passwordNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordNameLabel.Location = new System.Drawing.Point(12, 133);
            this.passwordNameLabel.Name = "passwordNameLabel";
            this.passwordNameLabel.Size = new System.Drawing.Size(124, 20);
            this.passwordNameLabel.TabIndex = 1;
            this.passwordNameLabel.Text = "Password Name";
            // 
            // passwordStringLabel
            // 
            this.passwordStringLabel.AutoSize = true;
            this.passwordStringLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordStringLabel.Location = new System.Drawing.Point(12, 177);
            this.passwordStringLabel.Name = "passwordStringLabel";
            this.passwordStringLabel.Size = new System.Drawing.Size(78, 20);
            this.passwordStringLabel.TabIndex = 2;
            this.passwordStringLabel.Text = "Password";
            // 
            // passwordNameTextBox
            // 
            this.passwordNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordNameTextBox.Location = new System.Drawing.Point(143, 132);
            this.passwordNameTextBox.Name = "passwordNameTextBox";
            this.passwordNameTextBox.Size = new System.Drawing.Size(184, 26);
            this.passwordNameTextBox.TabIndex = 3;
            this.passwordNameTextBox.Leave += new System.EventHandler(this.passwordNameTextBox_Leave);
            // 
            // passwordStringTextBox
            // 
            this.passwordStringTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordStringTextBox.Location = new System.Drawing.Point(143, 174);
            this.passwordStringTextBox.Name = "passwordStringTextBox";
            this.passwordStringTextBox.Size = new System.Drawing.Size(184, 26);
            this.passwordStringTextBox.TabIndex = 4;
            this.passwordStringTextBox.Leave += new System.EventHandler(this.passwordStringTextBox_Leave);
            // 
            // autoGenerateLabel
            // 
            this.autoGenerateLabel.AutoSize = true;
            this.autoGenerateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoGenerateLabel.Location = new System.Drawing.Point(140, 203);
            this.autoGenerateLabel.Name = "autoGenerateLabel";
            this.autoGenerateLabel.Size = new System.Drawing.Size(93, 15);
            this.autoGenerateLabel.TabIndex = 5;
            this.autoGenerateLabel.Text = "Auto-Generate?";
            // 
            // autoGenerateCheckBox
            // 
            this.autoGenerateCheckBox.AutoSize = true;
            this.autoGenerateCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoGenerateCheckBox.Location = new System.Drawing.Point(239, 204);
            this.autoGenerateCheckBox.Name = "autoGenerateCheckBox";
            this.autoGenerateCheckBox.Size = new System.Drawing.Size(15, 14);
            this.autoGenerateCheckBox.TabIndex = 6;
            this.autoGenerateCheckBox.UseVisualStyleBackColor = true;
            this.autoGenerateCheckBox.CheckedChanged += new System.EventHandler(this.autoGenerateCheckBox_CheckedChanged);
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.deleteRadioButton);
            this.optionsGroupBox.Controls.Add(this.retrieveRadioButton);
            this.optionsGroupBox.Controls.Add(this.updateRadioButton);
            this.optionsGroupBox.Controls.Add(this.addRadioButton);
            this.optionsGroupBox.Location = new System.Drawing.Point(13, 51);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(722, 46);
            this.optionsGroupBox.TabIndex = 7;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "options";
            // 
            // deleteRadioButton
            // 
            this.deleteRadioButton.AutoSize = true;
            this.deleteRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteRadioButton.Location = new System.Drawing.Point(222, 19);
            this.deleteRadioButton.Name = "deleteRadioButton";
            this.deleteRadioButton.Size = new System.Drawing.Size(65, 20);
            this.deleteRadioButton.TabIndex = 11;
            this.deleteRadioButton.Text = "Delete";
            this.deleteRadioButton.UseVisualStyleBackColor = true;
            this.deleteRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // retrieveRadioButton
            // 
            this.retrieveRadioButton.AutoSize = true;
            this.retrieveRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retrieveRadioButton.Location = new System.Drawing.Point(139, 19);
            this.retrieveRadioButton.Name = "retrieveRadioButton";
            this.retrieveRadioButton.Size = new System.Drawing.Size(76, 20);
            this.retrieveRadioButton.TabIndex = 10;
            this.retrieveRadioButton.Text = "Retrieve";
            this.retrieveRadioButton.UseVisualStyleBackColor = true;
            this.retrieveRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // updateRadioButton
            // 
            this.updateRadioButton.AutoSize = true;
            this.updateRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateRadioButton.Location = new System.Drawing.Point(63, 19);
            this.updateRadioButton.Name = "updateRadioButton";
            this.updateRadioButton.Size = new System.Drawing.Size(70, 20);
            this.updateRadioButton.TabIndex = 9;
            this.updateRadioButton.Text = "Update";
            this.updateRadioButton.UseVisualStyleBackColor = true;
            this.updateRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // addRadioButton
            // 
            this.addRadioButton.AutoSize = true;
            this.addRadioButton.Checked = true;
            this.addRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addRadioButton.Location = new System.Drawing.Point(6, 19);
            this.addRadioButton.Name = "addRadioButton";
            this.addRadioButton.Size = new System.Drawing.Size(50, 20);
            this.addRadioButton.TabIndex = 8;
            this.addRadioButton.TabStop = true;
            this.addRadioButton.Text = "Add";
            this.addRadioButton.UseVisualStyleBackColor = true;
            this.addRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // enterButton
            // 
            this.enterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterButton.Location = new System.Drawing.Point(589, 159);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(146, 41);
            this.enterButton.TabIndex = 8;
            this.enterButton.Text = "Add";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // passwordNameComboBox
            // 
            this.passwordNameComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordNameComboBox.FormattingEnabled = true;
            this.passwordNameComboBox.Location = new System.Drawing.Point(143, 132);
            this.passwordNameComboBox.Name = "passwordNameComboBox";
            this.passwordNameComboBox.Size = new System.Drawing.Size(184, 28);
            this.passwordNameComboBox.TabIndex = 9;
            this.passwordNameComboBox.Visible = false;
            this.passwordNameComboBox.Leave += new System.EventHandler(this.passwordNameComboBox_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.passwordNameComboBox);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.autoGenerateCheckBox);
            this.Controls.Add(this.autoGenerateLabel);
            this.Controls.Add(this.passwordStringTextBox);
            this.Controls.Add(this.passwordNameTextBox);
            this.Controls.Add(this.passwordStringLabel);
            this.Controls.Add(this.passwordNameLabel);
            this.Controls.Add(this.titleTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label passwordNameLabel;
        private System.Windows.Forms.Label passwordStringLabel;
        private System.Windows.Forms.TextBox passwordNameTextBox;
        private System.Windows.Forms.TextBox passwordStringTextBox;
        private System.Windows.Forms.Label autoGenerateLabel;
        private System.Windows.Forms.CheckBox autoGenerateCheckBox;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.RadioButton addRadioButton;
        private System.Windows.Forms.RadioButton deleteRadioButton;
        private System.Windows.Forms.RadioButton retrieveRadioButton;
        private System.Windows.Forms.RadioButton updateRadioButton;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.ComboBox passwordNameComboBox;
    }
}

