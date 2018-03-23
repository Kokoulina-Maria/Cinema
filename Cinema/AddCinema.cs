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
    public partial class AddCinema : Form
    {
        public CinemaModelContainer db = new CinemaModelContainer();
        public bool saved = false;
        public bool add;
        public Cinema cinema;
        Form1 form;
        public AddCinema(Form1 forma, bool add, Cinema x)
        {
            InitializeComponent();
            form = forma;
            form.Enabled = false;
            this.add = add;
            cinema = x;
            texts();
        }
        public void texts()
        {
            if (!add)
            {
                this.Text = "Редактирование информации о кинотеатре";
                tbName.Text = cinema.Name;
                tbCity.Text = cinema.City;
                tbAdress.Text = cinema.Adress;
                btAdd.Text = "Сохранить изменения";
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if ((tbName.Text == "") || (tbCity.Text == "") || (tbAdress.Text == "")) MessageBox.Show("Вы заполнили не все поля!");
            else
            {
                bool ok = true;
                foreach (Cinema x in db.CinemaSet)
                {
                    if ((x.City == tbCity.Text) && (x.Adress == tbAdress.Text) && ((add) || (!add) && (cinema.ID != x.ID)))
                    {
                        MessageBox.Show("Кинотеатр по таком адресу уже существует!");
                        ok = false;
                        break;
                    }
                    if ((x.City == tbCity.Text) && (x.Name == tbName.Text) && ((add) || (!add) && (cinema.ID != x.ID)))
                    {
                        MessageBox.Show("В данном городе уже существует кинотеатр с таким названием!");
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (add)
                        db.CinemaSet.Add(new Cinema { Name = tbName.Text, City = tbCity.Text, Adress = tbAdress.Text });
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Данные о кинотеатре будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.CinemaSet.Find(cinema.ID).Name = tbName.Text;
                            db.CinemaSet.Find(cinema.ID).City = tbCity.Text;
                            db.CinemaSet.Find(cinema.ID).Adress = tbAdress.Text;
                        }
                    }
                    db.SaveChanges();
                    form.UpdateCinema();
                    saved = true;
                    this.Close();
                }
            }
        }

        private void AddCinema_FormClosing(object sender, FormClosingEventArgs e)
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
