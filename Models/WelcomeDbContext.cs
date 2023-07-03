using Microsoft.EntityFrameworkCore;

namespace welcome_api.Models
{
    public class WelcomeDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Topar> Toparlar { get; set; }

        public WelcomeDbContext(DbContextOptions<WelcomeDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(builder=>
            {
                builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
                builder.Property(c => c.Lastname).HasMaxLength(100).IsRequired();
                builder.Property(c => c.Crdate).HasColumnType("datetime2").HasDefaultValueSql("getdate()");
                builder.HasOne(f => f.Topar).WithMany().HasForeignKey(f => f.ToparId).IsRequired(false);

            });

            modelBuilder.Entity<Note>(builder =>
            {
                builder.Property(c => c.Text).HasMaxLength(800).IsRequired();
                builder.Property(c => c.Crdate).HasColumnType("datetime2").HasDefaultValueSql("getdate()");
                builder.HasOne(f => f.Student).WithMany(f => f.Notes).HasForeignKey(f => f.StudentId);
            });  
            
            modelBuilder.Entity<Topar>(builder =>
            {
                builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            });
        }

    }
}
