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
                        switch (atr)
                        {
                            case "Название":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.Name == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.Name != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Адрес":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.Adress == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.Adress != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Город":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Cinema.City == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Cinema.City != eqv select d).ToList(); break; }
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
