using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public class FilmWork
    {
        static CinemaModelContainer db = new CinemaModelContainer();
        /// <summary>
        /// Добавление фильма
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="descrip"></param>
        /// <param name="time"></param>
        /// <param name="producer"></param>
        /// <param name="year"></param>
        /// <param name="poster"></param>
        public static void Add(string name, string age, string descrip, TimeSpan time, string producer, short year, string poster)
        {
            if (Check(name, true, 0))
            {
                db.FilmSet.Add(new Film { Name = name, AgeLimit = age, Description = descrip, length = time, Producer =producer, Year = year, Poster = poster });
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Редактирование фильма
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ID"></param>
        /// <param name="age"></param>
        /// <param name="descrip"></param>
        /// <param name="time"></param>
        /// <param name="producer"></param>
        /// <param name="year"></param>
        /// <param name="poster"></param>
        public static void Change(string name, int ID, string age, string descrip, TimeSpan time, string producer, short year, string poster)
        {
            if (Check(name, false, ID))
            {
                db.FilmSet.Find(ID).AgeLimit = age;
                db.FilmSet.Find(ID).Name = name;
                db.FilmSet.Find(ID).Description = descrip;
                db.FilmSet.Find(ID).length = time;
                db.FilmSet.Find(ID).Producer = producer;
                db.FilmSet.Find(ID).Year = year;
                if (poster != "")
                    db.FilmSet.Find(ID).Poster = poster;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Проверкана соответствие БД
        /// </summary>
        /// <param name="name"></param>
        /// <param name="add"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Check(string name, bool add, int ID)
        {
            bool ok = true;
            foreach (Film x in db.FilmSet)
            {
                if ((x.Name == name) && ((add) || (!add) && (ID != x.ID)))
                {
                    MessageBox.Show("Фильм с таким названием уже существует");
                    ok = false;
                    break;
                }
            }
            return ok;
        }
        /// <summary>
        /// Удаление фильма
        /// </summary>
        /// <param name="ID"></param>
        public static void Delete(int ID)
        {
            Film s = db.FilmSet.Find(ID);
            List<Session> ses = s.Session.ToList();
            foreach (Session x in ses)
            {//удаляем все сеансы данного фильма
                SessionWork.Delete(x.ID, db);
            }
            db.FilmSet.Remove(s);
            db.SaveChanges();
        }
        /// <summary>
        /// Многопараметрический поиск фильма
        /// </summary>
        /// <param name="f"></param>
        /// <param name="atr"></param>
        /// <param name="sign"></param>
        /// <param name="eqv"></param>
        /// <param name="eqv2"></param>
        /// <returns></returns>
        public static List<Film> Find(List<Film> f, string atr, string sign, string eqv, string eqv2)
        {
            List<Film> result = new List<Film>();
            switch (atr)
            {
                case "Название":
                    {
                        switch (sign)
                        {
                            case "=": { result = (from d in f where d.Name == eqv select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Name != eqv select d).ToList(); break; }
                        }
                        break;
                    }
                case "Год":
                    {
                        switch (sign)
                        {
                            case "=": { result = (from d in f where d.Year == int.Parse(eqv) select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Year != int.Parse(eqv) select d).ToList(); break; }
                            case ">": { result = (from d in f where d.Year > int.Parse(eqv) select d).ToList(); break; }
                            case "<": { result = (from d in f where d.Year < int.Parse(eqv) select d).ToList(); break; }
                            case ">=": { result = (from d in f where d.Year >= int.Parse(eqv) select d).ToList(); break; }
                            case "<=": { result = (from d in f where d.Year <= int.Parse(eqv) select d).ToList(); break; }
                        }
                        break;
                    }
                case "Длительность":
                    {
                        switch (sign)
                        {
                            case "=": { result = (from d in f where d.length == TimeSpan.Parse(eqv) select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.length != TimeSpan.Parse(eqv) select d).ToList(); break; }
                            case ">": { result = (from d in f where d.length > TimeSpan.Parse(eqv) select d).ToList(); break; }
                            case "<": { result = (from d in f where d.length < TimeSpan.Parse(eqv) select d).ToList(); break; }
                            case ">=": { result = (from d in f where d.length >= TimeSpan.Parse(eqv) select d).ToList(); break; }
                            case "<=": { result = (from d in f where d.length <= TimeSpan.Parse(eqv) select d).ToList(); break; }
                        }
                        break;
                    }
                case "Возрастное ограничение":
                    {
                        switch (sign)
                        {
                            case "=": { result = (from d in f where d.AgeLimit == eqv2 select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.AgeLimit != eqv2 select d).ToList(); break; }
                        }
                        break;
                    }
                case "Продюссер":
                    {
                        switch (sign)
                        {
                            case "=": { result = (from d in f where d.Producer == eqv select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Producer == eqv select d).ToList(); break; }
                        }
                        break;
                    }
            }
            return result;
        }
    }
}
