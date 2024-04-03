using CourseHub.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Infrastructure.Data.SeedDb
{
    internal class CourseParticipantConfiguration : IEntityTypeConfiguration<CourseParticipant>
    {
        public void Configure(EntityTypeBuilder<CourseParticipant> builder)
        {
            builder
               .HasKey(cp => new { cp.CourseId, cp.ParticipantId });

            builder
                .HasOne(c => c.Course)
                .WithMany(c => c.CourseParticipants)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
