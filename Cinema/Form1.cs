using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Excel=Microsoft.Office.Interop.Excel;

namespace Cinema
{
    public partial class Form1 : Form
    {
        public const string admLog = "Admin";
        public const string admPass = "12345";
        public eEntity NowEnt = default(eEntity);
        public eUser user;
        public CinemaModelContainer db = new CinemaModelContainer();
        public Form form;
        public List<Film> films;
        public List<Cinema> cinemas;
        public List<Hall> halls;
        public List<Сashier> cashiers;
        public List<Session> sessions;
        public List<Ticket> tickets;
        public List<Booking> bookings;
        public List<Film> nowfilms;
        public List<Cinema> nowcinemas;
        public List<Hall> nowhalls;
        public List<Сashier> nowcashiers;
        public List<Session> nowsessions;
        public List<Ticket> nowtickets;
        public List<Booking> nowbookings;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            user = eUser.Клиент;
            BlockZapr();
            BlockNewEnt();
            btExit.Enabled = false;
            foreach (Session d in db.SessionSet)
                if (d.Time < DateTime.Now) DeleteSession(d.ID);
            db.SaveChanges();
            ListNull();
            ListDB();
        }
        public void ListNull()
        {
            films = new List<Film>();
            cinemas = new List<Cinema>();
            halls = new List<Hall>();
            cashiers = new List<Сashier>();
            sessions = new List<Session>();
            tickets = new List<Ticket>();
            bookings = new List<Booking>();
        }
        public void ListDB()
        {
            nowfilms = db.FilmSet.ToList();
            nowcinemas = db.CinemaSet.ToList();
            nowhalls = db.HallSet.ToList();
            nowcashiers = db.СashierSet.ToList();
            nowsessions = db.SessionSet.ToList();
            nowtickets = db.TicketSet.ToList();
            nowbookings = db.BookingSet.ToList();
        }

        private void btEntry_Click(object sender, EventArgs e)
        {//если пользователь заходит, то это либо админ, либо кассир           
            if ((tbLogin.Text == admLog) && (tbPassword.Text == admPass))
            {
                user = eUser.Админ;
                //админ может найти информацию не только о кинотеатрах, но и о кассире
                cbSearch.Items.Add("Кассир");
                BlockSearch();
                UnblockAdmin();
                if (cbSearch.Items.Contains("Билет"))
                {
                    cbSearch.Items.Remove("Билет");
                    cbSearch.Items.Remove("Бронь");
                }
                if (NowEnt != default(eEntity)) AdminSearch();
                btExit.Enabled = true;
                if (NowEnt == eEntity.Кинотеатр)
                    UpdateCinema();
                if (NowEnt == eEntity.Зал)
                    UpdateHall();
            }
            else
            {
                bool ok = false;
                if (db.СashierSet.Count() != 0)
                {
                    foreach (Сashier x in db.СashierSet)
                        if ((x.Login == tbLogin.Text) && (x.Password == tbPassword.Text))
                        {
                            ok = true;
                            break;
                        }
                    if (ok)
                    {
                        user = eUser.Кассир;
                        if (cbSearch.Items.Contains("Кассир")) cbSearch.Items.Remove("Кассир");
                        cbSearch.Items.Add("Билет");
                        cbSearch.Items.Add("Бронь");
                        BlockAdmin();
                        btExit.Enabled = true;
                    }
                    else MessageBox.Show("Неверные логин или пароль!");
                }
                else MessageBox.Show("Неверные логин или пароль!");
            }
            tbLogin.Text = "";
            tbPassword.Text = "";
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 127 && number != 32)
                e.Handled = true;
        }

        private void btExit_Click(object sender, EventArgs e)
        {//если пользователь выходит, то он автоматически становится клиентом
            btExit.Enabled = false;
            user = eUser.Клиент;
            if (cbSearch.Items.Contains("Кассир")) cbSearch.Items.Remove("Кассир");
            if (cbSearch.Items.Contains("Билет"))
            {
                cbSearch.Items.Remove("Билет");
                cbSearch.Items.Remove("Бронь");
            }
            BlockAdmin();
            if ((NowEnt == eEntity.Кассир) || (NowEnt == eEntity.Билет) || (NowEnt == eEntity.Бронь))
            {
                dgvList.DataSource = null;
                cbSearch.Text = "Фильм";
                BlockZapr();
            }
            if (NowEnt == eEntity.Фильм)
                FilmSearch();
            if (NowEnt == eEntity.Кинотеатр)
                UpdateCinema();
            if (NowEnt == eEntity.Зал)
                UpdateHall();
            if (NowEnt == eEntity.Сеанс)
                SessionSearch();
            Information();
        }

        public void UnblockAdmin()
        {
            btAdd.Visible = true;
            btDelete.Visible = true;
            btChange.Visible = true;
            btExel.Visible = true;
        }
        public void BlockAdmin()
        {
            btAdd.Visible = false;
            btDelete.Visible = false;
            btChange.Visible = false;
            btExel.Visible = false;
        }
        public void BlockZapr()
        {
            cbSearch.Enabled = true;
            btEnt.Enabled = true;
            cbEnt.Enabled = false;
            cbAtr.Enabled = false;
            cbSign.Enabled = false;
            tbEqv.Enabled = false;
            btFind.Enabled = false;
        }
        public void BlockNewEnt()
        {
            cbNewEnt.Enabled = false;
            btExtra.Enabled = false;
        }
        public void unBlockNewEnt()
        {
            cbNewEnt.Enabled = true;
            btExtra.Enabled = true;
        }
        public void unBlockZapr()
        {
            cbEnt.Enabled = true;
            cbAtr.Enabled = true;
            cbSign.Enabled = true;
            tbEqv.Enabled = true;
            btFind.Enabled = true;
        }
        public void EntitiesForFilm()
        {
            cbEnt.Text = "Фильм";
            string[] x = { "Фильм" };
            cbEnt.Items.Clear();
            cbEnt.Items.Add("Фильм");
        }
        public void EntitiesForCinema()
        {
            cbEnt.Text = "Кинотеатр";
            string[] x = { "Кинотеатр" };
            cbEnt.Items.Clear();
            cbEnt.Items.AddRange(x);
        }
        public void EntitiesForHall()
        {
            cbEnt.Text = "Кинотеатр";
            string[] x = { "Кинотеатр", "Зал" };
            cbEnt.Items.Clear();
            cbEnt.Items.AddRange(x);
        }
        public void EntitiesForSession()
        {
            cbEnt.Text = "Фильм";
            string[] x = { "Фильм", "Кинотеатр", "Зал", "Сеанс" };
            cbEnt.Items.Clear();
            cbEnt.Items.AddRange(x);
        }
        public void EntitiesForCashier()
        {
            cbEnt.Text = "Кинотеатр";
            string[] x = { "Кинотеатр", "Кассир" };
            cbEnt.Items.Clear();
            cbEnt.Items.AddRange(x);
        }
        public void EntitiesForTicket()
        {
            cbEnt.Text = "Фильм";
            string[] x = { "Фильм", "Кинотеатр", "Зал", "Сеанс", "Место", "Билет" };
            cbEnt.Items.Clear();
            cbEnt.Items.AddRange(x);
        }
        public void EntitiesForBoking()
        {
            cbEnt.Text = "Фильм";
            string[] x = { "Фильм", "Кинотеатр", "Зал", "Сеанс", "Место", "Бронь" };
            cbEnt.Items.Clear();
            cbEnt.Items.AddRange(x);
        }
        public void AttribForFilm()
        {
            cbAtr.Text = "Название";
            string[] x = { "Название", "Год", "Длительность", "Возрастное ограничение", "Продюссер" };
            cbAtr.Items.Clear();
            cbAtr.Items.AddRange(x);
        }
        public void AttribForCinema()
        {
            cbAtr.Text = "Город";
            string[] x = { "Город", "Адрес", "Название" };
            cbAtr.Items.Clear();
            cbAtr.Items.AddRange(x);
        }
        public void AttribForHall()
        {
            cbAtr.Text = "Номер";
            string[] x = { "Номер", "Тип", "Количество рядов", "Количество мест в ряду" };
            cbAtr.Items.Clear();
            cbAtr.Items.AddRange(x);
        }
        public void AttribForSession()
        {
            cbAtr.Text = "Дата";
            string[] x = { "Дата", "Цена", "Время" };
            cbAtr.Items.Clear();
            cbAtr.Items.AddRange(x);
        }
        public void AttribForCashier()
        {
            cbAtr.Text = "ФИО";
            string[] x = { "ФИО", "Логин" };
            cbAtr.Items.Clear();
            cbAtr.Items.AddRange(x);
        }
        public void AttribForTicketOrBooking()
        {
            cbAtr.Text = "Номер";
            string[] x = { "Номер" };
            cbAtr.Items.Clear();
            cbAtr.Items.AddRange(x);
        }
        public void AttribForSeat()
        {
            cbAtr.Text = "Ряд";
            string[] x = { "Ряд", "Номер в ряду" };
            cbAtr.Items.Clear();
            cbAtr.Items.AddRange(x);
        }


        private void btEnt_Click(object sender, EventArgs e)
        {
            ListNull();
            ListDB();
            BlockNewEnt();
            BlockSearch();
            unBlockZapr();
            cbNewEnt.Text = "И";
            switch (cbSearch.Text)
            {
                case "Фильм": { EntitiesForFilm(); NowEnt = eEntity.Фильм; break; }
                case "Кинотеатр": { EntitiesForCinema(); NowEnt = eEntity.Кинотеатр; break; }
                case "Зал": { EntitiesForHall(); NowEnt = eEntity.Зал; break; }
                case "Сеанс": { EntitiesForSession(); NowEnt = eEntity.Сеанс; break; }
                case "Кассир": { EntitiesForCashier(); NowEnt = eEntity.Кассир; break; }
                case "Билет": { EntitiesForTicket(); NowEnt = eEntity.Билет; break; }
                case "Бронь": { EntitiesForBoking(); NowEnt = eEntity.Бронь; break; }
                default: { break; }
            }
            if (user == eUser.Админ)
            {
                AdminSearch();
            }
            dgvList.MultiSelect = true;
            switch (NowEnt)
            {
                case eEntity.Фильм:
                    {
                        UpdateFilms();
                        if (user != eUser.Админ)
                            FilmSearch();
                        break;
                    }
                case eEntity.Сеанс:
                    {
                        UpdateSession();
                        if (user != eUser.Админ)
                            SessionSearch();
                        break;
                    }
                case eEntity.Кинотеатр:
                    {
                        UpdateCinema();
                        dgvList.MultiSelect = false;
                        break;
                    }
                case eEntity.Зал:
                    {
                        UpdateHall();
                        dgvList.MultiSelect = false;
                        break;
                    }
                case eEntity.Кассир:
                    {
                        UpdateCashier();
                        break;
                    }
                case eEntity.Билет:
                    {
                        UpdateTicket();
                        break;
                    }
                case eEntity.Бронь:
                    {
                        UpdateBooking();
                        break;
                    }

                default: { break; }
            }
            Information();
        }

        private void cbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbEnt_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void cbEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbEnt_TextChanged(object sender, EventArgs e)
        {
            switch (cbEnt.Text)
            {
                case "Фильм": { AttribForFilm(); break; }
                case "Кинотеатр": { AttribForCinema(); break; }
                case "Зал": { AttribForHall(); break; }
                case "Сеанс": { AttribForSession(); break; }
                case "Кассир": { AttribForCashier(); break; }
                case "Билет": { AttribForTicketOrBooking(); break; }
                case "Бронь": { AttribForTicketOrBooking(); break; }
                case "Место": { AttribForSeat(); break; }
                default: { break; }
            }
        }

        private void cbSign_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbNewEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void BlockSearch()
        {
            btAdd.Enabled = false;
            btDelete.Enabled = false;
            btExel.Enabled = false;
            btChange.Enabled = false;
            tbInfo.Visible = false;
            tbInfo.Text = "";
            pbPoster.Visible = false;
            pbPoster.Image = null;
            btSession.Visible = false;
        }
        private void FilmSearch()
        {
            tbInfo.Visible = true;
            pbPoster.Visible = true;
        }
        private void SessionSearch()
        {
            btSession.Visible = true;
        }
        private void AdminSearch()
        {
            btAdd.Enabled = true;
            btDelete.Enabled = true;
            btExel.Enabled = true;
            btChange.Enabled = true;
        }
        
        //Нужно добавить проверку на ввод!
        private void btFind_Click(object sender, EventArgs e)
        {
            if ((tbEqv.Visible) && (tbEqv.Text == ""))
                MessageBox.Show("Заполните поле ввода!");
            else
            {
                if ((cbNewEnt.Text == "И"))
                    Search(true);
                else Search(false);
                unBlockNewEnt();
                BlockZapr();
            }
        }

        private void btExtra_Click(object sender, EventArgs e)
        {
            unBlockZapr();
            BlockNewEnt();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (NowEnt == eEntity.Фильм)
            {
                form = new AddFilm(this, true, null);
            }
            if (NowEnt == eEntity.Кинотеатр)
            {
                form = new AddCinema(this, true, null);
            }
            if (NowEnt == eEntity.Кассир)
            {
                form = new AddСashier(this, true, null);
            }
            if (NowEnt == eEntity.Зал)
            {
                form = new AddHall(this, true, null);
            }
            if (NowEnt == eEntity.Сеанс)
            {
                form = new AddSession(this, true, null);
            }
            form.Show();
        }
        public void UpdateFilms()
        {
            dgvList.DataSource = (from d in db.FilmSet select new { d.ID, d.Name, d.Year, d.Producer, d.length, d.AgeLimit }).ToList();
            FilmsColomns();
            dgvList.Update();
        }
        public void FilmsColomns()
        {
            dgvList.Columns[0].Visible = false;
            dgvList.Columns[1].HeaderText = "Название";
            dgvList.Columns[2].HeaderText = "Год";
            dgvList.Columns[3].HeaderText = "Режиссер";
            dgvList.Columns[4].HeaderText = "Длина";
            dgvList.Columns[5].HeaderText = "Ограничение";
        }
        public void UpdateSession()
        {
            dgvList.DataSource = (from d in db.SessionSet where d.Time > DateTime.Now select new { d.ID, d.Time, d.Film.Name, d.Hall.Cinema.City, d.Hall.Cinema.Adress, d.Price, d.Hall.Num }).ToList();
            SessionColomns();
            dgvList.Update();
        }
        public void SessionColomns()
        {
            dgvList.Columns[0].Visible = false;
            dgvList.Columns[1].HeaderText = "Начало";
            dgvList.Columns[2].HeaderText = "Фильм";
            dgvList.Columns[3].HeaderText = "Город";
            dgvList.Columns[4].HeaderText = "Адрес";
            dgvList.Columns[5].HeaderText = "Цена";
            dgvList.Columns[6].HeaderText = "Зал";
        }
        public void UpdateCinema()
        {
            if (user != eUser.Админ)
                dgvList.DataSource = (from d in db.CinemaSet where d.Deleted == false select new { d.ID, d.Name, d.City, d.Adress }).ToList();
            else dgvList.DataSource = (from d in db.CinemaSet select new { d.ID, d.Name, d.City, d.Adress, d.Deleted }).ToList();
            CinemaColomns();
            dgvList.Update();
        }
        public void CinemaColomns()
        {
            dgvList.Columns[0].Visible = false;
            dgvList.Columns[1].HeaderText = "Название";
            dgvList.Columns[2].HeaderText = "Город";
            dgvList.Columns[3].HeaderText = "Адрес";
            if (user == eUser.Админ)
                dgvList.Columns[4].HeaderText = "Удален";
        }
        public void UpdateHall()
        {
            if (user != eUser.Админ)
                dgvList.DataSource = (from d in db.HallSet where d.Deleted == false select new { d.ID, d.Num, d.Cinema.Name, d.Cinema.City, d.Type, d.AmountOfRow, d.AmountOfSeats }).ToList();
            else dgvList.DataSource = (from d in db.HallSet select new { d.ID, d.Num, d.Cinema.Name, d.Cinema.City, d.Type, d.AmountOfRow, d.AmountOfSeats, d.Deleted }).ToList();
            HallColomns();
            dgvList.Update();
        }
        public void HallColomns()
        {
            dgvList.Columns[0].Visible = false;
            dgvList.Columns[1].HeaderText = "Номер";
            dgvList.Columns[2].HeaderText = "Кинотеатр";
            dgvList.Columns[3].HeaderText = "Город";
            dgvList.Columns[4].HeaderText = "Тип";
            dgvList.Columns[5].HeaderText = "Ряды";
            dgvList.Columns[6].HeaderText = "Места в ряду";
            if (user == eUser.Админ)
                dgvList.Columns[7].HeaderText = "Удален";
        }
        public void UpdateCashier()
        {
            dgvList.DataSource = (from d in db.СashierSet select new { d.ID, d.FIO, d.Cinema.City, d.Cinema.Name, d.Login, d.Password }).ToList();
            CashierColomns();
            dgvList.Update();
        }
        public void CashierColomns()
        {
            dgvList.Columns[0].Visible = false;
            dgvList.Columns[1].HeaderText = "ФИО";
            dgvList.Columns[2].HeaderText = "Город";
            dgvList.Columns[3].HeaderText = "Кинотеатр";
            dgvList.Columns[4].HeaderText = "Логин";
            dgvList.Columns[5].HeaderText = "Пароль";
        }
        public void UpdateTicket()
        {
            dgvList.DataSource = (from d in db.TicketSet select new { d.Number, d.Seat.NumberOfRow, d.Seat.NumberOfSeat, d.Seat.Session.Time, d.Seat.Session.Film.Name, d.Seat.Session.Hall.Num, d.Seat.Session.Hall.Cinema.Adress }).ToList();
            TBColomns();
            dgvList.Update();
        }
        public void UpdateBooking()
        {
            dgvList.DataSource = (from d in db.BookingSet select new { d.Number, d.Seat.NumberOfRow, d.Seat.NumberOfSeat, d.Seat.Session.Time, d.Seat.Session.Film.Name, d.Seat.Session.Hall.Num, d.Seat.Session.Hall.Cinema.Adress }).ToList();
            TBColomns();
            dgvList.Update();
        }
        public void TBColomns()
        {
            dgvList.Columns[0].HeaderText = "Номер";
            dgvList.Columns[1].HeaderText = "Ряд";
            dgvList.Columns[2].HeaderText = "Место";
            dgvList.Columns[3].HeaderText = "Сеанс";
            dgvList.Columns[4].HeaderText = "Фильм";
            dgvList.Columns[5].HeaderText = "Зал";
            dgvList.Columns[6].HeaderText = "Кинотеатр";
        }


        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count > 0)
            {
                if (NowEnt == eEntity.Фильм)
                {
                    DeleteFilm();
                }
                if (NowEnt == eEntity.Кинотеатр)
                {
                    DeleteCinema();
                }
                if (NowEnt == eEntity.Кассир)
                {
                    DeleteCashier();
                }
                if (NowEnt == eEntity.Зал)
                {
                    DeleteHall();
                }
                if (NowEnt == eEntity.Сеанс)
                {
                    DeleteSessions();
                }
            }
        }

        private void DeleteFilm()
        {
            DialogResult dialogResult = MessageBox.Show("Фильмы, а также все их сеансы будут удалены безвозвратно. Возможно, на данные сеансы были куплены билеты. В уверены, что хотите удалить данный фильмы?", "Удаление фильма", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < dgvList.SelectedRows.Count; i++)
                {
                    Film s = db.FilmSet.Find(dgvList.SelectedRows[i].Cells[0].Value);
                    List<Session> ses = s.Session.ToList();
                    foreach (Session x in ses)
                    {//удаляем все сеансы данного фильма
                        List<Seat> se = x.Seat.ToList();
                        foreach (Seat y in se)
                        {//удаляем все места данного сеанса
                            Ticket z;
                            if (y.Ticket != null)
                            {//удаляем билеты, если есть
                                z = y.Ticket;
                                db.TicketSet.Remove(z);
                            }
                            Booking r;
                            if (y.Booking != null)
                            {//удаляем брони, если есть
                                r = y.Booking;
                                db.BookingSet.Remove(r);
                            }
                            db.SeatSet.Remove(y);
                        }
                        db.SessionSet.Remove(x);
                    }
                    db.FilmSet.Remove(s);
                }
                db.SaveChanges();
                UpdateFilms();
            }
        }
        private void DeleteCinema()
        {
            Cinema s = db.CinemaSet.Find(dgvList.SelectedRows[0].Cells[0].Value);
            if (!s.Deleted)
            {
                DialogResult dialogResult = MessageBox.Show("Кинотеатр и все его залы будут помечены, как удаленные, пользователи не смогут их увидеть. Вы сможете вернуть его в любое время. Однако все сеансы и кассиры в данном кинотеатре будут удалены безвозвратно. Возможно, на них были куплены билеты! Вы действительно хотите удалить кинотеатр? ", "Удаление кинотеатра", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<Hall> h = s.Hall.ToList();
                    foreach (Hall x in h)
                    {//удаляем все кинотеатры данного фильма 
                        List<Session> ses = x.Session.ToList();
                        foreach (Session y in ses)
                        {
                            DeleteSession(y.ID);
                        }
                        db.HallSet.Find(x.ID).Deleted = true;
                    }
                    List<Сashier> c = s.Сashier.ToList();
                    foreach (Сashier x in c)
                    {
                        db.СashierSet.Remove(x);
                    }
                    db.CinemaSet.Find(s.ID).Deleted = true;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Кинотеатр и все его залы будут восстановлены, пользователи смогут их увидеть. Вы уверены, что хотите восстановить кинотеатр?", "Восстановление кинотеатра", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (Hall x in s.Hall)
                    {//восстанавливаем все кинотеатры данного фильма 
                        db.HallSet.Find(x.ID).Deleted = false;
                    }
                    db.CinemaSet.Find(s.ID).Deleted = false;
                }
            }
            db.SaveChanges();
            UpdateCinema();
            Information();
        }
        private void DeleteHall()
        {
            Hall s = db.HallSet.Find(dgvList.SelectedRows[0].Cells[0].Value);
            if (!s.Deleted)
            {
                DialogResult dialogResult = MessageBox.Show("Зал будет помечен, как удаленный, пользователи не смогут его увидеть. Вы сможете вернуть его в любое время. Однако все сеансы будут удалены безвозвратно. Возможно, на них были куплены билеты! Вы действительно хотите удалить зал? ", "Удаление зала", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    List<Session> h = s.Session.ToList();
                    foreach (Session x in h)
                    {//удаляем все сеансы                  
                        DeleteSession(x.ID);
                    }
                    db.HallSet.Find(s.ID).Deleted = true;
                }
            }
            else
            {
                if (!s.Cinema.Deleted)
                {
                    DialogResult dialogResult = MessageBox.Show("Зал будет восстановлен. Посльзователи смогут его увидеть. Вы уверены, что хотите восстановить зал?", "Восстановление зала", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.HallSet.Find(s.ID).Deleted = false;
                    }
                }
                else MessageBox.Show("Зал не может быть восстановлен, так как удален кинотеатр. Сначала восстановите кинотеатр!");
            }
            db.SaveChanges();
            UpdateHall();
            Information();
        }
        public void DeleteSession(Int16 ID)
        {
            List<Seat> se = db.SessionSet.Find(ID).Seat.ToList();
            foreach (Seat z in se)
            {
                //удаляем все места данного сеанса
                Ticket t;
                if (z.Ticket != null)
                {//удаляем билеты, если есть
                    t = z.Ticket;
                    db.TicketSet.Remove(t);
                }
                Booking r;
                if (z.Booking != null)
                {//удаляем брони, если есть
                    r = z.Booking;
                    db.BookingSet.Remove(r);
                }
                db.SeatSet.Remove(z);
            }
            db.SessionSet.Remove(db.SessionSet.Find(ID));
        }
        private void DeleteSessions()
        {
            DialogResult dialogResult = MessageBox.Show("Сеансы будут удалены безвозвратно. Вы действительно хотите удалить сеансы?", "Удаление сеанса", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                for (int i = 0; i < dgvList.SelectedRows.Count; i++)
                {
                    Session s = db.SessionSet.Find(dgvList.SelectedRows[i].Cells[0].Value);
                    DeleteSession(s.ID);
                }
            db.SaveChanges();
            UpdateCashier();
        }
        private void DeleteCashier()
        {
            DialogResult dialogResult = MessageBox.Show("Кассиры будут удалены безвозвратно, также им будет закрыт доступ к системе. Вы действительно хотите удалить кассиров?", "Удаление кассира", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
                for (int i = 0; i < dgvList.SelectedRows.Count; i++)
                {
                    Сashier s = db.СashierSet.Find(dgvList.SelectedRows[i].Cells[0].Value);
                    db.СashierSet.Remove(s);
                }
            db.SaveChanges();
            UpdateCashier();
        }
        private void dgvList_Click(object sender, EventArgs e)
        {
            Information();
        }
        public void Information()
        {
            btDelete.Text = "Удалить";
            if (NowEnt == eEntity.Фильм)
            {
                if ((user != eUser.Админ) && (db.FilmSet.Count() > 0) && (dgvList.SelectedRows.Count > 0))
                {
                    pbPoster.Image = Image.FromFile(db.FilmSet.Find(dgvList.SelectedRows[0].Cells[0].Value).Poster);
                    tbInfo.Text = db.FilmSet.Find(dgvList.SelectedRows[0].Cells[0].Value).Description;
                }
            }
            if ((NowEnt == eEntity.Кинотеатр) && (dgvList.SelectedRows.Count > 0))
            {
                if ((user == eUser.Админ) && (db.CinemaSet.Find(dgvList.SelectedRows[0].Cells[0].Value).Deleted)) btDelete.Text = "Восстановить";
                else if (user == eUser.Админ) btDelete.Text = "Удалить";
            }
            if ((NowEnt == eEntity.Зал) && (dgvList.SelectedRows.Count > 0))
            {
                if ((user == eUser.Админ) && (db.HallSet.Find(dgvList.SelectedRows[0].Cells[0].Value).Deleted)) btDelete.Text = "Восстановить";
                else if (user == eUser.Админ) btDelete.Text = "Удалить";
            }
            if ((NowEnt == eEntity.Сеанс) && (dgvList.SelectedRows.Count == 1))
            {
                if (user != eUser.Админ)
                {
                    btSession.Enabled = true;
                    //здесь должна быть кратинка мест
                }
            }
        }

        private void btChange_Click(object sender, EventArgs e)
        {
            if (dgvList.SelectedRows.Count == 1)
            {
                if (NowEnt == eEntity.Фильм)
                {
                    form = new AddFilm(this, false, db.FilmSet.Find(dgvList.SelectedRows[0].Cells[0].Value));
                }
                if (NowEnt == eEntity.Кинотеатр)
                {
                    form = new AddCinema(this, false, db.CinemaSet.Find(dgvList.SelectedRows[0].Cells[0].Value));
                }
                if (NowEnt == eEntity.Кассир)
                {
                    form = new AddСashier(this, false, db.СashierSet.Find(dgvList.SelectedRows[0].Cells[0].Value));
                }
                if (NowEnt == eEntity.Зал)
                {
                    form = new AddHall(this, false, db.HallSet.Find(dgvList.SelectedRows[0].Cells[0].Value));
                }
                if (NowEnt == eEntity.Сеанс)
                {
                    form = new AddSession(this, false, db.SessionSet.Find(dgvList.SelectedRows[0].Cells[0].Value));
                }
                form.Show();
            }
            else MessageBox.Show("Выберите один элемент!");
        }

        private void btSession_Click(object sender, EventArgs e)
        {
            bool cash = false;
            if (user == eUser.Кассир)
                cash = true;
            form = new SessionSeats(this, db.SessionSet.Find(dgvList.SelectedRows[0].Cells[0].Value), cash);
            form.Show();
        }

        private void btExel_Click(object sender, EventArgs e)
        {
            SaveFileDialog exel = new SaveFileDialog();
            exel.InitialDirectory = "C: ";
            exel.Title = "Выгрузка отчета в Exel";
            exel.FileName = NowEnt.ToString();
            exel.Filter = "Excel files(2003)|*.xls|Excel files(2007)|*.xlsx";
            exel.DefaultExt = ".xlxs";

            Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Excel._Worksheet worksheet = null;

            worksheet = workbook.Sheets["Лист1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Name = "Список ";

            for (int i = 1; i <= dgvList.ColumnCount; i++)
            {
                worksheet.Cells[1, i] = dgvList.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                for (int j = 0; j < dgvList.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dgvList.Rows[i].Cells[j].Value.ToString();
                }
            }

            Col(worksheet, "A1", 15, 15);
            if (exel.ShowDialog() != DialogResult.Cancel)
            {
                workbook.SaveAs(exel.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            
            app.Quit();
            ReleaseOb(worksheet);
            ReleaseOb(workbook);
            ReleaseOb(app);           
        }
        public void Col(Microsoft.Office.Interop.Excel._Worksheet sheet, string start, int rows, int col)
        {
            Excel.Range r = sheet.get_Range(start, System.Reflection.Missing.Value);
            r = r.get_Resize(rows, col);
            r.Columns.AutoFit();
            ReleaseOb(r);
        }
        public void ReleaseOb(object ob)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ob);
                ob = null;
            }
            catch
            {
                ob = null;
            }
            finally
            {
                GC.Collect();
            }

        }

        public List<Film> SearchFilm(List<Film> f)
        {
            List<Film> result = new List<Film>();
            switch (cbAtr.Text)
            {
                case "Название":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result= (from d in f  where d.Name== tbEqv.Text select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Name != tbEqv.Text select d).ToList(); break; }
                        }
                        break;
                    }
                case "Год":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.Year == int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Year != int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case ">": { result = (from d in f where d.Year > int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "<": { result = (from d in f where d.Year < int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case ">=": { result = (from d in f where d.Year >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "<=": { result = (from d in f where d.Year <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                        }
                        break;
                    }
                case "Длительность":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.length == TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.length != TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                            case ">": { result = (from d in f where d.length > TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "<": { result = (from d in f where d.length < TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                            case ">=": { result = (from d in f where d.length >= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "<=": { result = (from d in f where d.length <= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                        }
                        break;
                    }
                case "Возрастное ограничение":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.AgeLimit== cbEqv.Text select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.AgeLimit != cbEqv.Text select d).ToList(); break; }
                        }
                        break;
                    }
                case "Продюссер":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.Producer == tbEqv.Text select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Producer == tbEqv.Text select d).ToList(); break; }
                        }
                        break;
                    }
            }
            return result;
        }
        public List<Cinema> SearchCinema(List<Cinema> f)
        {
            List<Cinema> result = new List<Cinema>();
            switch (cbAtr.Text)
            {
                case "Название":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.Name == tbEqv.Text select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Name != tbEqv.Text select d).ToList(); break; }
                        }
                        break;
                    }
                case "Адрес":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.Adress == tbEqv.Text select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Adress != tbEqv.Text select d).ToList(); break; }
                        }
                        break;
                    }
                case "Город":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.City == tbEqv.Text select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.City != tbEqv.Text select d).ToList(); break; }
                        }
                        break;
                    }
            }
            return result;
        }
        public List<Сashier> SearchCashier(List<Сashier> f)
        {
            List<Сashier> result = new List<Сashier>();
            switch (cbEnt.Text)
            {
                case "Кассир":
                    {
                        switch (cbAtr.Text)
                        {
                            case "ФИО":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.FIO== tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.FIO != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Логин":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Login == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Login != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Кинотеатр":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Название":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.Name == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.Name != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Адрес":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.Adress == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.Adress != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Город":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.City == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.City != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
            return result;
        }
        public List<Hall> SearchHall(List<Hall> f)
        {
            List<Hall> result = new List<Hall>();
            switch (cbEnt.Text)
            {
                case "Зал":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Номер":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Num == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Num != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Num > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Num < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Num >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Num <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Тип":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Type == cbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Type != cbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество рядов":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.AmountOfRow == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.AmountOfRow != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.AmountOfRow > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.AmountOfRow < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.AmountOfRow >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.AmountOfRow <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество мест в ряду":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.AmountOfSeats == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.AmountOfSeats != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.AmountOfSeats > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.AmountOfSeats < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.AmountOfSeats >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.AmountOfSeats <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Кинотеатр":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Название":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.Name == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.Name != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Адрес":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.Adress == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.Adress != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Город":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.City == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.City != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
            return (result);
        }
        public List<Session> SearchSession(List<Session> f)
        {
            List<Session> result = new List<Session>();
            switch (cbEnt.Text)
            {
                case "Зал":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Номер":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Num == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Num != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Hall.Num > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Hall.Num < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Hall.Num >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Hall.Num <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Тип":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Type == cbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Type != cbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество рядов":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Hall.AmountOfRow == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.AmountOfRow != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Hall.AmountOfRow > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Hall.AmountOfRow < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Hall.AmountOfRow >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Hall.AmountOfRow <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество мест в ряду":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Hall.AmountOfSeats == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.AmountOfSeats != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Hall.AmountOfSeats > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Hall.AmountOfSeats < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Hall.AmountOfSeats >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Hall.AmountOfSeats <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Кинотеатр":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Название":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Cinema.Name == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Cinema.Name != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Адрес":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Cinema.Adress == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Cinema.Adress != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Город":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Cinema.City == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Cinema.City != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Фильм":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Название":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Film.Name == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.Name != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Год":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Film.Year == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.Year != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Film.Year > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Film.Year < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Film.Year >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Film.Year <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Длительность":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Film.length == TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.length != TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Film.length > TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Film.length < TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Film.length >= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Film.length <= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Возрастное ограничение":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Film.AgeLimit == cbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.AgeLimit != cbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Продюссер":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Film.Producer == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.Producer != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Сеанс":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Дата":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Time.Date == DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Time.Date != DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Time.Date > DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Time.Date < DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Time.Date >= DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Time.Date <= DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Цена":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Price == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Price != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Price > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Price < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Price >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Price <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Время":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Time.TimeOfDay == TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Time.TimeOfDay != TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Time.TimeOfDay > TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Time.TimeOfDay < TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Time.TimeOfDay >= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Time.TimeOfDay <= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
            return result;
        }
        public List<Ticket> SearchTicket(List<Ticket> f)
        {
            List<Ticket> result = new List<Ticket>();
            switch (cbEnt.Text)
            {
                case "Зал":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Номер":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Num == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Num != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.Num > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.Num < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.Num >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.Num <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Тип":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Type == cbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Type != cbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество рядов":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество мест в ряду":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Кинотеатр":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Название":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Name == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Name != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Адрес":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Adress == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Adress != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Город":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.City == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.City != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Фильм":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Название":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Name == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Name != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Год":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Year == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Year != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Film.Year > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Film.Year < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Film.Year >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Film.Year <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Длительность":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.length == TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.length != TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Film.length > TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Film.length < TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Film.length >= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Film.length <= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Возрастное ограничение":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.AgeLimit == cbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.AgeLimit != cbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Продюссер":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Producer == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Producer != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Сеанс":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Дата":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Time.Date == DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Time.Date != DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Time.Date > DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Time.Date < DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Time.Date >= DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Time.Date <= DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Цена":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Price == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Price != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Price > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Price < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Price >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Price <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Время":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay == TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay != TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Time.TimeOfDay > TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Time.TimeOfDay < TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay >= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay <= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Место":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Ряд":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.NumberOfRow == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.NumberOfRow != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.NumberOfRow > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.NumberOfRow < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.NumberOfRow >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.NumberOfRow <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Номер в ряду":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.NumberOfSeat == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.NumberOfSeat != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.NumberOfSeat > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.NumberOfSeat < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.NumberOfSeat >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.NumberOfSeat <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Билет":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.Number == int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Number != int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case ">": { result = (from d in f where d.Number > int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "<": { result = (from d in f where d.Number < int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case ">=": { result = (from d in f where d.Number >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "<=": { result = (from d in f where d.Number <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                        }
                        break;
                    }
            }
            return result;
        }
        public List<Booking> SearchBooking(List<Booking> f)
        {
            List<Booking> result = new List<Booking>();
            switch (cbEnt.Text)
            {
                case "Зал":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Номер":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Num == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Num != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.Num > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.Num < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.Num >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.Num <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Тип":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Type == cbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Type != cbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество рядов":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество мест в ряду":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Кинотеатр":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Название":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Name == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Name != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Адрес":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Adress == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Adress != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Город":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.City == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.City != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Фильм":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Название":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Name == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Name != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Год":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Year == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Year != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Film.Year > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Film.Year < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Film.Year >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Film.Year <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Длительность":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.length == TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.length != TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Film.length > TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Film.length < TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Film.length >= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Film.length <= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Возрастное ограничение":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.AgeLimit == cbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.AgeLimit != cbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Продюссер":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Producer == tbEqv.Text select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Producer != tbEqv.Text select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Сеанс":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Дата":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Time.Date == DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Time.Date != DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Time.Date > DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Time.Date < DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Time.Date >= DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Time.Date <= DateTime.Parse(tbEqv.Text).Date select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Цена":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Price == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Price != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Price > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Price < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Price >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Price <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Время":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay == TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay != TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Time.TimeOfDay > TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Time.TimeOfDay < TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay >= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay <= TimeSpan.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Место":
                    {
                        switch (cbAtr.Text)
                        {
                            case "Ряд":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.NumberOfRow == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.NumberOfRow != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.NumberOfRow > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.NumberOfRow < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.NumberOfRow >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.NumberOfRow <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Номер в ряду":
                                {
                                    switch (cbSign.Text)
                                    {
                                        case "=": { result = (from d in f where d.Seat.NumberOfSeat == int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.NumberOfSeat != int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.NumberOfSeat > int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.NumberOfSeat < int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.NumberOfSeat >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.NumberOfSeat <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Бронь":
                    {
                        switch (cbSign.Text)
                        {
                            case "=": { result = (from d in f where d.Number == int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Number != int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case ">": { result = (from d in f where d.Number > int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "<": { result = (from d in f where d.Number < int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case ">=": { result = (from d in f where d.Number >= int.Parse(tbEqv.Text) select d).ToList(); break; }
                            case "<=": { result = (from d in f where d.Number <= int.Parse(tbEqv.Text) select d).ToList(); break; }
                        }
                        break;
                    }
            }
            return result;
        }

        public void Search(bool ok)
        {//функция для многопараметрического поиска
            switch (NowEnt)
            {
                case eEntity.Фильм:
                    {
                        if (ok) { nowfilms = SearchFilm(nowfilms); }
                        else
                        {
                            films.AddRange(nowfilms);
                            nowfilms = db.FilmSet.ToList();
                            nowfilms = SearchFilm(nowfilms);
                        }
                        List<Film> vivod = new List<Film>();
                        vivod.AddRange(films);
                        vivod.AddRange(nowfilms);
                        dgvList.DataSource = (from d in vivod select new { d.ID, d.Name, d.Year, d.Producer, d.length, d.AgeLimit }).Distinct().ToList();
                        FilmsColomns();
                        dgvList.Update();
                        break;
                    }
                case eEntity.Сеанс:
                    {
                        if (ok) { nowsessions = SearchSession(nowsessions); }
                        else
                        {
                            sessions.AddRange(nowsessions);
                            nowsessions = db.SessionSet.ToList();
                            nowsessions = SearchSession(nowsessions);
                        }
                        List<Session> vivod = new List<Session>();
                        vivod.AddRange(sessions);
                        vivod.AddRange(nowsessions);
                        dgvList.DataSource = (from d in vivod where d.Time > DateTime.Now select new { d.ID, d.Time, d.Film.Name, d.Hall.Cinema.City, d.Hall.Cinema.Adress, d.Price, d.Hall.Num }).Distinct().ToList();
                        SessionColomns();
                        dgvList.Update();
                        break;
                    }
                case eEntity.Кинотеатр:
                    {
                        if (ok) { nowcinemas = SearchCinema(nowcinemas); }
                        else
                        {
                            cinemas.AddRange(nowcinemas);
                            nowcinemas = db.CinemaSet.ToList();
                            nowcinemas = SearchCinema(nowcinemas);
                        }
                        List<Cinema> vivod = new List<Cinema>();
                        vivod.AddRange(cinemas);
                        vivod.AddRange(nowcinemas);
                        if (user != eUser.Админ)
                            dgvList.DataSource = (from d in vivod where d.Deleted == false select new { d.ID, d.Name, d.City, d.Adress }).Distinct().ToList();
                        else dgvList.DataSource = (from d in vivod select new { d.ID, d.Name, d.City, d.Adress, d.Deleted }).Distinct().ToList();
                        CinemaColomns();
                        dgvList.Update();
                        break;
                    }
                case eEntity.Зал:
                    {
                        if (ok) { nowhalls = SearchHall(nowhalls); }
                        else
                        {
                            halls.AddRange(nowhalls);
                            nowhalls = db.HallSet.ToList();
                            nowhalls = SearchHall(nowhalls);
                        }
                        List<Hall> vivod = new List<Hall>();
                        vivod.AddRange(halls);
                        vivod.AddRange(nowhalls);
                        if (user != eUser.Админ)
                            dgvList.DataSource = (from d in vivod where d.Deleted == false select new { d.ID, d.Num, d.Cinema.Name, d.Cinema.City, d.Type, d.AmountOfRow, d.AmountOfSeats }).Distinct().ToList();
                        else dgvList.DataSource = (from d in vivod select new { d.ID, d.Num, d.Cinema.Name, d.Cinema.City, d.Type, d.AmountOfRow, d.AmountOfSeats, d.Deleted }).Distinct().ToList();
                        HallColomns();
                        dgvList.Update();
                        break;
                    }
                case eEntity.Кассир:
                    {
                        if (ok) { nowcashiers = SearchCashier(nowcashiers); }
                        else
                        {
                            cashiers.AddRange(nowcashiers);
                            nowcashiers = db.СashierSet.ToList();
                            nowcashiers = SearchCashier(nowcashiers);
                        }
                        List<Сashier> vivod = new List<Сashier>();
                        vivod.AddRange(cashiers);
                        vivod.AddRange(nowcashiers);
                        dgvList.DataSource = (from d in vivod select new { d.ID, d.FIO, d.Cinema.City, d.Cinema.Name, d.Login, d.Password }).Distinct().ToList();
                        CashierColomns();
                        dgvList.Update();
                        break;
                    }
                case eEntity.Билет:
                    {
                        if (ok) { nowtickets = SearchTicket(nowtickets); }
                        else
                        {
                            tickets.AddRange(nowtickets);
                            nowtickets = db.TicketSet.ToList();
                            nowtickets = SearchTicket(nowtickets);
                        }
                        List<Ticket> vivod = new List<Ticket>();
                        vivod.AddRange(tickets);
                        vivod.AddRange(nowtickets);
                        dgvList.DataSource = (from d in vivod select new { d.Number, d.Seat.NumberOfRow, d.Seat.NumberOfSeat, d.Seat.Session.Time, d.Seat.Session.Film.Name, d.Seat.Session.Hall.Num, d.Seat.Session.Hall.Cinema.Adress }).Distinct().ToList();
                        TBColomns();
                        dgvList.Update();
                        break;
                    }
                case eEntity.Бронь:
                    {
                        if (ok) { nowbookings = SearchBooking(nowbookings); }
                        else
                        {
                            bookings.AddRange(nowbookings);
                            nowbookings = db.BookingSet.ToList();
                            nowbookings = SearchBooking(nowbookings);
                        }
                        List<Booking> vivod = new List<Booking>();
                        vivod.AddRange(bookings);
                        vivod.AddRange(nowbookings);
                        dgvList.DataSource = (from d in vivod select new { d.Number, d.Seat.NumberOfRow, d.Seat.NumberOfSeat, d.Seat.Session.Time, d.Seat.Session.Film.Name, d.Seat.Session.Hall.Num, d.Seat.Session.Hall.Cinema.Adress }).Distinct().ToList();
                        TBColomns();
                        dgvList.Update();
                        break;
                    }
                default: { break; }
            }
        }

        private void cbAtr_TextChanged(object sender, EventArgs e)
        {
            if ((cbAtr.Text == "Год") || (cbAtr.Text == "Длительность") 
                || (cbAtr.Text == "Номер") || (cbAtr.Text == "Количество рядов") || (cbAtr.Text == "Количество мест в ряду")
                || (cbAtr.Text == "Дата") || (cbAtr.Text == "Цена") || (cbAtr.Text == "Время") || (cbAtr.Text == "Ряд")
                || (cbAtr.Text == "Номер в ряду"))
            {
                cbSign.Text = "=";
                string[] x = { "=", "!=", ">", "<", ">=", "<=" };
                cbSign.Items.Clear();
                cbSign.Items.AddRange(x);
            }
            else
            {
                cbSign.Text = "=";
                string[] x = { "=", "!="};
                cbSign.Items.Clear();
                cbSign.Items.AddRange(x);
            }
            if ((cbAtr.Text == "Возрастное ограничение")|| (cbAtr.Text == "Тип"))
            {
                tbEqv.Visible = false;
                cbEqv.Visible = true;
                switch (cbAtr.Text)
                {
                    case "Возрастное ограничение":
                        {
                            cbEqv.Text = "0+";
                            string[] x = { "0+", "6+", "12+", "16+", "18+" };
                            cbEqv.Items.Clear();
                            cbEqv.Items.AddRange(x);
                            break;
                        }
                    case "Тип":
                        {
                            cbEqv.Text = "2D";
                            string[] x = { "2D", "3D", "4D", "IMAX", "VIP" };
                            cbEqv.Items.Clear();
                            cbEqv.Items.AddRange(x);
                            break;
                        }
                }
            }
            else
            {
                tbEqv.Visible = true;
                cbEqv.Visible = false;
            }        
        }
        public bool ReadDate()
        {
            DateTime t = new DateTime();
            bool ok = DateTime.TryParse(cbEqv.Text, out t);
            if (!ok) MessageBox.Show("Неверный ввод!");
            return ok;
        }
        public bool ReadInt()
        {
            int i = new int();
            bool ok = int.TryParse(cbEqv.Text, out i);
            if (!ok) MessageBox.Show("Неверный ввод!");
            return ok;
        }

        private void cbEqv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btNewSearch_Click(object sender, EventArgs e)
        {
            ListNull();
            ListDB();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
