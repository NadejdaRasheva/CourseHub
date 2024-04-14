using CourseHub.Infrastructure.Data.Models;
using CourseHub.Infrastructure.Data.SeedDb;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CourseHub.Infrastrucure.Data
{
    public class CourseHubDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool _seedDb;
        public CourseHubDbContext(DbContextOptions<CourseHubDbContext> options, bool seed = true)
            : base(options)
        {
            
            if(Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }

            _seedDb = seed;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new TeacherConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseParticipantConfiguration());

            builder.Entity<Course>()
                .HasOne(c => c.Category)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Course>()
				.HasOne(c => c.Teacher)
				.WithMany()
				.HasForeignKey(c => c.TeacherId)
				.OnDelete(DeleteBehavior.Restrict);

			if (_seedDb)
            {
				builder.ApplyConfiguration(new UserConfiguration());
				builder.ApplyConfiguration(new TeacherConfiguration());
				builder.ApplyConfiguration(new CategoryConfiguration());
				builder.ApplyConfiguration(new CourseConfiguration());
                builder.ApplyConfiguration(new CourseParticipantConfiguration());
            }
            base.OnModelCreating(builder);
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseParticipant> CoursesParticipants { get; set; }
    }
}