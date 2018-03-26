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
                tbName.Text = db.CinemaSet.Find(cinema.ID).Name;
                tbCity.Text = db.CinemaSet.Find(cinema.ID).City;
                tbAdress.Text = db.CinemaSet.Find(cinema.ID).Adress;
                btAdd.Text = "Сохранить изменения";
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if ((tbName.Text == "") || (tbCity.Text == "") || (tbAdress.Text == "")) MessageBox.Show("Вы заполнили не все поля!");
            else
            {
                if (add)
                    CinemaWork.Add(tbName.Text, tbCity.Text, tbAdress.Text);
                else
                {
                    CinemaWork.Change(tbName.Text, tbCity.Text, tbAdress.Text, cinema.ID);
                }
                    form.UpdateCinema();
                    saved = true;
                    this.Close();
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
