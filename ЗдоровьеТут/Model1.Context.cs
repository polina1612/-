﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ЗдоровьеТут
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class АптекаEntities : DbContext
    {
        private static АптекаEntities _context;
        public АптекаEntities()
            : base("name=АптекаEntities")
        {
        }
        public static АптекаEntities GetContext()
        {
            if (_context == null)
            {
                _context = new АптекаEntities();
            }
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Заказ> Заказ { get; set; }
        public virtual DbSet<Заказ_Товар> Заказ_Товар { get; set; }
        public virtual DbSet<Пользователь> Пользователь { get; set; }
        public virtual DbSet<Пункт_Выдачи> Пункт_Выдачи { get; set; }
        public virtual DbSet<Роль_пользователя> Роль_пользователя { get; set; }
        public virtual DbSet<Статус_заказа> Статус_заказа { get; set; }
        public virtual DbSet<Товар> Товар { get; set; }
    }
}
