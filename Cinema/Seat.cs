//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cinema
{
    using System;
    using System.Collections.Generic;
    
    public partial class Seat
    {
        public byte NumberOfRow { get; set; }
        public byte NumberOfSeat { get; set; }
        public string State { get; set; }
        public long ID { get; set; }
    
        public virtual Session Session { get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
