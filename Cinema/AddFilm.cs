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
                tbName.Text = film.Name;
                nudYear.Value = film.Year;
                tbProd.Text = film.Producer;
                dudAge.Text = film.AgeLimit;
                nudHour.Value = film.length.Hours;
                nudMin.Value = film.length.Minutes;
                tbDescrip.Text = film.Description;
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
            if ((tbName.Text == "") || (tbProd.Text == "") || ((poster == "")&&(add)) || (tbDescrip.Text == "")) MessageBox.Show("Вы заполнили не все поля!");
            else
            {
                bool ok = true;
                foreach (Film x in db.FilmSet)
                {
                    if ((x.Name == tbName.Text) && ((add) || (!add) && (film.ID != x.ID)))
                    {
                        MessageBox.Show("Фильм с таким названием уже существует");
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    TimeSpan time = new TimeSpan((int)nudHour.Value, (int)nudMin.Value, 0);
                    if (add)
                        db.FilmSet.Add(new Film { Name = tbName.Text, AgeLimit = dudAge.Text, Description = tbDescrip.Text, length = time, Producer = tbProd.Text, Year = (short)nudYear.Value, Poster = poster });
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Данные о фильме будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            db.FilmSet.Find(film.ID).AgeLimit = dudAge.Text;
                            db.FilmSet.Find(film.ID).Name = tbName.Text;
                            db.FilmSet.Find(film.ID).Description = tbDescrip.Text;
                            db.FilmSet.Find(film.ID).length = time;
                            db.FilmSet.Find(film.ID).Producer = tbProd.Text;
                            db.FilmSet.Find(film.ID).Year = (short)nudYear.Value;
                            if (poster!= "")
                            db.FilmSet.Find(film.ID).Poster = poster;
                        }
                    }
                    db.SaveChanges();
                    form.UpdateFilms();
                    saved = true;
                    this.Close();
                }
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
