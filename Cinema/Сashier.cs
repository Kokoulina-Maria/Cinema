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
    
    public partial class Сashier : IComparable, IEquatable<Сashier>
    {
        public string Login { get; set; }
        public string FIO { get; set; }
        public string Password { get; set; }
        public short ID { get; set; }
        public int CompareTo(Object obj)
        {
            Сashier x = obj as Сashier;
            if (ID > x.ID) return 1;
            else if (ID == x.ID) return 0;
            else return -1;
        }
        public bool Equals(Сashier other)
        {
            if (other == null) return false;
            if (ID == other.ID) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return ID;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            Сashier x = obj as Сashier;
            if (x == null) return false;
            else return Equals(x);
        }

        public virtual Cinema Cinema { get; set; }
    }
}
