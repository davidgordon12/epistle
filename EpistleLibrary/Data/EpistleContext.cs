using EpistleLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EpistleLibrary.Data
{
    public class EpistleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=local;Trusted_Connection=True");
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
    }
}
