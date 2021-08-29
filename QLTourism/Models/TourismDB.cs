using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLTourism.Models
{
    public partial class TourismDB : DbContext
    {
        public TourismDB()
            : base("name=TourismTu")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customers_Rewards> Customers_Rewards { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Program> Programs { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.News)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Customers_Rewards)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Medium>()
                .Property(e => e.path)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.thumbail)
                .IsUnicode(false);

            modelBuilder.Entity<Package>()
                .Property(e => e.thumbail)
                .IsUnicode(false);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.Media)
                .WithRequired(e => e.Package)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reward>()
                .HasMany(e => e.Customers_Rewards)
                .WithRequired(e => e.Reward)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.imagePath)
                .IsUnicode(false);

            modelBuilder.Entity<Slider>()
                .Property(e => e.urlPath)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.avatar)
                .IsUnicode(false);
        }
    }
}
