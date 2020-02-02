namespace BucoDesktop
{
    partial class HomeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PetsLabel = new System.Windows.Forms.LinkLabel();
            this.PetTypesLabel = new System.Windows.Forms.LinkLabel();
            this.activityEntriesLabel = new System.Windows.Forms.LinkLabel();
            this.ActivityTypesLabel = new System.Windows.Forms.LinkLabel();
            this.mealEntriesLabel = new System.Windows.Forms.LinkLabel();
            this.weightEntriesLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Heiti Std R", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(160, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(873, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Chubster Desktop!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe Heiti Std R", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(36, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1081, 125);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // PetsLabel
            // 
            this.PetsLabel.AutoSize = true;
            this.PetsLabel.Font = new System.Drawing.Font("Adobe Heiti Std R", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PetsLabel.LinkColor = System.Drawing.Color.MediumOrchid;
            this.PetsLabel.Location = new System.Drawing.Point(350, 385);
            this.PetsLabel.Name = "PetsLabel";
            this.PetsLabel.Size = new System.Drawing.Size(56, 29);
            this.PetsLabel.TabIndex = 2;
            this.PetsLabel.TabStop = true;
            this.PetsLabel.Text = "Pets";
            this.PetsLabel.VisitedLinkColor = System.Drawing.Color.DarkViolet;
            this.PetsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // PetTypesLabel
            // 
            this.PetTypesLabel.AutoSize = true;
            this.PetTypesLabel.Font = new System.Drawing.Font("Adobe Heiti Std R", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PetTypesLabel.LinkColor = System.Drawing.Color.MediumOrchid;
            this.PetTypesLabel.Location = new System.Drawing.Point(350, 431);
            this.PetTypesLabel.Name = "PetTypesLabel";
            this.PetTypesLabel.Size = new System.Drawing.Size(107, 29);
            this.PetTypesLabel.TabIndex = 3;
            this.PetTypesLabel.TabStop = true;
            this.PetTypesLabel.Text = "Pet types";
            this.PetTypesLabel.VisitedLinkColor = System.Drawing.Color.DarkViolet;
            this.PetTypesLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.PetTypesLabel_LinkClicked);
            // 
            // activityEntriesLabel
            // 
            this.activityEntriesLabel.AutoSize = true;
            this.activityEntriesLabel.Font = new System.Drawing.Font("Adobe Heiti Std R", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.activityEntriesLabel.LinkColor = System.Drawing.Color.MediumOrchid;
            this.activityEntriesLabel.Location = new System.Drawing.Point(670, 385);
            this.activityEntriesLabel.Name = "activityEntriesLabel";
            this.activityEntriesLabel.Size = new System.Drawing.Size(166, 29);
            this.activityEntriesLabel.TabIndex = 4;
            this.activityEntriesLabel.TabStop = true;
            this.activityEntriesLabel.Text = "Activity entries";
            this.activityEntriesLabel.VisitedLinkColor = System.Drawing.Color.DarkViolet;
            this.activityEntriesLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.activityEntriesLabel_LinkClicked);
            // 
            // ActivityTypesLabel
            // 
            this.ActivityTypesLabel.AutoSize = true;
            this.ActivityTypesLabel.Font = new System.Drawing.Font("Adobe Heiti Std R", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ActivityTypesLabel.LinkColor = System.Drawing.Color.MediumOrchid;
            this.ActivityTypesLabel.Location = new System.Drawing.Point(350, 477);
            this.ActivityTypesLabel.Name = "ActivityTypesLabel";
            this.ActivityTypesLabel.Size = new System.Drawing.Size(152, 29);
            this.ActivityTypesLabel.TabIndex = 5;
            this.ActivityTypesLabel.TabStop = true;
            this.ActivityTypesLabel.Text = "Activity types";
            this.ActivityTypesLabel.VisitedLinkColor = System.Drawing.Color.DarkViolet;
            this.ActivityTypesLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ActivityTypesLink_LinkClicked);
            // 
            // mealEntriesLabel
            // 
            this.mealEntriesLabel.AutoSize = true;
            this.mealEntriesLabel.Font = new System.Drawing.Font("Adobe Fan Heiti Std B", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mealEntriesLabel.LinkColor = System.Drawing.Color.MediumOrchid;
            this.mealEntriesLabel.Location = new System.Drawing.Point(670, 477);
            this.mealEntriesLabel.Name = "mealEntriesLabel";
            this.mealEntriesLabel.Size = new System.Drawing.Size(122, 25);
            this.mealEntriesLabel.TabIndex = 6;
            this.mealEntriesLabel.TabStop = true;
            this.mealEntriesLabel.Text = "Meal entries";
            this.mealEntriesLabel.VisitedLinkColor = System.Drawing.Color.DarkViolet;
            this.mealEntriesLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel5_LinkClicked);
            // 
            // weightEntriesLabel
            // 
            this.weightEntriesLabel.AutoSize = true;
            this.weightEntriesLabel.Font = new System.Drawing.Font("Adobe Heiti Std R", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.weightEntriesLabel.LinkColor = System.Drawing.Color.MediumOrchid;
            this.weightEntriesLabel.Location = new System.Drawing.Point(670, 431);
            this.weightEntriesLabel.Name = "weightEntriesLabel";
            this.weightEntriesLabel.Size = new System.Drawing.Size(163, 29);
            this.weightEntriesLabel.TabIndex = 7;
            this.weightEntriesLabel.TabStop = true;
            this.weightEntriesLabel.Text = "Weight entries";
            this.weightEntriesLabel.VisitedLinkColor = System.Drawing.Color.DarkViolet;
            this.weightEntriesLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel6_LinkClicked);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1195, 802);
            this.Controls.Add(this.activityEntriesLabel);
            this.Controls.Add(this.weightEntriesLabel);
            this.Controls.Add(this.mealEntriesLabel);
            this.Controls.Add(this.ActivityTypesLabel);
            this.Controls.Add(this.PetTypesLabel);
            this.Controls.Add(this.PetsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HomeForm";
            this.Text = "Home  - Chubster Desktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel PetsLabel;
        private System.Windows.Forms.LinkLabel PetTypesLabel;
        private System.Windows.Forms.LinkLabel activityEntriesLabel;
        private System.Windows.Forms.LinkLabel activityTypesLabel;
        private System.Windows.Forms.LinkLabel mealEntriesLabel;
        private System.Windows.Forms.LinkLabel weightEntriesLabel;
        private System.Windows.Forms.LinkLabel ActivityTypesLabel;
    }
}

