namespace Cinema
{
    partial class AddCinema
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
            this.btAdd = new System.Windows.Forms.Button();
            this.tbCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAdress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(354, 75);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(130, 43);
            this.btAdd.TabIndex = 30;
            this.btAdd.Text = "Добавить кинотеатр";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbCity
            // 
            this.tbCity.Location = new System.Drawing.Point(114, 55);
            this.tbCity.Name = "tbCity";
            this.tbCity.Size = new System.Drawing.Size(220, 22);
            this.tbCity.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Адрес:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Город:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(114, 17);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(220, 22);
            this.tbName.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Название:";
            // 
            // tbAdress
            // 
            this.tbAdress.Location = new System.Drawing.Point(114, 96);
            this.tbAdress.Name = "tbAdress";
            this.tbAdress.Size = new System.Drawing.Size(220, 22);
            this.tbAdress.TabIndex = 35;
            // 
            // AddCinema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(496, 140);
            this.Controls.Add(this.tbAdress);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.tbCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(514, 187);
            this.MinimumSize = new System.Drawing.Size(514, 187);
            this.Name = "AddCinema";
            this.Text = "Добавление Кинотеатра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCinema_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAdress;
    }
}