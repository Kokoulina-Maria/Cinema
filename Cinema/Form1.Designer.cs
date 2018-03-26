namespace Cinema
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btEntry = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEnt = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAtr = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbNewEnt = new System.Windows.Forms.ComboBox();
            this.btFind = new System.Windows.Forms.Button();
            this.btExtra = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btEnt = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btChange = new System.Windows.Forms.Button();
            this.btExel = new System.Windows.Forms.Button();
            this.btSession = new System.Windows.Forms.Button();
            this.cbSign = new System.Windows.Forms.ComboBox();
            this.tbEqv = new System.Windows.Forms.TextBox();
            this.btExit = new System.Windows.Forms.Button();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.cbEqv = new System.Windows.Forms.ComboBox();
            this.btNewSearch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(478, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль:";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(569, 9);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(163, 22);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.WordWrap = false;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(569, 42);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(163, 22);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.WordWrap = false;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPassword_KeyPress);
            // 
            // btEntry
            // 
            this.btEntry.Location = new System.Drawing.Point(757, 42);
            this.btEntry.Name = "btEntry";
            this.btEntry.Size = new System.Drawing.Size(75, 23);
            this.btEntry.TabIndex = 4;
            this.btEntry.Text = "Зайти";
            this.btEntry.UseVisualStyleBackColor = true;
            this.btEntry.Click += new System.EventHandler(this.btEntry_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Искомая сущность:";
            // 
            // cbSearch
            // 
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "Фильм",
            "Кинотеатр",
            "Зал",
            "Сеанс"});
            this.cbSearch.Location = new System.Drawing.Point(166, 95);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(177, 24);
            this.cbSearch.TabIndex = 6;
            this.cbSearch.Text = "Фильм";
            this.cbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSearch_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Сущность-параметр:";
            // 
            // cbEnt
            // 
            this.cbEnt.FormattingEnabled = true;
            this.cbEnt.Location = new System.Drawing.Point(166, 144);
            this.cbEnt.Name = "cbEnt";
            this.cbEnt.Size = new System.Drawing.Size(177, 24);
            this.cbEnt.TabIndex = 8;
            this.cbEnt.ValueMemberChanged += new System.EventHandler(this.cbEnt_ValueMemberChanged);
            this.cbEnt.TextChanged += new System.EventHandler(this.cbEnt_TextChanged);
            this.cbEnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEnt_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(377, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Атрибут:";
            // 
            // cbAtr
            // 
            this.cbAtr.FormattingEnabled = true;
            this.cbAtr.Location = new System.Drawing.Point(449, 144);
            this.cbAtr.Name = "cbAtr";
            this.cbAtr.Size = new System.Drawing.Size(153, 24);
            this.cbAtr.TabIndex = 10;
            this.cbAtr.TextChanged += new System.EventHandler(this.cbAtr_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Еще параметр:";
            // 
            // cbNewEnt
            // 
            this.cbNewEnt.FormattingEnabled = true;
            this.cbNewEnt.Items.AddRange(new object[] {
            "И",
            "ИЛИ"});
            this.cbNewEnt.Location = new System.Drawing.Point(166, 190);
            this.cbNewEnt.Name = "cbNewEnt";
            this.cbNewEnt.Size = new System.Drawing.Size(76, 24);
            this.cbNewEnt.TabIndex = 12;
            this.cbNewEnt.Text = "И";
            this.cbNewEnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbNewEnt_KeyPress);
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(792, 190);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(87, 23);
            this.btFind.TabIndex = 13;
            this.btFind.Text = "Найти";
            this.btFind.UseVisualStyleBackColor = true;
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // btExtra
            // 
            this.btExtra.Location = new System.Drawing.Point(301, 190);
            this.btExtra.Name = "btExtra";
            this.btExtra.Size = new System.Drawing.Size(75, 23);
            this.btExtra.TabIndex = 14;
            this.btExtra.Text = "OK";
            this.btExtra.UseVisualStyleBackColor = true;
            this.btExtra.Click += new System.EventHandler(this.btExtra_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(18, 253);
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowTemplate.Height = 24;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(520, 466);
            this.dgvList.TabIndex = 15;
            this.dgvList.Click += new System.EventHandler(this.dgvList_Click);
            // 
            // btEnt
            // 
            this.btEnt.Location = new System.Drawing.Point(380, 95);
            this.btEnt.Name = "btEnt";
            this.btEnt.Size = new System.Drawing.Size(124, 23);
            this.btEnt.TabIndex = 17;
            this.btEnt.Text = "Новый запрос";
            this.btEnt.UseVisualStyleBackColor = true;
            this.btEnt.Click += new System.EventHandler(this.btEnt_Click);
            // 
            // btAdd
            // 
            this.btAdd.Enabled = false;
            this.btAdd.Location = new System.Drawing.Point(674, 289);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(128, 44);
            this.btAdd.TabIndex = 18;
            this.btAdd.Text = "Добавить";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Visible = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btDelete
            // 
            this.btDelete.Enabled = false;
            this.btDelete.Location = new System.Drawing.Point(674, 371);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(128, 44);
            this.btDelete.TabIndex = 19;
            this.btDelete.Text = "Удалить";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Visible = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btChange
            // 
            this.btChange.Enabled = false;
            this.btChange.Location = new System.Drawing.Point(674, 452);
            this.btChange.Name = "btChange";
            this.btChange.Size = new System.Drawing.Size(128, 44);
            this.btChange.TabIndex = 20;
            this.btChange.Text = "Редактировать";
            this.btChange.UseVisualStyleBackColor = true;
            this.btChange.Visible = false;
            this.btChange.Click += new System.EventHandler(this.btChange_Click);
            // 
            // btExel
            // 
            this.btExel.Enabled = false;
            this.btExel.Location = new System.Drawing.Point(674, 534);
            this.btExel.Name = "btExel";
            this.btExel.Size = new System.Drawing.Size(128, 44);
            this.btExel.TabIndex = 21;
            this.btExel.Text = "Выгрузить отчет";
            this.btExel.UseVisualStyleBackColor = true;
            this.btExel.Visible = false;
            this.btExel.Click += new System.EventHandler(this.btExel_Click);
            // 
            // btSession
            // 
            this.btSession.Enabled = false;
            this.btSession.Location = new System.Drawing.Point(792, 675);
            this.btSession.Name = "btSession";
            this.btSession.Size = new System.Drawing.Size(120, 44);
            this.btSession.TabIndex = 22;
            this.btSession.Text = "Занять места";
            this.btSession.UseVisualStyleBackColor = true;
            this.btSession.Visible = false;
            this.btSession.Click += new System.EventHandler(this.btSession_Click);
            // 
            // cbSign
            // 
            this.cbSign.FormattingEnabled = true;
            this.cbSign.Items.AddRange(new object[] {
            "=",
            "!="});
            this.cbSign.Location = new System.Drawing.Point(645, 144);
            this.cbSign.Name = "cbSign";
            this.cbSign.Size = new System.Drawing.Size(58, 24);
            this.cbSign.TabIndex = 23;
            this.cbSign.Text = "=";
            this.cbSign.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSign_KeyPress);
            // 
            // tbEqv
            // 
            this.tbEqv.Location = new System.Drawing.Point(746, 144);
            this.tbEqv.Name = "tbEqv";
            this.tbEqv.Size = new System.Drawing.Size(178, 22);
            this.tbEqv.TabIndex = 24;
            this.tbEqv.Text = "Введите значение...";
            this.tbEqv.Visible = false;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(838, 42);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 25;
            this.btExit.Text = "Выйти";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // pbPoster
            // 
            this.pbPoster.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbPoster.ErrorImage")));
            this.pbPoster.Location = new System.Drawing.Point(660, 253);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(158, 243);
            this.pbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPoster.TabIndex = 26;
            this.pbPoster.TabStop = false;
            // 
            // tbInfo
            // 
            this.tbInfo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbInfo.Location = new System.Drawing.Point(569, 505);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(343, 214);
            this.tbInfo.TabIndex = 27;
            this.tbInfo.Visible = false;
            // 
            // cbEqv
            // 
            this.cbEqv.FormattingEnabled = true;
            this.cbEqv.Location = new System.Drawing.Point(746, 144);
            this.cbEqv.Name = "cbEqv";
            this.cbEqv.Size = new System.Drawing.Size(166, 24);
            this.cbEqv.TabIndex = 28;
            this.cbEqv.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbEqv_KeyPress);
            // 
            // btNewSearch
            // 
            this.btNewSearch.Location = new System.Drawing.Point(633, 98);
            this.btNewSearch.Name = "btNewSearch";
            this.btNewSearch.Size = new System.Drawing.Size(121, 23);
            this.btNewSearch.TabIndex = 29;
            this.btNewSearch.Text = "Новый запрос";
            this.btNewSearch.UseVisualStyleBackColor = true;
            this.btNewSearch.Visible = false;
            this.btNewSearch.Click += new System.EventHandler(this.btNewSearch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cinema.Properties.Resources.film;
            this.pictureBox1.Location = new System.Drawing.Point(18, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(85, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(936, 733);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btNewSearch);
            this.Controls.Add(this.cbEqv);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.tbEqv);
            this.Controls.Add(this.cbSign);
            this.Controls.Add(this.btSession);
            this.Controls.Add(this.btExel);
            this.Controls.Add(this.btChange);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btEnt);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btExtra);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.cbNewEnt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbAtr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbEnt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btEntry);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPoster);
            this.Controls.Add(this.tbInfo);
            this.MaximumSize = new System.Drawing.Size(954, 780);
            this.MinimumSize = new System.Drawing.Size(954, 780);
            this.Name = "Form1";
            this.Text = "Cinema";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btEntry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAtr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbNewEnt;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.Button btExtra;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btEnt;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btChange;
        private System.Windows.Forms.Button btExel;
        private System.Windows.Forms.Button btSession;
        private System.Windows.Forms.ComboBox cbSign;
        private System.Windows.Forms.TextBox tbEqv;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.ComboBox cbEqv;
        private System.Windows.Forms.Button btNewSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

