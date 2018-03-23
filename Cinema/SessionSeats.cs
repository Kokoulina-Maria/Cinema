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
    public partial class SessionSeats : Form
    {
        public Graphics picture;                                                              //Графика
        public Bitmap seats;
        public CinemaModelContainer db = new CinemaModelContainer();
        public bool cashier;
        public Session session;
        Form1 form;
        bool made = false;
        public List<Seat> choose=new List<Seat>();
        int min;
        public SessionSeats(Form1 forma, Session x, bool cash)
        {
            InitializeComponent();
            form = forma;
            form.Enabled = false;
            cashier = cash;
            session = x;
            texts();
            UploadPicture();
        }
        public void texts()
        {
            nudRow.Maximum = session.Hall.AmountOfRow;
            nudSeat.Maximum = session.Hall.AmountOfSeats;
            if (cashier)
            {
                btBuy.Text = "Занято";
                btBook.Text = "Забронировано";
                btFree.Text = "Свободно";
            }
        }
        public void But()
        {
            btBuy.Enabled = true;
            btBook.Enabled = true;
            btFree.Enabled = true;
            btCancel.Enabled = true;
        }
        public void NotBut()
        {
            btBuy.Enabled = false;
            btBook.Enabled = false;
        }
        public void UploadPicture()
        {
            
            seats = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //Создаем Bitmap
            picture = Graphics.FromImage(seats);
            picture.Clear(Color.White);
            int h = pictureBox1.Height / (session.Hall.AmountOfRow+2);//размер части в высоте
            int w = pictureBox1.Width / (session.Hall.AmountOfSeats + 2);//размер части в ширине
            //находим размер места
            min = h;
            if (w < h) min = w;
            //выводим на экран надпись

            //Координата начала
            int ist = (pictureBox1.Height - min * session.Hall.AmountOfRow) / 2;
            int jst = (pictureBox1.Width - min * session.Hall.AmountOfSeats) / 2;
            Rectangle ecran = new Rectangle(jst, 0, min * session.Hall.AmountOfSeats, min);
            picture.FillRectangle(Brushes.Gray, ecran);
            for (int i=1; i<= session.Hall.AmountOfRow; i++)
            {
                Rectangle ini = new Rectangle(0,ist, (pictureBox1.Width - min * session.Hall.AmountOfSeats) / 2, (pictureBox1.Height - min * session.Hall.AmountOfRow) / 2);                
                picture.DrawString(i.ToString(), new Font("Arial", 14), Brushes.Black, ini);
                ist = ist + min;
            }
            for (int j=1; j<=session.Hall.AmountOfSeats; j++)
            {
                Rectangle inj = new Rectangle(jst, pictureBox1.Height-(pictureBox1.Height - min * session.Hall.AmountOfRow) / 2, (pictureBox1.Width - min * session.Hall.AmountOfSeats) / 2, (pictureBox1.Height - min * session.Hall.AmountOfRow) / 2);
                picture.DrawString(j.ToString(), new Font("Arial", 14), Brushes.Black, inj);
                jst = jst + min;
            }
            for (int i=1; i<= session.Hall.AmountOfRow; i++)
                for(int j=1; j<=session.Hall.AmountOfSeats; j++)
                {
                    List<Seat> a = new List<Seat>();
                    foreach (Seat d in db.SessionSet.Find(session.ID).Seat)
                        if ((d.NumberOfRow == i) && (d.NumberOfSeat == j))
                        {
                            a.Add(d);
                            break;
                        }
                    if (a[0].State == "Свободно") DrawSeat(i, j, new SolidBrush(Color.Green));
                    if (a[0].State == "Занято") DrawSeat(i, j, new SolidBrush(Color.Red));
                    if (a[0].State=="Забронировано") DrawSeat(i, j, new SolidBrush(Color.Yellow));
                }
        }
        public void DrawSeat(int i, int j, Brush brush)
        {
            Pen pen = new Pen(Color.White, 2);
            int ist = (pictureBox1.Height - min * session.Hall.AmountOfRow) / 2 + min * (i-1);
            int jst = (pictureBox1.Width - min * session.Hall.AmountOfSeats) / 2 + min * (j-1);
            picture.FillRectangle(brush, jst, ist, min, min);
            picture.DrawRectangle(pen, jst, ist, min, min);
            pictureBox1.Image = seats;
        }

        private void btChoice_Click(object sender, EventArgs e)
        {
            if (made) choose.Clear();
            
            //выбрали место
            List<Seat> a = new List<Seat>();
            foreach (Seat d in db.SessionSet.Find(session.ID).Seat)
                if ((d.NumberOfRow == nudRow.Value) && (d.NumberOfSeat == nudSeat.Value))
                {
                    a.Add(d);
                    break;
                }
            if ((!cashier) && (a[0].State != "Свободно"))
            {
                MessageBox.Show("Данное место уже занято");
            }
            else
            {
                choose.Add(a[0]);//добавили его в список выбранных мест
                choose = (from d in choose select d).Distinct().ToList(); ;
                DrawSeat(a[0].NumberOfRow, a[0].NumberOfSeat, new SolidBrush(Color.Blue));
                made = false;
                But();

            }
            label3.Text = ("Итого: " + choose.Count * session.Price + " руб");
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (choose.Count > 0) choose.RemoveAt(choose.Count - 1);
            UploadPicture();
        }

        private void btBuy_Click(object sender, EventArgs e)
        {
            if (choose.Count > 0)
            {
                if (!cashier)
                {
                    string tick = "";
                    made = true;
                    foreach (Seat d in choose)
                    {
                        Ticket t = new Ticket();
                        t.Seat = db.SeatSet.Find(d.ID);
                        db.TicketSet.Add(t);
                        db.SeatSet.Find(d.ID).State = "Занято";
                        db.SaveChanges();
                        tick = tick + " " + db.SeatSet.Find(d.ID).Ticket.Number.ToString();
                    }
                    MessageBox.Show("Номера ваших билетов: " + tick + ". Запомните или запишите их и предъявите на кассе.");
                }
                else
                {
                    made = true;
                    foreach (Seat d in choose)
                    {
                        db.SeatSet.Find(d.ID).State = "Занято";
                        Booking r;
                        if (d.Booking != null)
                        {//удаляем брони, если есть
                            r = d.Booking;
                            db.BookingSet.Remove(r);
                        }
                        Ticket z;
                        if (d.Ticket != null)
                        {//удаляем билеты, если есть
                            z = d.Ticket;
                            db.TicketSet.Remove(z);
                        }
                    }
                }
                db.SaveChanges();
                UploadPicture();
                NotBut();
            }
        }

        private void btBook_Click(object sender, EventArgs e)
        {
            if (choose.Count > 0)
            {
                if (!cashier)
                {
                    string book = "";
                    made = true;
                    foreach (Seat d in choose)
                    {
                        Booking t = new Booking();
                        t.Seat = db.SeatSet.Find(d.ID);
                        db.BookingSet.Add(t);
                        db.SeatSet.Find(d.ID).State = "Забронировано";
                        db.SaveChanges();
                        book = book + " " + db.SeatSet.Find(d.ID).Booking.Number.ToString();
                    }
                    MessageBox.Show("Номера вашей брони: " + book + ". Запомните или запишите их и предъявите на кассе не позднее, чем за 40 минут до начала сеанса");
                }
                else
                {
                    made = true;
                    foreach (Seat d in choose)
                    {
                        db.SeatSet.Find(d.ID).State = "Забронировано";
                        Ticket z;
                        if (d.Ticket != null)
                        {//удаляем билеты, если есть
                            z = d.Ticket;
                            db.TicketSet.Remove(z);
                        }
                        Booking r;
                        if (d.Booking != null)
                        {//удаляем брони, если есть
                            r = d.Booking;
                            db.BookingSet.Remove(r);
                        }
                    }
                }
                db.SaveChanges();
                UploadPicture();
                NotBut();
            }
        }

        private void btFree_Click(object sender, EventArgs e)
        {
            foreach (Seat d in choose)
            {
                made = true;
                Ticket z;
                if (d.Ticket != null)
                {//удаляем билеты, если есть
                    z = d.Ticket;
                    db.TicketSet.Remove(z);
                }
                Booking r;
                if (d.Booking != null)
                {//удаляем брони, если есть
                    r = d.Booking;
                    db.BookingSet.Remove(r);
                }
                db.SeatSet.Find(d.ID).State = "Свободно";                
            }
            db.SaveChanges();
            UploadPicture();
        }

        private void SessionSeats_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.Enabled = true;
        }
    }
}
