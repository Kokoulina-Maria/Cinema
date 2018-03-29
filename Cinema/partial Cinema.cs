using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public class CinemaWork
    {     
        static CinemaModelContainer db = new CinemaModelContainer();
        /// <summary>
        /// Добавление кинотеатра
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="adress"></param>
        public static void Add(string name, string city, string adress)
        {
            if (Check(name, city, adress, true, 0))
            {
                db.CinemaSet.Add(new Cinema { Name = name, City = city, Adress = adress });
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Редактирование кинотеатра
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="adress"></param>
        /// <param name="ID"></param>
        public static void Change(string name, string city, string adress, int ID)
        {
            if (Check(name, city, adress, false, ID))
            {
                DialogResult dialogResult = MessageBox.Show("Данные о кинотеатре будут сохранены. Вы уверены, что хотите изменить их?", "Сохранение изменений", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    db.CinemaSet.Find(ID).Name = name;
                    db.CinemaSet.Find(ID).City = city;
                    db.CinemaSet.Find(ID).Adress = adress;
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Проверка на соответствие БД
        /// </summary>
        /// <param name="name"></param>
        /// <param name="city"></param>
        /// <param name="adress"></param>
        /// <param name="add"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static bool Check(string name, string city, string adress, bool add, int ID)
        {
            bool ok = true;
            foreach (Cinema x in db.CinemaSet)
            {
                if ((x.City == city) && (x.Adress == adress) && ((add) || (!add) && (ID != x.ID)))
                {
                    MessageBox.Show("Кинотеатр по таком адресу уже существует!");
                    ok = false;
                    break;
                }
                if ((x.Name == name) && ((add) || (!add) && (ID != x.ID)))
                {
                    MessageBox.Show("Уже существует кинотеатр с таким названием!");
                    ok = false;
                    break;
                }
            }
            return ok;
        }
        /// <summary>
        /// Удаление кинотеатра
        /// </summary>
        /// <param name="ID"></param>
        public static void Delete(int ID)
        {          
            List<Hall> h = (db.CinemaSet.Find(ID)).Hall.ToList();
            foreach (Hall x in h)
            {//удаляем все кинотеатры данного фильма
                HallWork.Delete(x.ID);
            }
            List<Сashier> c = (db.CinemaSet.Find(ID)).Сashier.ToList();
            foreach (Сashier x in c)
            {
                db.СashierSet.Remove(x);
            }
            db.CinemaSet.Find(ID).Deleted = true;
            db.SaveChanges();
        }
        /// <summary>
        /// Восстановление кинотеатра
        /// </summary>
        /// <param name="ID"></param>
        public static void Restore(int ID)
        {
            foreach (Hall x in (db.CinemaSet.Find(ID)).Hall)
            {//восстанавливаем все кинотеатры данного фильма 
                HallWork.Restore(x.ID);
            }
            db.CinemaSet.Find((db.CinemaSet.Find(ID)).ID).Deleted = false;
            db.SaveChanges();
        }
        /// <summary>
        /// Многопараметрический поиск кинотеатра
        /// </summary>
        /// <param name="f"></param>
        /// <param name="atr"></param>
        /// <param name="sign"></param>
        /// <param name="eqv"></param>
        /// <returns></returns>
        public static List<Cinema> Search(List<Cinema> f, string atr, string sign, string eqv)
        {
            List<Cinema> result=null;
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
                case "Адрес":
                    {
                        switch (sign)
                        {
                            case "=": { result = (from d in f where d.Adress == eqv select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Adress != eqv select d).ToList(); break; }
                        }
                        break;
                    }
                case "Город":
                    {
                        switch (sign)
                        {
                            case "=": { result = (from d in f where d.City == eqv select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.City != eqv select d).ToList(); break; }
                        }
                        break;
                    }
            }
            return result;
        }

    }
}
