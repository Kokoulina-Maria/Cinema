using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class HallWork
    {
        static CinemaModelContainer db = new CinemaModelContainer();
        /// <summary>
        /// Добавление зала
        /// </summary>
        /// <param name="cinema"></param>
        /// <param name="num"></param>
        /// <param name="type"></param>
        /// <param name="rows"></param>
        /// <param name="seats"></param>
        public static void Add(Cinema cinema, byte num,  string type, byte rows, byte seats)
        {
            if (Check(cinema, num, true, 0))
            {
                Hall c = new Hall();
                c.Num = num;
                c.Type = type;
                c.AmountOfRow = rows;
                c.AmountOfSeats = seats;
                c.Cinema = db.CinemaSet.Find(cinema.ID);
                db.HallSet.Add(c);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Редактирование зала
        /// </summary>
        /// <param name="cinema"></param>
        /// <param name="num"></param>
        /// <param name="type"></param>
        /// <param name="rows"></param>
        /// <param name="seats"></param>
        /// <param name="ID"></param>
        public static void Change(Cinema cinema, byte num, string type, byte rows, byte seats, int ID)
        {
            if (Check(cinema, num, false, ID))
            {
                DialogResult dialogResult = MessageBox.Show("Данные о зале будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    db.HallSet.Find(ID).Num = num;
                    db.HallSet.Find(ID).Type = type;
                    db.HallSet.Find(ID).AmountOfRow = rows;
                    db.HallSet.Find(ID).AmountOfSeats = seats;
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Изменение зала
        /// </summary>
        /// <param name="cinema"></param>
        /// <param name="num"></param>
        /// <param name="add"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Check(Cinema cinema, int num, bool add, int ID)
        {
            bool ok = true;
            foreach (Hall x in db.HallSet)
            {
                if ((x.Cinema.Name == (cinema.Name)) && (x.Num == num) && ((add) || (!add) && (ID != x.ID)))
                {
                    MessageBox.Show("В данном кинотеатре уже есть зал с таким номером!");
                    ok = false;
                    break;
                }
            }
            return ok;
        }
        /// <summary>
        /// Удаление зала
        /// </summary>
        /// <param name="ID"></param>
        public static void Delete(int ID)
        {
            List<Session> h = (db.HallSet.Find(ID)).Session.ToList();
            foreach (Session x in h)
            {//удаляем все сеансы                  
                SessionWork.Delete(x.ID, db);
            }
            db.HallSet.Find(ID).Deleted = true;
            db.SaveChanges();
        }
        /// <summary>
        /// Восстановление зала
        /// </summary>
        /// <param name="ID"></param>
        public static void Restore(int ID)
        {
            db.HallSet.Find(ID).Deleted = false;
            db.SaveChanges();
        }
        /// <summary>
        /// Многопараметрический поиск зала
        /// </summary>
        /// <param name="f"></param>
        /// <param name="ent"></param>
        /// <param name="atr"></param>
        /// <param name="sign"></param>
        /// <param name="eqv"></param>
        /// <param name="eqv2"></param>
        /// <returns></returns>
        public static List<Hall> Search(List<Hall> f, string ent, string atr, string sign, string eqv, string eqv2)
        {
            List<Hall> result = new List<Hall>();
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
                                        case "=": { result = (from d in f where d.Num == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Num != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Num > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Num < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Num >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Num <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Тип":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Type == eqv2 select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Type != eqv2 select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество рядов":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.AmountOfRow == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.AmountOfRow != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.AmountOfRow > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.AmountOfRow < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.AmountOfRow >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.AmountOfRow <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество мест в ряду":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.AmountOfSeats == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.AmountOfSeats != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.AmountOfSeats > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.AmountOfSeats < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.AmountOfSeats >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.AmountOfSeats <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Кинотеатр":
                    {
                        List<Cinema> cin = CinemaWork.Search(db.CinemaSet.ToList(), atr, sign, eqv);
                        List<Hall> cash = new List<Hall>();
                        foreach (Cinema x in cin)
                        {
                            cash.AddRange(x.Hall);
                        }
                        result = (from d in f select d).Intersect(from a in cash select a).ToList();
                        break;
                    }
            }
            return (result);
        }
    }
}
