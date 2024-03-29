﻿namespace BucoDesktop.Views
{
    partial class MealEntriesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MealEntriesView));
            this.MealEntriesLabel = new System.Windows.Forms.Label();
            this.CaloriesLabel = new System.Windows.Forms.Label();
            this.CalorieTextBox = new System.Windows.Forms.TextBox();
            this.PetLabel = new System.Windows.Forms.Label();
            this.PetTextBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MealEntriesLabel
            // 
            this.MealEntriesLabel.AutoSize = true;
            this.MealEntriesLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.MealEntriesLabel.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MealEntriesLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.MealEntriesLabel.Location = new System.Drawing.Point(101, 27);
            this.MealEntriesLabel.Name = "MealEntriesLabel";
            this.MealEntriesLabel.Size = new System.Drawing.Size(122, 25);
            this.MealEntriesLabel.TabIndex = 0;
            this.MealEntriesLabel.Text = "Meal entries";
            // 
            // CaloriesLabel
            // 
            this.CaloriesLabel.AccessibleRole = System.Windows.Forms.AccessibleRole.Dial;
            this.CaloriesLabel.AutoEllipsis = true;
            this.CaloriesLabel.AutoSize = true;
            this.CaloriesLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CaloriesLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CaloriesLabel.Location = new System.Drawing.Point(101, 73);
            this.CaloriesLabel.Name = "CaloriesLabel";
            this.CaloriesLabel.Size = new System.Drawing.Size(78, 25);
            this.CaloriesLabel.TabIndex = 1;
            this.CaloriesLabel.Text = "Calories:";
            // 
            // CalorieTextBox
            // 
            this.CalorieTextBox.Location = new System.Drawing.Point(216, 71);
            this.CalorieTextBox.Name = "CalorieTextBox";
            this.CalorieTextBox.Size = new System.Drawing.Size(205, 27);
            this.CalorieTextBox.TabIndex = 2;
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
            // PetTextBox
            // 
            this.PetTextBox.Location = new System.Drawing.Point(216, 111);
            this.PetTextBox.Name = "PetTextBox";
            this.PetTextBox.Size = new System.Drawing.Size(205, 27);
            this.PetTextBox.TabIndex = 4;
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
            this.UpdateButton.Location = new System.Drawing.Point(216, 152);
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
            this.DeleteButton.Location = new System.Drawing.Point(327, 152);
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
            // MealEntriesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1195, 802);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.PetTextBox);
            this.Controls.Add(this.CalorieTextBox);
            this.Controls.Add(this.PetLabel);
            this.Controls.Add(this.CaloriesLabel);
            this.Controls.Add(this.MealEntriesLabel);
            this.Controls.Add(this.DataGrid);
            this.Name = "MealEntriesView";
            this.Text = "Meal Entries - Chubster Desktop";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MealEntriesLabel;
        private System.Windows.Forms.Label CaloriesLabel;
        private System.Windows.Forms.TextBox CalorieTextBox;
        private System.Windows.Forms.Label PetLabel;
        private System.Windows.Forms.TextBox PetTextBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.DataGridView DataGrid;
    }
}