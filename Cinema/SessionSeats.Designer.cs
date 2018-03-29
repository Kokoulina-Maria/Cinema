namespace Cinema
{
    partial class SessionSeats
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRow = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSeat = new System.Windows.Forms.NumericUpDown();
            this.btBuy = new System.Windows.Forms.Button();
            this.btBook = new System.Windows.Forms.Button();
            this.btFree = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btChoice = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeat)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(916, 645);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 669);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ряд:";
            // 
            // nudRow
            // 
            this.nudRow.Location = new System.Drawing.Point(70, 667);
            this.nudRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRow.Name = "nudRow";
            this.nudRow.Size = new System.Drawing.Size(66, 22);
            this.nudRow.TabIndex = 2;
            this.nudRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRow.ValueChanged += new System.EventHandler(this.nudRow_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 669);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Место:";
            // 
            // nudSeat
            // 
            this.nudSeat.Location = new System.Drawing.Point(220, 667);
            this.nudSeat.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSeat.Name = "nudSeat";
            this.nudSeat.Size = new System.Drawing.Size(66, 22);
            this.nudSeat.TabIndex = 4;
            this.nudSeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSeat.ValueChanged += new System.EventHandler(this.nudSeat_ValueChanged);
            // 
            // btBuy
            // 
            this.btBuy.Enabled = false;
            this.btBuy.Location = new System.Drawing.Point(506, 667);
            this.btBuy.Name = "btBuy";
            this.btBuy.Size = new System.Drawing.Size(125, 44);
            this.btBuy.TabIndex = 5;
            this.btBuy.Text = "Купить билеты";
            this.btBuy.UseVisualStyleBackColor = true;
            this.btBuy.Click += new System.EventHandler(this.btBuy_Click);
            // 
            // btBook
            // 
            this.btBook.Enabled = false;
            this.btBook.Location = new System.Drawing.Point(655, 667);
            this.btBook.Name = "btBook";
            this.btBook.Size = new System.Drawing.Size(125, 44);
            this.btBook.TabIndex = 6;
            this.btBook.Text = "Забронировать";
            this.btBook.UseVisualStyleBackColor = true;
            this.btBook.Click += new System.EventHandler(this.btBook_Click);
            // 
            // btFree
            // 
            this.btFree.Enabled = false;
            this.btFree.Location = new System.Drawing.Point(799, 667);
            this.btFree.Name = "btFree";
            this.btFree.Size = new System.Drawing.Size(125, 44);
            this.btFree.TabIndex = 7;
            this.btFree.Text = "Отменить";
            this.btFree.UseVisualStyleBackColor = true;
            this.btFree.Click += new System.EventHandler(this.btFree_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 707);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Итого: 0 руб";
            // 
            // btChoice
            // 
            this.btChoice.Location = new System.Drawing.Point(315, 660);
            this.btChoice.Name = "btChoice";
            this.btChoice.Size = new System.Drawing.Size(92, 34);
            this.btChoice.TabIndex = 9;
            this.btChoice.Text = "Выбрать";
            this.btChoice.UseVisualStyleBackColor = true;
            this.btChoice.Click += new System.EventHandler(this.btChoice_Click);
            // 
            // btCancel
            // 
            this.btCancel.Enabled = false;
            this.btCancel.Location = new System.Drawing.Point(315, 698);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(92, 34);
            this.btCancel.TabIndex = 10;
            this.btCancel.Text = "Отменить";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // SessionSeats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(936, 733);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btChoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btFree);
            this.Controls.Add(this.btBook);
            this.Controls.Add(this.btBuy);
            this.Controls.Add(this.nudSeat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudRow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(954, 780);
            this.MinimumSize = new System.Drawing.Size(954, 780);
            this.Name = "SessionSeats";
            this.Text = "Выбор мест";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SessionSeats_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSeat;
        private System.Windows.Forms.Button btBuy;
        private System.Windows.Forms.Button btBook;
        private System.Windows.Forms.Button btFree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btChoice;
        private System.Windows.Forms.Button btCancel;
    }
}