namespace Cinema
{
    partial class AddSession
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbHall = new System.Windows.Forms.ComboBox();
            this.cbCinema = new System.Windows.Forms.ComboBox();
            this.cbFilm = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.nudHour = new System.Windows.Forms.NumericUpDown();
            this.btnFromExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).BeginInit();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(362, 188);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(130, 43);
            this.btAdd.TabIndex = 63;
            this.btAdd.Text = "Добавить сеанс";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "Кинотеатр:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 61;
            this.label2.Text = "Зал:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 62;
            this.label3.Text = "Фильм:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 64;
            this.label4.Text = "Стоимость:";
            // 
            // nudPrice
            // 
            this.nudPrice.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPrice.Location = new System.Drawing.Point(117, 138);
            this.nudPrice.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(77, 22);
            this.nudPrice.TabIndex = 68;
            this.nudPrice.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 69;
            this.label5.Text = "Дата:";
            // 
            // cbHall
            // 
            this.cbHall.FormattingEnabled = true;
            this.cbHall.Location = new System.Drawing.Point(117, 58);
            this.cbHall.Name = "cbHall";
            this.cbHall.Size = new System.Drawing.Size(220, 24);
            this.cbHall.TabIndex = 70;
            this.cbHall.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbHall_KeyPress);
            // 
            // cbCinema
            // 
            this.cbCinema.FormattingEnabled = true;
            this.cbCinema.Location = new System.Drawing.Point(117, 20);
            this.cbCinema.Name = "cbCinema";
            this.cbCinema.Size = new System.Drawing.Size(220, 24);
            this.cbCinema.TabIndex = 71;
            this.cbCinema.SelectedValueChanged += new System.EventHandler(this.cbCinema_SelectedValueChanged);
            this.cbCinema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCinema_KeyPress);
            // 
            // cbFilm
            // 
            this.cbFilm.FormattingEnabled = true;
            this.cbFilm.Location = new System.Drawing.Point(117, 99);
            this.cbFilm.Name = "cbFilm";
            this.cbFilm.Size = new System.Drawing.Size(220, 24);
            this.cbFilm.TabIndex = 72;
            this.cbFilm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFilm_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 17);
            this.label7.TabIndex = 74;
            this.label7.Text = "руб";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(117, 171);
            this.dtpDate.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(2018, 3, 18, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 75;
            this.dtpDate.Value = new System.DateTime(2018, 3, 31, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 76;
            this.label6.Text = "Время:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(323, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 17);
            this.label8.TabIndex = 81;
            this.label8.Text = "мин";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 17);
            this.label9.TabIndex = 80;
            this.label9.Text = "ч";
            // 
            // nudMin
            // 
            this.nudMin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudMin.Location = new System.Drawing.Point(243, 209);
            this.nudMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(74, 22);
            this.nudMin.TabIndex = 79;
            // 
            // nudHour
            // 
            this.nudHour.Location = new System.Drawing.Point(117, 209);
            this.nudHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.nudHour.Name = "nudHour";
            this.nudHour.Size = new System.Drawing.Size(74, 22);
            this.nudHour.TabIndex = 78;
            this.nudHour.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // btnFromExcel
            // 
            this.btnFromExcel.Location = new System.Drawing.Point(362, 12);
            this.btnFromExcel.Name = "btnFromExcel";
            this.btnFromExcel.Size = new System.Drawing.Size(130, 43);
            this.btnFromExcel.TabIndex = 82;
            this.btnFromExcel.Text = "Загрузить сеансы из Excel";
            this.btnFromExcel.UseVisualStyleBackColor = true;
            this.btnFromExcel.Click += new System.EventHandler(this.btnFromExcel_Click);
            // 
            // AddSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(496, 242);
            this.Controls.Add(this.btnFromExcel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudMin);
            this.Controls.Add(this.nudHour);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbFilm);
            this.Controls.Add(this.cbCinema);
            this.Controls.Add(this.cbHall);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(514, 261);
            this.Name = "AddSession";
            this.Text = "Добавление Сеанса";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSession_FormClosing);
            this.Load += new System.EventHandler(this.AddSession_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbHall;
        private System.Windows.Forms.ComboBox cbCinema;
        private System.Windows.Forms.ComboBox cbFilm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.NumericUpDown nudHour;
        private System.Windows.Forms.Button btnFromExcel;
    }
}