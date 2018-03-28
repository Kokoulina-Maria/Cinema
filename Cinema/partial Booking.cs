using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    public class BookingWork
    {
        public static List<Booking> Find(List<Booking> f, string ent, string atr, string sign, string eqv, string eqv2)
        {
            List<Booking> result = new List<Booking>();
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
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Num == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Num != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.Num > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.Num < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.Num >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.Num <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Тип":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Type == eqv2 select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Type != eqv2 select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество рядов":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.AmountOfRow <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Количество мест в ряду":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Hall.AmountOfSeats <= int.Parse(eqv) select d).ToList(); break; }
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
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Name == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Name != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Адрес":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Adress == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.Adress != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Город":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Hall.Cinema.City == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Hall.Cinema.City != eqv select d).ToList(); break; }
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
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Name == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Name != eqv select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Год":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Year == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Year != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Film.Year > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Film.Year < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Film.Year >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Film.Year <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Длительность":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.length == TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.length != TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Film.length > TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Film.length < TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Film.length >= TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Film.length <= TimeSpan.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Возрастное ограничение":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.AgeLimit == eqv2 select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.AgeLimit != eqv2 select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Продюссер":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Film.Producer == eqv select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Film.Producer != eqv select d).ToList(); break; }
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
                                        case "=": { result = (from d in f where d.Seat.Session.Time.Date == DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Time.Date != DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Time.Date > DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Time.Date < DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Time.Date >= DateTime.Parse(eqv).Date select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Time.Date <= DateTime.Parse(eqv).Date select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Цена":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Price == int.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Price != int.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Price > int.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Price < int.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Price >= int.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Price <= int.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                            case "Время":
                                {
                                    switch (sign)
                                    {
                                        case "=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay == TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "!=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay != TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case ">": { result = (from d in f where d.Seat.Session.Time.TimeOfDay > TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "<": { result = (from d in f where d.Seat.Session.Time.TimeOfDay < TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case ">=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay >= TimeSpan.Parse(eqv) select d).ToList(); break; }
                                        case "<=": { result = (from d in f where d.Seat.Session.Time.TimeOfDay <= TimeSpan.Parse(eqv) select d).ToList(); break; }
                                    }
                                    break;
                                }
                        }
                        break;
                    }
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
                case "Бронь":
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
            }
            return result;
        }
    }
}
