using Microsoft.EntityFrameworkCore;

namespace Freelancing.Models
{
    public class FreelancingDbContext : DbContext
    {
        public FreelancingDbContext(DbContextOptions<FreelancingDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure Payment relationships
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Service)
                .WithMany()
                .HasForeignKey(p => p.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
                
            // Configure decimal precision
            modelBuilder.Entity<Service>()
                .Property(s => s.Price)
                .HasPrecision(18, 2);
                
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
                
            // Seed admin user with YOUR credentials
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Your Name", // Change this to your actual name
                    Email = "your-email@yourdomain.com", // Change this to your actual email
                    PhoneNumber = "your-phone-number", // Change this to your actual phone
                    IsAdmin = true,
                    CreatedAt = new DateTime(2025, 1, 1, 12, 0, 0, DateTimeKind.Utc)
                }
            );
            
            // Seed sample services
            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    Name = "Custom Web Application",
                    Type = "Web Development",
                    Description = "Full-stack web development using ASP.NET Core, React, and modern technologies.",
                    Price = 500.00m,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new Service
                {
                    Id = 2,
                    Name = "E-commerce Store",
                    Type = "E-commerce",
                    Description = "Complete e-commerce solutions with payment integration and inventory management.",
                    Price = 1200.00m,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new Service
                {
                    Id = 3,
                    Name = "Mobile Application",
                    Type = "Mobile Development",
                    Description = "Cross-platform mobile apps for iOS and Android using modern frameworks.",
                    Price = 800.00m,
                    IsActive = true,
                    CreatedAt = new DateTime(2025, 1, 1, 12, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}