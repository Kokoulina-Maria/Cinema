using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public class SessionWork
    {
        static CinemaModelContainer db = new CinemaModelContainer();
        public static void Add(Hall hall, DateTime date, Film film, short price)
        {
            if (Check(hall, date, true, 0))
            {
                Session c = new Session();
                c.Film = db.FilmSet.Find(film.ID);
                c.Hall = db.HallSet.Find(hall.ID);
                c.Price = price;
                c.Date = date;
                c.Time = date;
                db.SessionSet.Add(c);
                for (int i = 1; i <= c.Hall.AmountOfRow; i++)
                    for (int j = 1; j <= c.Hall.AmountOfSeats; j++)
                    {
                        SeatWork.Add(c.ID, (byte)i, (byte)j, db);
                    }
                db.SaveChanges();
            }
        }
        public static void Change(Hall hall, DateTime date, Film film, short price, int ID)
        {
            if (Check(hall, date, false, ID))
            {
                db.SessionSet.Find(ID).Film = db.FilmSet.Find(film.ID);
                db.SessionSet.Find(ID).Hall = db.HallSet.Find(hall.ID);
                db.SessionSet.Find(ID).Price = price;
                db.SessionSet.Find(ID).Date = date;
                db.SessionSet.Find(ID).Time = date;
                db.SaveChanges();
            }
        }
        public static bool Check(Hall hall, DateTime date, bool add, int ID)
        {
            bool ok=true;
            TimeSpan q = new TimeSpan(5, 0, 0);
            foreach (Session x in db.SessionSet)
            {
                if ((x.Hall == hall) && (x.Date == date.Date) && (x.Time.TimeOfDay <= date.TimeOfDay) && ((x.Time + q).TimeOfDay >= date.TimeOfDay) && ((add) || (!add) && (ID != x.ID)))
                {
                    MessageBox.Show("В данном зале в это время уже идет сеанс!");
                    ok = false;
                    break;
                }
                if (date <= DateTime.Now)
                {
                    MessageBox.Show("Вы не можете добавить сеанс, который уже начался!");
                    ok = false;
                    break;
                }
            }
            return ok;
        }
        public static void Delete(int ID, CinemaModelContainer DB)
        {
            List<Seat> se = DB.SessionSet.Find(ID).Seat.ToList();
            foreach (Seat z in se)
            {
                SeatWork.Delete(z.ID, DB);
            }
            DB.SessionSet.Remove(DB.SessionSet.Find(ID));
        }
        public static List<Session> Find(List<Session> f, string ent, string atr, string sign, string eqv, string eqv2)
        {
            List<Session> result = new List<Session>();
            switch (ent)
            {
                case "Зал":
                    {
                        switch (atr)
                        {
                            case "Номер":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Num == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Num != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Hall.Num > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Hall.Num < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Hall.Num >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Hall.Num <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Тип":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Type == eqv2 select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Type != eqv2 select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество рядов":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Hall.AmountOfRow == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.AmountOfRow != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Hall.AmountOfRow > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Hall.AmountOfRow < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Hall.AmountOfRow >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Hall.AmountOfRow <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество мест в ряду":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Hall.AmountOfSeats == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.AmountOfSeats != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Hall.AmountOfSeats > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Hall.AmountOfSeats < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Hall.AmountOfSeats >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Hall.AmountOfSeats <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Кинотеатр":
                    {
                        switch (atr)
                        {
                            case "Название":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Cinema.Name == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Cinema.Name != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Адрес":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Cinema.Adress == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Cinema.Adress != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Город":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Hall.Cinema.City == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Hall.Cinema.City != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Фильм":
                    {
                        switch (atr)
                        {
                            case "Название":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Film.Name == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.Name != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Год":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Film.Year == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.Year != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Film.Year > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Film.Year < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Film.Year >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Film.Year <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Длительность":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Film.length == TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.length != TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Film.length > TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Film.length < TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Film.length >= TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Film.length <= TimeSpan.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Возрастное ограничение":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Film.AgeLimit == eqv2 select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.AgeLimit != eqv2 select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Продюссер":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Film.Producer == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Film.Producer != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Сеанс":
                    {
                        switch (atr)
                        {
                            case "Дата":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Time.Date == DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Time.Date != DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Time.Date > DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Time.Date < DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Time.Date >= DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Time.Date <= DateTime.Parse(eqv).Date select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Цена":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Price == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Price != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Price > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Price < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Price >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Price <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Время":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Time.TimeOfDay == TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Time.TimeOfDay != TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Time.TimeOfDay > TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Time.TimeOfDay < TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Time.TimeOfDay >= TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Time.TimeOfDay <= TimeSpan.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
            }
            return result;
        }
    }
}
