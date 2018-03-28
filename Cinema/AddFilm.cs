using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cinema
{
    public partial class AddFilm : Form
    {
        public CinemaModelContainer db = new CinemaModelContainer();
        public string poster="";
        public bool saved = false;
        public bool add;
        public Film film;
        Form1 form;

        public AddFilm(Form1 forma, bool add, Film x)
        {
            InitializeComponent();
            form = forma;
            form.Enabled = false;
            this.add = add;
            film = x;
        }
        public void texts()
        {
            if (!add)
            {
                this.Text = "Редактирование информации о фильме";
                tbName.Text = db.FilmSet.Find(film.ID).Name;
                nudYear.Value = db.FilmSet.Find(film.ID).Year;
                tbProd.Text = db.FilmSet.Find(film.ID).Producer;
                dudAge.Text = db.FilmSet.Find(film.ID).AgeLimit;
                nudHour.Value = db.FilmSet.Find(film.ID).length.Hours;
                nudMin.Value = db.FilmSet.Find(film.ID).length.Minutes;
                tbDescrip.Text = db.FilmSet.Find(film.ID).Description;
                btAdd.Text = "Сохранить изменения";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sf = new OpenFileDialog();
            sf.Filter = "Text files (*.txt)|*.txt";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamReader f = new StreamReader(sf.FileName);
                try
                {
                    tbDescrip.Text = f.ReadToEnd();
                }
                catch
                {
                    MessageBox.Show("Неудалось считать содержимое из файла");
                }
            }
        }

        private void AddFilm_Load(object sender, EventArgs e)
        {
            texts();
        }

        private void btPoster_Click(object sender, EventArgs e)
        {
            OpenFileDialog sf = new OpenFileDialog();
            sf.Filter = "Images |*.GIF;*.TIF;*.JPG;*.BPM";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                poster = sf.FileName;
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if ((tbName.Text == "") || (tbProd.Text == "") || ((poster == "") && (add)) || (tbDescrip.Text == "")) MessageBox.Show("Вы заполнили не все поля!");
            else
            {
                TimeSpan time = new TimeSpan((int)nudHour.Value, (int)nudMin.Value, 0);
                if (add)
                    FilmWork.Add(tbName.Text, dudAge.Text, tbDescrip.Text, time, tbProd.Text, (short)nudYear.Value, poster);
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Данные о фильме будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        FilmWork.Change(tbName.Text, film.ID, dudAge.Text, tbDescrip.Text, time, tbProd.Text, (short)nudYear.Value, poster);
                    }
                }
                db.SaveChanges();
                form.UpdateFilms();
                saved = true;
                this.Close();
            }
        }

        private void AddFilm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult;
            if (!saved)
            {
                dialogResult = MessageBox.Show("Данные не сохранились. Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) e.Cancel=true;
            }
            form.Enabled = true;
        }
    }
}
