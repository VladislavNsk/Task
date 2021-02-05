using System.Data.Entity;

namespace DocumentsStorage.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Document> Documents { get; set; }

        public UserContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Entity<Document>().
                MapToStoredProcedures();
            base.OnModelCreating(modelBuilder);
        }
    }
}