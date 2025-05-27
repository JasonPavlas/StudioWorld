using Microsoft.EntityFrameworkCore;
using webapp.Data.Entities;

namespace webapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure ServiceCategory entity
            modelBuilder.Entity<ServiceCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Slug).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Slug).IsUnique();
            });

            // Configure Service entity
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(2000);
                entity.Property(e => e.ShortDescription).HasMaxLength(200);
                entity.Property(e => e.BasePrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Slug).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.Slug).IsUnique();

                // Define relationship with ServiceCategory
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Services)
                      .HasForeignKey(e => e.ServiceCategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Booking entity
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ClientName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ClientEmail).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ClientPhone).IsRequired().HasMaxLength(20);
                entity.Property(e => e.TimeSlot).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Notes).HasMaxLength(1000);

                // Define relationship with Service
                entity.HasOne(e => e.Service)
                      .WithMany(s => s.Bookings)
                      .HasForeignKey(e => e.ServiceId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Add some seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Service Categories
            // Use a static date for all seed data to avoid EF Core warnings
            var seedCreatedDate = new DateTime(2025, 1, 1);
            var seedUpdatedDate = new DateTime(2025, 1, 1);
            
            modelBuilder.Entity<ServiceCategory>().HasData(
                new ServiceCategory { 
                    Id = 1, 
                    Name = "Content Creation",
                    Description = "Professional video, photo, and digital content creation services.", 
                    Slug = "content-creation", 
                    ImageUrl = "/images/services/content-creation.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                },
                new ServiceCategory { 
                    Id = 2, 
                    Name = "Podcasting & Media",
                    Description = "Professional recording studio and media production services.", 
                    Slug = "podcasting-media", 
                    ImageUrl = "/images/services/podcasting-media.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                },
                new ServiceCategory { 
                    Id = 3, 
                    Name = "Cosmetology",
                    Description = "Hair styling, beauty treatments, and professional cosmetic services.", 
                    Slug = "cosmetology", 
                    ImageUrl = "/images/services/cosmetology.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                },
                new ServiceCategory { 
                    Id = 4, 
                    Name = "Tattooing",
                    Description = "Custom tattoo design and professional tattoo services.", 
                    Slug = "tattooing", 
                    ImageUrl = "/images/services/tattooing.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                }
            );

            // Seed Services
            modelBuilder.Entity<Service>().HasData(
                // Content Creation Services
                new Service { 
                    Id = 1, 
                    ServiceCategoryId = 1, 
                    Name = "Professional Photography", 
                    ShortDescription = "High-quality photography for individuals and businesses", 
                    Description = "Our professional photography services include portrait, product, and event photography with expert editing and quick turnaround times.", 
                    BasePrice = 150.00M, 
                    DurationMinutes = 60, 
                    Slug = "professional-photography",
                    ImageUrl = "/images/services/photography.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                },
                new Service { 
                    Id = 2, 
                    ServiceCategoryId = 1, 
                    Name = "Video Production", 
                    ShortDescription = "Full-service video production for any occasion", 
                    Description = "From concept to final edit, our video production team creates compelling visual content for marketing, events, and social media.", 
                    BasePrice = 300.00M, 
                    DurationMinutes = 120, 
                    Slug = "video-production",
                    ImageUrl = "/images/services/video-production.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                },
                
                // Podcasting & Media Services
                new Service { 
                    Id = 3, 
                    ServiceCategoryId = 2, 
                    Name = "Podcast Recording Session", 
                    ShortDescription = "Professional recording for your podcast", 
                    Description = "Record your podcast in our state-of-the-art studio with professional equipment and sound engineering support.", 
                    BasePrice = 100.00M, 
                    DurationMinutes = 60, 
                    Slug = "podcast-recording",
                    ImageUrl = "/images/services/podcast-recording.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                },
                
                // Cosmetology Services
                new Service { 
                    Id = 4, 
                    ServiceCategoryId = 3, 
                    Name = "Haircut & Style", 
                    ShortDescription = "Professional haircut and styling", 
                    Description = "Get a professional haircut and style from our experienced stylists who will work with you to create the perfect look.", 
                    BasePrice = 60.00M, 
                    DurationMinutes = 45, 
                    Slug = "haircut-style",
                    ImageUrl = "/images/services/haircut.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                },
                
                // Tattooing Services
                new Service { 
                    Id = 5, 
                    ServiceCategoryId = 4, 
                    Name = "Custom Tattoo Design", 
                    ShortDescription = "Personalized tattoo design consultation", 
                    Description = "Work with our talented tattoo artists to create a custom design that expresses your individuality and style.", 
                    BasePrice = 200.00M, 
                    DurationMinutes = 90, 
                    Slug = "custom-tattoo-design",
                    ImageUrl = "/images/services/tattoo-design.jpg",
                    CreatedAt = seedCreatedDate,
                    UpdatedAt = seedUpdatedDate,
                    IsDeleted = false
                }
            );
        }
    }
}
