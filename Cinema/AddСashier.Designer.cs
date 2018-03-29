namespace Cinema
{
    partial class AddСashier
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
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCinema = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(116, 102);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(220, 22);
            this.tbPassword.TabIndex = 42;
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(354, 119);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(130, 43);
            this.btAdd.TabIndex = 41;
            this.btAdd.Text = "Добавить кассира";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(116, 61);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(220, 22);
            this.tbLogin.TabIndex = 40;
            this.tbLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLogin_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 39;
            this.label3.Text = "Пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Login:";
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(116, 23);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.Size = new System.Drawing.Size(220, 22);
            this.tbFIO.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 36;
            this.label1.Text = "ФИО:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Кинотеатр:";
            // 
            // cbCinema
            // 
            this.cbCinema.FormattingEnabled = true;
            this.cbCinema.Location = new System.Drawing.Point(116, 138);
            this.cbCinema.Name = "cbCinema";
            this.cbCinema.Size = new System.Drawing.Size(220, 24);
            this.cbCinema.TabIndex = 44;
            this.cbCinema.SelectedIndexChanged += new System.EventHandler(this.cbCinema_SelectedIndexChanged);
            this.cbCinema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCinema_KeyPress);
            // 
            // AddСashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(496, 179);
            this.Controls.Add(this.cbCinema);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(514, 226);
            this.MinimumSize = new System.Drawing.Size(514, 226);
            this.Name = "AddСashier";
            this.Text = "Добавление Кассира";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddСashier_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCinema;
    }
}