using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext: DbContext
    {
        private string Path { get; set; }

        public AppDbContext() 
        {
            var  folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            Path = System.IO.Path.Join(path, "books.db");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data source ={Path}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "adam", Email = "asdad@.pl", Phone = "23123123131" },
                new ContactEntity() { Id = 2, Name = "ada21123m", Email = "asdad@.pl", Phone = "23123123131" },
                new ContactEntity() { Id = 3, Name = "a231111dam", Email = "asdad@.pl", Phone = "23123123131" });

            modelBuilder.Entity<BookEntity>().HasData(
                new BookEntity() { Id = 1, Author = "sssss", Title = "ssadasdad", ISBN="1234567891234" , PageNumber="222" , PublicationYear="2002-09-09" , Publisher="loll"});
                
        }





        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<BookEntity> Books { get; set; }
    }
}
