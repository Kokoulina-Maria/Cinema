namespace Cinema
{
    partial class AddFilm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dudAge = new System.Windows.Forms.DomainUpDown();
            this.tbDescrip = new System.Windows.Forms.TextBox();
            this.btFromFile = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.nudHour = new System.Windows.Forms.NumericUpDown();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudYear = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btPoster = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(118, 22);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(220, 22);
            this.tbName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Год:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Режиссер";
            // 
            // tbProd
            // 
            this.tbProd.Location = new System.Drawing.Point(118, 101);
            this.tbProd.Name = "tbProd";
            this.tbProd.Size = new System.Drawing.Size(220, 22);
            this.tbProd.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Возрастное ограничение:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Длительность:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Краткое описание:";
            // 
            // dudAge
            // 
            this.dudAge.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dudAge.Items.Add("0+");
            this.dudAge.Items.Add("6+");
            this.dudAge.Items.Add("12+");
            this.dudAge.Items.Add("16+");
            this.dudAge.Items.Add("18+");
            this.dudAge.Location = new System.Drawing.Point(211, 144);
            this.dudAge.Name = "dudAge";
            this.dudAge.ReadOnly = true;
            this.dudAge.Size = new System.Drawing.Size(127, 22);
            this.dudAge.TabIndex = 9;
            this.dudAge.Text = "0+";
            // 
            // tbDescrip
            // 
            this.tbDescrip.Location = new System.Drawing.Point(12, 292);
            this.tbDescrip.MaximumSize = new System.Drawing.Size(322, 145);
            this.tbDescrip.MinimumSize = new System.Drawing.Size(322, 145);
            this.tbDescrip.Multiline = true;
            this.tbDescrip.Name = "tbDescrip";
            this.tbDescrip.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbDescrip.Size = new System.Drawing.Size(322, 145);
            this.tbDescrip.TabIndex = 11;
            // 
            // btFromFile
            // 
            this.btFromFile.Location = new System.Drawing.Point(340, 292);
            this.btFromFile.Name = "btFromFile";
            this.btFromFile.Size = new System.Drawing.Size(147, 64);
            this.btFromFile.TabIndex = 12;
            this.btFromFile.Text = "Загрузить описание из файла";
            this.btFromFile.UseVisualStyleBackColor = true;
            this.btFromFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(340, 397);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(147, 40);
            this.btAdd.TabIndex = 13;
            this.btAdd.Text = "Добавить фильм";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // nudHour
            // 
            this.nudHour.Location = new System.Drawing.Point(118, 183);
            this.nudHour.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudHour.Name = "nudHour";
            this.nudHour.Size = new System.Drawing.Size(74, 22);
            this.nudHour.TabIndex = 14;
            this.nudHour.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudMin
            // 
            this.nudMin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMin.Location = new System.Drawing.Point(244, 183);
            this.nudMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(74, 22);
            this.nudMin.TabIndex = 15;
            this.nudMin.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "ч";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "мин";
            // 
            // nudYear
            // 
            this.nudYear.Location = new System.Drawing.Point(118, 61);
            this.nudYear.Maximum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.nudYear.Minimum = new decimal(new int[] {
            1960,
            0,
            0,
            0});
            this.nudYear.Name = "nudYear";
            this.nudYear.Size = new System.Drawing.Size(74, 22);
            this.nudYear.TabIndex = 18;
            this.nudYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Постер:";
            // 
            // btPoster
            // 
            this.btPoster.Location = new System.Drawing.Point(118, 214);
            this.btPoster.Name = "btPoster";
            this.btPoster.Size = new System.Drawing.Size(147, 40);
            this.btPoster.TabIndex = 20;
            this.btPoster.Text = "Выберите файл";
            this.btPoster.UseVisualStyleBackColor = true;
            this.btPoster.Click += new System.EventHandler(this.btPoster_Click);
            // 
            // AddFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(496, 449);
            this.Controls.Add(this.btPoster);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudYear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudMin);
            this.Controls.Add(this.nudHour);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btFromFile);
            this.Controls.Add(this.tbDescrip);
            this.Controls.Add(this.dudAge);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbProd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(514, 496);
            this.MinimumSize = new System.Drawing.Size(514, 496);
            this.Name = "AddFilm";
            this.Text = "Добавление фильма";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddFilm_FormClosing);
            this.Load += new System.EventHandler(this.AddFilm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbProd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DomainUpDown dudAge;
        private System.Windows.Forms.TextBox tbDescrip;
        private System.Windows.Forms.Button btFromFile;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.NumericUpDown nudHour;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btPoster;
    }
}