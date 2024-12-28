using Microsoft.EntityFrameworkCore;
using System;
using webprogramlama4.Data;

namespace webprogramlama4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Admin kullanıcısını seed olarak ekle
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 100, // Veritabanında otomatik id oluşturmayı devredışı bırakıyoruz
                    Username = "G211210041@sakarya.edu.tr",
                    Password = "sau", // Şifreyi düz metin olarak saklıyoruz (test amaçlı)
                    Email = "G211210041@sakarya.edu.tr",
                    CreatedDate = DateTime.Now,
                    Role = "Admin"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}