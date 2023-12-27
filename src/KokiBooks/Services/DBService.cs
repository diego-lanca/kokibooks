using Microsoft.EntityFrameworkCore;
using KokiBooks.Models;

namespace KokiBooks.Services
{
    public class DataService : DbContext
    {
        public DbSet<Author> autor {get; set;}
        public DbSet<Book> book {get; set;}
        public DbSet<Editora> editora {get; set;}
        public DbSet<Cliente> cliente {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            string arquivoDB = "kokibooks.db";

            if (arquivoDB != null) {
                string connectionString = $"Data Source={arquivoDB};";

                optionsBuilder.UseSqlite(connectionString);

            }
            else {
                throw new ArgumentException("Erro ao construir caminho para o banco de dados!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b => b.autor).WithMany(a => a.book).HasForeignKey(b => b.idAutor);
            modelBuilder.Entity<Book>().HasOne(b => b.editora).WithMany().HasForeignKey(b => b.idEditora);
        }
    }
}