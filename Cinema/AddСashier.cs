using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class AddСashier : Form
    {
        public CinemaModelContainer db = new CinemaModelContainer();
        public bool saved = false;
        public bool add;
        public Сashier cashier;
        Form1 form;
        public AddСashier(Form1 forma, bool add, Сashier x)
        {
            InitializeComponent();
            form = forma;
            form.Enabled = false;
            this.add = add;
            cashier= x;
            cbCinema.DataSource = (from d in db.CinemaSet where d.Deleted==false select d).ToList();
            cbCinema.DisplayMember = "Name";
            cbCinema.Update();
            texts();
        }
        public void texts()
        {
            if (!add)
            {
                this.Text = "Редактирование информации о кассире";
                tbFIO.Text = db.СashierSet.Find(cashier.ID).FIO;
                tbLogin.Text = db.СashierSet.Find(cashier.ID).Login;
                tbPassword.Text = db.СashierSet.Find(cashier.ID).Password;
                cbCinema.Visible=false;
                label4.Visible = false;
                btAdd.Text = "Сохранить изменения";
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 127 && number != 32)
                e.Handled = true;
        }

        private void cbCinema_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbCinema_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if ((tbFIO.Text == "") || (tbLogin.Text == "") || (tbPassword.Text == "") || (cbCinema.Text == "")) MessageBox.Show("Вы заполнили не все поля!");
            else
            {

                if (add)
                {
                    CashierWork.Add(tbLogin.Text, tbFIO.Text, tbPassword.Text, db.CinemaSet.Find(((Cinema)cbCinema.SelectedValue).ID));
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Данные о кассире будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        CashierWork.Change(tbLogin.Text, tbFIO.Text, tbPassword.Text, cashier.ID);
                    }
                }
                db.SaveChanges();
                form.UpdateCashier();
                saved = true;
                this.Close();
            }
        }

        private void AddСashier_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult;
            if (!saved)
            {
                dialogResult = MessageBox.Show("Данные не сохранились. Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) e.Cancel = true;
            }
            form.Enabled = true;
        }
    }
}
