using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public class SeatWork
    {       
        public static void Add(int ID, byte i, byte j, CinemaModelContainer DB)
        {
            Seat s = new Seat();
            s.Session = DB.SessionSet.Find(ID);
            s.State = "Свободно";
            s.NumberOfRow = i;
            s.NumberOfSeat = j;
            DB.SeatSet.Add(s);
        }
        public static void Delete(Int64 ID, CinemaModelContainer DB)
        {
            //удаляем все места данного сеанса
            Ticket t;
            if (DB.SeatSet.Find(ID).Ticket != null)
            {//удаляем билеты, если есть
             t = (DB.SeatSet.Find(ID)).Ticket;
             DB.TicketSet.Remove(t);
            }
            Booking r;
            if ((DB.SeatSet.Find(ID)).Booking != null)
            {//удаляем брони, если есть
             r = (DB.SeatSet.Find(ID)).Booking;
             DB.BookingSet.Remove(r);
            }
            DB.SeatSet.Remove(DB.SeatSet.Find(ID));
        }
    }
}
