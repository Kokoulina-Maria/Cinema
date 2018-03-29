using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public class CashierWork
    {
        static CinemaModelContainer db = new CinemaModelContainer();
        /// <summary>
        /// Добавление кассира
        /// </summary>
        /// <param name="login"></param>
        /// <param name="FIO"></param>
        /// <param name="password"></param>
        /// <param name="cinema"></param>
        public static void Add(string login, string FIO, string password, Cinema cinema)
        {
            if (Cheack(login, true, 0))
            {
                Сashier c = new Сashier();
                c.FIO = FIO;
                c.Login = login;
                c.Password = password;
                c.Cinema = db.CinemaSet.Find(cinema.ID);
                db.СashierSet.Add(c);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Изменение кассира
        /// </summary>
        /// <param name="login"></param>
        /// <param name="FIO"></param>
        /// <param name="password"></param>
        /// <param name="ID"></param>
        public static void Change(string login, string FIO, string password, int ID)
        {
            if (Cheack(login, false,ID))
            {
                db.СashierSet.Find(ID).FIO = FIO;
                db.СashierSet.Find(ID).Login = login;
                db.СashierSet.Find(ID).Password = password;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Проверка на несоответствие данным в БД
        /// </summary>
        /// <param name="login"></param>
        /// <param name="add"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Cheack(string login, bool add, int ID)
        {
            bool ok = true;
            foreach (Сashier x in db.СashierSet)
            {
                if ((x.Login == login) && ((add) || (!add) && (ID != x.ID)))
                {
                    MessageBox.Show("Кассир с таким логином уже существует!");
                    ok = false;
                    break;
                }
            }
            if (login == "Admin")
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
                ok = false;
            }
            return ok;
        }
        /// <summary>
        /// Многопараметрический поиск кассира
        /// </summary>
        /// <param name="f"></param>
        /// <param name="ent"></param>
        /// <param name="atr"></param>
        /// <param name="sign"></param>
        /// <param name="eqv"></param>
        /// <returns></returns>
        public static List<Сashier> Find(List<Сashier> f, string ent, string atr, string sign, string eqv)
        {
            List<Сashier> result = new List<Сashier>();
            switch (ent)
            {
                case "Кассир":
                    {
                        switch (atr)
                        {
                            case "ФИО":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.FIO == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.FIO != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Логин":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Login == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Login != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Кинотеатр":
                    {
                        List<Cinema> cin = CinemaWork.Search(db.CinemaSet.ToList(), atr, sign, eqv);
                        List<Сashier> cash = new List<Сashier>();
                        foreach (Cinema x in cin)
                        {
                            cash.AddRange(x.Сashier);
                        }
                        result=(from d in f select d).Intersect(from a in cash select a).ToList();
                        break;
                    }
            }
            return result;
        }
    }
}
