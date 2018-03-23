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
                nudNumber.Value = hall.Num;
                dudType.Text = hall.Type;
                nudRows.Value = hall.AmountOfRow;
                nudSeats.Value = hall.AmountOfSeats;
                if (hall.Session.Count > 0)
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
            if ((dudType.Text == "")||(cbCinema.Text=="")) MessageBox.Show("Вы заполнили не все поля!");
            else
            {
                bool ok = true;
                foreach (Hall x in db.HallSet)
                {
                    if ((x.Cinema == ((Cinema)(cbCinema.SelectedValue))) && (x.Num== nudNumber.Value)&&((add) || (!add) && (hall.ID != x.ID)))
                    {
                        MessageBox.Show("В данном кинотеатре уже есть зал с таким номером!");
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (add)
                    {
                        Hall c = new Hall();
                        c.Num = (byte)nudNumber.Value;
                        c.Type = dudType.Text;
                        c.AmountOfRow = (byte)nudRows.Value;
                        c.AmountOfSeats = (byte)nudSeats.Value;
                        c.Cinema = db.CinemaSet.Find(((Cinema)(cbCinema.SelectedValue)).ID);
                        db.HallSet.Add(c);
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Данные о зале будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.HallSet.Find(hall.ID).Num = (byte)nudNumber.Value;
                            db.HallSet.Find(hall.ID).Type = dudType.Text;
                            db.HallSet.Find(hall.ID).AmountOfRow = (byte)nudRows.Value;
                            db.HallSet.Find(hall.ID).AmountOfSeats = (byte)nudSeats.Value;
                        }
                    }
                    db.SaveChanges();
                    form.UpdateHall();
                    saved = true;
                    this.Close();
                }
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
    }
}
