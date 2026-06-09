using Microsoft.EntityFrameworkCore;
using GraduateAppTracker.Models;

namespace GraduateAppTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UniversityProgram> UniversityPrograms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UniversityProgram>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UniversityName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.DepartmentName).IsRequired().HasMaxLength(200);
                entity.Property(e => e.MinAlesScore).HasColumnType("decimal(5,2)");
                entity.Property(e => e.MinLanguageScore).HasColumnType("decimal(5,2)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("GETDATE()");

                // Seed Data
                entity.HasData(
                    new UniversityProgram
                    {
                        Id = 1,
                        UniversityName = "Ankara Üniversitesi",
                        DepartmentName = "Bilgisayar Mühendisliği",
                        MinAlesScore = 70,
                        RequiresLanguage = true,
                        MinLanguageScore = 65,
                        ApplicationDate = DateTime.Now.AddDays(14),
                        CreatedAt = DateTime.Now
                    },
                    new UniversityProgram
                    {
                        Id = 2,
                        UniversityName = "İstanbul Teknik Üniversitesi",
                        DepartmentName = "Yapay Zeka ve Veri Mühendisliği",
                        MinAlesScore = 75,
                        RequiresLanguage = false,
                        MinLanguageScore = null,
                        ApplicationDate = DateTime.Now.AddDays(5),
                        CreatedAt = DateTime.Now
                    },
                    new UniversityProgram
                    {
                        Id = 3,
                        UniversityName = "ODTÜ",
                        DepartmentName = "Elektrik-Elektronik Mühendisliği",
                        MinAlesScore = 80,
                        RequiresLanguage = true,
                        MinLanguageScore = 70,
                        ApplicationDate = DateTime.Now.AddDays(30),
                        CreatedAt = DateTime.Now
                    }
                );
            });
        }
    }
}
