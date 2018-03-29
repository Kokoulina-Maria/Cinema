using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class TicketWork
    {
        static CinemaModelContainer db = new CinemaModelContainer();
        /// <summary>
        /// Многопараметрический поиск билета
        /// </summary>
        /// <param name="f"></param>
        /// <param name="ent"></param>
        /// <param name="atr"></param>
        /// <param name="sign"></param>
        /// <param name="eqv"></param>
        /// <param name="eqv2"></param>
        /// <returns></returns>
        public static List<Ticket> Find(List<Ticket> f, string ent, string atr, string sign, string eqv, string eqv2)
        {
            List<Ticket> result = new List<Ticket>();
            switch (ent)
            {
                case "Место":
                    {
                        switch (atr)
                        {
                            case "Ряд":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.NumberOfRow == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.NumberOfRow != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.NumberOfRow > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.NumberOfRow < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.NumberOfRow >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.NumberOfRow <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Номер в ряду":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.NumberOfSeat == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.NumberOfSeat != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.NumberOfSeat > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.NumberOfSeat < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.NumberOfSeat >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.NumberOfSeat <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case "Билет":
                    {
                        switch (sign)
                        {
                            case "=": { result = (from d in f where d.Number == int.Parse(eqv) select d).ToList(); break; }
                            case "!=": { result = (from d in f where d.Number != int.Parse(eqv) select d).ToList(); break; }
                            case ">": { result = (from d in f where d.Number > int.Parse(eqv) select d).ToList(); break; }
                            case "<": { result = (from d in f where d.Number < int.Parse(eqv) select d).ToList(); break; }
                            case ">=": { result = (from d in f where d.Number >= int.Parse(eqv) select d).ToList(); break; }
                            case "<=": { result = (from d in f where d.Number <= int.Parse(eqv) select d).ToList(); break; }
                        }
                        break;
                    }
                default:
                    {
                        List<Session> cin = SessionWork.Find(db.SessionSet.ToList(), ent, atr, sign, eqv, eqv2);
                        List<Ticket> cash = new List<Ticket>();
                        foreach (Session x in cin)
                        {
                            foreach (Seat y in x.Seat)
                                if (y.Ticket != null)
                                    cash.Add(y.Ticket);
                        }
                        result = (from d in f select d).Intersect(from a in cash select a).ToList();
                        break;
                    }
            }
            return result;
        }
    }
}
