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
        /// <summary>
        /// Добавление сеанса
        /// </summary>
        /// <param name="hall"></param>
        /// <param name="date"></param>
        /// <param name="film"></param>
        /// <param name="price"></param>
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
                db.SaveChanges();
                for (int i = 1; i <= c.Hall.AmountOfRow; i++)
                    for (int j = 1; j <= c.Hall.AmountOfSeats; j++)
                    {
                        SeatWork.Add(c.ID, (byte)i, (byte)j, db);
                    }
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Редактирование сеанса
        /// </summary>
        /// <param name="hall"></param>
        /// <param name="date"></param>
        /// <param name="film"></param>
        /// <param name="price"></param>
        /// <param name="ID"></param>
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
        /// <summary>
        /// Изменение сеанса
        /// </summary>
        /// <param name="hall"></param>
        /// <param name="date"></param>
        /// <param name="add"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Check(Hall hall, DateTime date, bool add, int ID)
        {
            bool ok=true;
            TimeSpan q = new TimeSpan(4, 0, 0);
            foreach (Session x in db.SessionSet)
            {
                if ((x.Hall.Cinema.Name==hall.Cinema.Name)&&(x.Hall.Num == hall.Num) && ((x.Time <= date) && ((x.Time + q) >= date)|| (x.Time >= date) && ((date + q) >= x.Time)) && ((add) || (!add) && (ID != x.ID)))
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
        /// <summary>
        /// Проверка совместимости с БД
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="DB"></param>
        public static void Delete(int ID, CinemaModelContainer DB)
        {
            List<Seat> se = DB.SessionSet.Find(ID).Seat.ToList();
            foreach (Seat z in se)
            {
                SeatWork.Delete(z.ID, DB);
            }
            DB.SessionSet.Remove(DB.SessionSet.Find(ID));
        }
        /// <summary>
        /// Многопараметрический поиск Сеанса
        /// </summary>
        /// <param name="f"></param>
        /// <param name="ent"></param>
        /// <param name="atr"></param>
        /// <param name="sign"></param>
        /// <param name="eqv"></param>
        /// <param name="eqv2"></param>
        /// <returns></returns>
        public static List<Session> Find(List<Session> f, string ent, string atr, string sign, string eqv, string eqv2)
        {
            List<Session> result = new List<Session>();
            switch (ent)
            {
                case "Фильм":
                    {
                        List<Film> cin = FilmWork.Find(db.FilmSet.ToList(), atr, sign, eqv, eqv2);
                        List<Session> cash = new List<Session>();
                        foreach (Film x in cin)
                        {
                            cash.AddRange(x.Session);
                        }
                        result = (from d in f select d).Intersect(from a in cash select a).ToList();
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
                default:
                    {
                        List<Hall> cin = HallWork.Search(db.HallSet.ToList(), ent, atr, sign, eqv, eqv2);
                        List<Session> cash = new List<Session>();
                        foreach (Hall x in cin)
                        {
                            cash.AddRange(x.Session);
                        }
                        result = (from d in f select d).Intersect(from a in cash select a).ToList();
                        break;
                    }
            }
            return result;
        }
    }
}
