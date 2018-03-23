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
            cbHall.DataSource = (from d in ((Cinema)(cbCinema.SelectedValue)).Hall where d.Deleted == false select d).ToList();
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
                nudPrice.Value = session.Price;
                dtpDate.Value = session.Date.Date;
                //cbHall.SelectedValue = session.Hall.Num;
                //cbFilm.SelectedValue = session.Film.Name;
                nudHour.Value = session.Time.Hour;
                nudMin.Value = session.Time.Minute;
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
            cbHall.Update();
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
                bool ok = true;
                TimeSpan q = new TimeSpan(5, 0, 0);
                foreach (Session x in db.SessionSet)
                {                   
                    if ((x.Hall == ((Hall)(cbHall.SelectedValue))) && (x.Date == dtpDate.Value) && (x.Time.TimeOfDay<= t.TimeOfDay) && ((x.Time+q).TimeOfDay >= t.TimeOfDay) && ((add) || (!add) && (session.ID != x.ID)))
                    {
                        MessageBox.Show("В данном зале в это время уже идет сеанс!");
                        ok = false;
                        break;
                    }
                    if (t<=DateTime.Now)
                    {
                        MessageBox.Show("Вы не можете добавить сеанс, который уже начался!");
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (add)
                    {
                        Session c = new Session();
                        c.Film=db.FilmSet.Find(((Film)(cbFilm.SelectedValue)).ID);
                        c.Hall = db.HallSet.Find(((Hall)(cbHall.SelectedValue)).ID);
                        c.Price =(short)nudPrice.Value;
                        c.Date = t;
                        c.Time = t;
                        db.SessionSet.Add(c);
                        for (int i=0; i<c.Hall.AmountOfRow; i++)
                            for (int j=0; j<c.Hall.AmountOfSeats; j++)
                            {
                                Seat s = new Seat();
                                s.Session=db.SessionSet.Find(c.ID);
                                s.State = "Свободно";
                                s.NumberOfRow = (byte)(i + 1);
                                s.NumberOfSeat = (byte)(j + 1);
                                db.SeatSet.Add(s);
                            }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Данные о сеансе будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.SessionSet.Find(session.ID).Film= db.FilmSet.Find(((Film)(cbFilm.SelectedValue)).ID);
                            db.SessionSet.Find(session.ID).Hall= db.HallSet.Find(((Hall)(cbHall.SelectedValue)).ID);
                            db.SessionSet.Find(session.ID).Price= (short)nudPrice.Value;
                            db.SessionSet.Find(session.ID).Date= dtpDate.Value;
                            db.SessionSet.Find(session.ID).Time = t;
                        }
                    }
                    db.SaveChanges();
                    form.UpdateSession();
                    saved = true;
                    this.Close();
                }
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
