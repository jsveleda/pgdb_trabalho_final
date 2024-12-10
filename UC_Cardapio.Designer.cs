namespace Calendário_do_RU
{
    partial class UC_Cardapio
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxBreakfast = new System.Windows.Forms.ListBox();
            this.listBoxLunch = new System.Windows.Forms.ListBox();
            this.listBoxDinner = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxBreakfast
            // 
            this.listBoxBreakfast.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxBreakfast.FormattingEnabled = true;
            this.listBoxBreakfast.ItemHeight = 20;
            this.listBoxBreakfast.Location = new System.Drawing.Point(25, 21);
            this.listBoxBreakfast.Name = "listBoxBreakfast";
            this.listBoxBreakfast.Size = new System.Drawing.Size(350, 104);
            this.listBoxBreakfast.TabIndex = 0;
            // 
            // listBoxLunch
            // 
            this.listBoxLunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxLunch.FormattingEnabled = true;
            this.listBoxLunch.ItemHeight = 20;
            this.listBoxLunch.Location = new System.Drawing.Point(25, 131);
            this.listBoxLunch.Name = "listBoxLunch";
            this.listBoxLunch.Size = new System.Drawing.Size(350, 104);
            this.listBoxLunch.TabIndex = 1;
            // 
            // listBoxDinner
            // 
            this.listBoxDinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDinner.FormattingEnabled = true;
            this.listBoxDinner.ItemHeight = 20;
            this.listBoxDinner.Location = new System.Drawing.Point(25, 241);
            this.listBoxDinner.Name = "listBoxDinner";
            this.listBoxDinner.Size = new System.Drawing.Size(350, 104);
            this.listBoxDinner.TabIndex = 2;
            // 
            // UC_Cardapio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxDinner);
            this.Controls.Add(this.listBoxLunch);
            this.Controls.Add(this.listBoxBreakfast);
            this.Name = "UC_Cardapio";
            this.Size = new System.Drawing.Size(400, 366);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxBreakfast;
        private System.Windows.Forms.ListBox listBoxLunch;
        private System.Windows.Forms.ListBox listBoxDinner;
    }
}
