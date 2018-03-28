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
    public partial class AddHall : Form
    {
        public CinemaModelContainer db = new CinemaModelContainer();
        public bool saved = false;
        public bool add;
        public Hall hall;
        Form1 form;
        public AddHall(Form1 forma, bool add, Hall x)
        {
            InitializeComponent();
            form = forma;
            form.Enabled = false;
            this.add = add;
            hall = x;
            cbCinema.DataSource = (from d in db.CinemaSet where d.Deleted == false select d).ToList();
            cbCinema.DisplayMember = "Name";
            cbCinema.Update();
            texts();
        }
        public void texts()
        {
            if (!add)
            {
                this.Text = "Редактирование информации о зале";
                nudNumber.Value = db.HallSet.Find(hall.ID).Num;
                dudType.Text = db.HallSet.Find(hall.ID).Type;
                nudRows.Value = db.HallSet.Find(hall.ID).AmountOfRow;
                nudSeats.Value = db.HallSet.Find(hall.ID).AmountOfSeats;
                if (db.HallSet.Find(hall.ID).Session.Count > 0)
                {
                    nudRows.Enabled = false;
                    nudSeats.Enabled = false;
                    label6.Text = "В данном зале уже";
                    label7.Text = "запланированы сеансы";
                }
                cbCinema.Visible = false;
                label5.Visible = false;
                btAdd.Text = "Сохранить изменения";
            }
        }

        private void cbCinema_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if ((dudType.Text == "") || (cbCinema.Text == "")) MessageBox.Show("Вы заполнили не все поля!");
            else
            {
                if (add)
                {
                    HallWork.Add(db.CinemaSet.Find(((Cinema)cbCinema.SelectedValue).ID), (byte)nudNumber.Value, dudType.Text, (byte)nudRows.Value, (byte)nudSeats.Value);
                }
                else
                {
                    HallWork.Change(hall.Cinema, (byte)nudNumber.Value, dudType.Text, (byte)nudRows.Value, (byte)nudSeats.Value, hall.ID);
                }
                form.UpdateHall();
                saved = true;
                this.Close();
            }
        }

        private void AddHall_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult;
            if (!saved)
            {
                dialogResult = MessageBox.Show("Данные не сохранились. Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) e.Cancel = true;
            }
            form.Enabled = true;
        }

        private void cbCinema_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
