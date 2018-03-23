namespace Cinema
{
    partial class AddHall
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
            this.label4 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudNumber = new System.Windows.Forms.NumericUpDown();
            this.dudType = new System.Windows.Forms.DomainUpDown();
            this.nudRows = new System.Windows.Forms.NumericUpDown();
            this.nudSeats = new System.Windows.Forms.NumericUpDown();
            this.cbCinema = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 17);
            this.label4.TabIndex = 52;
            this.label4.Text = "Количество мест в ряду:";
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(354, 154);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(130, 43);
            this.btAdd.TabIndex = 50;
            this.btAdd.Text = "Добавить зал";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "Количество рядов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Тип:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "№";
            // 
            // nudNumber
            // 
            this.nudNumber.Location = new System.Drawing.Point(116, 24);
            this.nudNumber.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumber.Name = "nudNumber";
            this.nudNumber.Size = new System.Drawing.Size(68, 22);
            this.nudNumber.TabIndex = 54;
            this.nudNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dudType
            // 
            this.dudType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dudType.Items.Add("2D");
            this.dudType.Items.Add("3D");
            this.dudType.Items.Add("4D");
            this.dudType.Items.Add("IMAX");
            this.dudType.Items.Add("VIP");
            this.dudType.Location = new System.Drawing.Point(116, 62);
            this.dudType.Name = "dudType";
            this.dudType.ReadOnly = true;
            this.dudType.Size = new System.Drawing.Size(150, 22);
            this.dudType.TabIndex = 55;
            // 
            // nudRows
            // 
            this.nudRows.Location = new System.Drawing.Point(175, 105);
            this.nudRows.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRows.Name = "nudRows";
            this.nudRows.Size = new System.Drawing.Size(91, 22);
            this.nudRows.TabIndex = 56;
            this.nudRows.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nudSeats
            // 
            this.nudSeats.Location = new System.Drawing.Point(189, 141);
            this.nudSeats.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudSeats.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudSeats.Name = "nudSeats";
            this.nudSeats.Size = new System.Drawing.Size(77, 22);
            this.nudSeats.TabIndex = 57;
            this.nudSeats.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbCinema
            // 
            this.cbCinema.FormattingEnabled = true;
            this.cbCinema.Location = new System.Drawing.Point(116, 173);
            this.cbCinema.Name = "cbCinema";
            this.cbCinema.Size = new System.Drawing.Size(220, 24);
            this.cbCinema.TabIndex = 59;
            this.cbCinema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCinema_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 58;
            this.label5.Text = "Кинотеатр:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 61;
            // 
            // AddHall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(496, 214);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCinema);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudSeats);
            this.Controls.Add(this.nudRows);
            this.Controls.Add(this.dudType);
            this.Controls.Add(this.nudNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(514, 261);
            this.MinimumSize = new System.Drawing.Size(514, 261);
            this.Name = "AddHall";
            this.Text = "Добавление зала";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddHall_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudNumber;
        private System.Windows.Forms.DomainUpDown dudType;
        private System.Windows.Forms.NumericUpDown nudRows;
        private System.Windows.Forms.NumericUpDown nudSeats;
        private System.Windows.Forms.ComboBox cbCinema;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}