﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CinemaModelContainer : DbContext
    {
        public CinemaModelContainer()
            : base("name=CinemaModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Cinema> CinemaSet { get; set; }
        public DbSet<Film> FilmSet { get; set; }
        public DbSet<Session> SessionSet { get; set; }
        public DbSet<Hall> HallSet { get; set; }
        public DbSet<Сashier> СashierSet { get; set; }
        public DbSet<Seat> SeatSet { get; set; }
        public DbSet<Ticket> TicketSet { get; set; }
        public DbSet<Booking> BookingSet { get; set; }
    }
}