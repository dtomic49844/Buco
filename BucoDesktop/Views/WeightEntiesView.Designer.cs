namespace BucoDesktop.Views
{
    partial class WeightEntiesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeightEntiesView));
            this.WeightEntryLabel = new System.Windows.Forms.Label();
            this.MesuredWeightLabel = new System.Windows.Forms.Label();
            this.WeightTextBox = new System.Windows.Forms.TextBox();
            this.PetLabel = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.PetTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WeightEntryLabel
            // 
            this.WeightEntryLabel.AutoSize = true;
            this.WeightEntryLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.WeightEntryLabel.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WeightEntryLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.WeightEntryLabel.Location = new System.Drawing.Point(101, 27);
            this.WeightEntryLabel.Name = "WeightEntryLabel";
            this.WeightEntryLabel.Size = new System.Drawing.Size(143, 25);
            this.WeightEntryLabel.TabIndex = 0;
            this.WeightEntryLabel.Text = "Weight entries";
            // 
            // MesuredWeightLabel
            // 
            this.MesuredWeightLabel.AutoSize = true;
            this.MesuredWeightLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MesuredWeightLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MesuredWeightLabel.Location = new System.Drawing.Point(101, 73);
            this.MesuredWeightLabel.Name = "MesuredWeightLabel";
            this.MesuredWeightLabel.Size = new System.Drawing.Size(143, 25);
            this.MesuredWeightLabel.TabIndex = 1;
            this.MesuredWeightLabel.Text = "Mesured weight:";
            // 
            // WeightTextBox
            // 
            this.WeightTextBox.Location = new System.Drawing.Point(262, 71);
            this.WeightTextBox.Name = "WeightTextBox";
            this.WeightTextBox.Size = new System.Drawing.Size(205, 27);
            this.WeightTextBox.TabIndex = 2;
            // 
            // PetLabel
            // 
            this.PetLabel.AutoSize = true;
            this.PetLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PetLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PetLabel.Location = new System.Drawing.Point(101, 111);
            this.PetLabel.Name = "PetLabel";
            this.PetLabel.Size = new System.Drawing.Size(40, 25);
            this.PetLabel.TabIndex = 3;
            this.PetLabel.Text = "Pet:";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(101, 152);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(94, 29);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Location = new System.Drawing.Point(240, 152);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(94, 29);
            this.UpdateButton.TabIndex = 6;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(373, 152);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(94, 29);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Location = new System.Drawing.Point(710, 152);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(94, 29);
            this.PreviousButton.TabIndex = 8;
            this.PreviousButton.Text = "<<";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(826, 152);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(94, 29);
            this.NextButton.TabIndex = 9;
            this.NextButton.Text = ">>";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.AllowUserToResizeColumns = false;
            this.DataGrid.AllowUserToResizeRows = false;
            this.DataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DataGrid.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DataGrid.Location = new System.Drawing.Point(101, 200);
            this.DataGrid.MultiSelect = false;
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowHeadersWidth = 51;
            this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid.Size = new System.Drawing.Size(240, 150);
            this.DataGrid.TabIndex = 0;
            // 
            // PetTextBox
            // 
            this.PetTextBox.Location = new System.Drawing.Point(262, 111);
            this.PetTextBox.Name = "PetTextBox";
            this.PetTextBox.Size = new System.Drawing.Size(205, 27);
            this.PetTextBox.TabIndex = 10;
            this.PetTextBox.TextChanged += new System.EventHandler(this.PetTextBox_TextChanged);
            // 
            // WeightEntiesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1195, 802);
            this.Controls.Add(this.PetTextBox);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.PetLabel);
            this.Controls.Add(this.WeightTextBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.MesuredWeightLabel);
            this.Controls.Add(this.WeightEntryLabel);
            this.Controls.Add(this.DataGrid);
            this.Name = "WeightEntiesView";
            this.Text = "Weight Entries - Chubster Desktop";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WeightEntryLabel;
        private System.Windows.Forms.Label MesuredWeightLabel;
        private System.Windows.Forms.TextBox WeightTextBox;
        private System.Windows.Forms.Label PetLabel;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.TextBox PetTextBox;
    }
}