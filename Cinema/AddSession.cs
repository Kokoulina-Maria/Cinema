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
    public partial class AddSession : Form
    {
        public CinemaModelContainer db = new CinemaModelContainer();
        public bool saved = false;
        public bool add;
        public Session session;
        Form1 form;
        public AddSession(Form1 forma, bool add, Session x)
        {
            InitializeComponent();
            form = forma;
            form.Enabled = false;
            this.add = add;
            session = x;
        }
        public void Info()
        {
            if (add)
            cbHall.DataSource = (from d in ((Cinema)(cbCinema.SelectedValue)).Hall where d.Deleted == false select d).ToList();
            else cbHall.DataSource= (from d in (session.Hall.Cinema.Hall) where d.Deleted == false select d).ToList();
            cbHall.DisplayMember = "Num";
            cbHall.Update();           
        }
        public void texts()
        {
            if (!add)
            {             
                this.Text = "Редактирование информации о зале";
                cbCinema.Visible = false;
                label1.Visible = false;
                nudPrice.Value = db.SessionSet.Find(session.ID).Price;
                dtpDate.Value = db.SessionSet.Find(session.ID).Date.Date;
                cbHall.Text = db.SessionSet.Find(session.ID).Hall.Num.ToString();
                cbFilm.Text = db.SessionSet.Find(session.ID).Film.Name.ToString();
                nudHour.Value = db.SessionSet.Find(session.ID).Time.Hour;
                nudMin.Value = db.SessionSet.Find(session.ID).Time.Minute;
                cbCinema.Visible = false;
                label5.Visible = false;
                btAdd.Text = "Сохранить изменения";
            }
        }

        private void AddSession_Load(object sender, EventArgs e)
        {         
            cbCinema.DataSource = (from d in db.CinemaSet where d.Deleted == false select d).ToList();
            cbCinema.DisplayMember = "Name";
            cbCinema.Update();
            cbFilm.DataSource = (from d in db.FilmSet select d).ToList();
            cbFilm.DisplayMember = "Name";
            cbFilm.Update();
            Info();
            texts();
        }

        private void cbCinema_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbHall_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbFilm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if ((cbCinema.Text == "") || (cbHall.Text == "") || (cbFilm.Text == "")) MessageBox.Show("Вы заполнили не все поля!");
            else
            {
                DateTime t = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day, (int)nudHour.Value, (int)nudMin.Value, 0);
                if (add)
                {
                    SessionWork.Add(db.HallSet.Find(((Hall)(cbHall.SelectedValue)).ID), t, db.FilmSet.Find(((Film)(cbFilm.SelectedValue)).ID), (short)nudPrice.Value);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Данные о сеансе будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SessionWork.Change(db.HallSet.Find(((Hall)(cbHall.SelectedValue)).ID), t, db.FilmSet.Find(((Film)(cbFilm.SelectedValue)).ID), (short)nudPrice.Value, session.ID);
                    }
                }
                db.SaveChanges();
                form.UpdateSession();
                saved = true;
                this.Close();

            }
        }

        private void AddSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult;
            if (!saved)
            {
                dialogResult = MessageBox.Show("Данные не сохранились. Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) e.Cancel = true;
            }
            form.Enabled = true;
        }

        private void cbCinema_SelectedValueChanged(object sender, EventArgs e)
        {
            Info();
        }
    }
}
