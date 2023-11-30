using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.DB.Models;

namespace MusicStore.DB.ModelsConfigurations
{
    public class PerformanceConfiguration : IEntityTypeConfiguration<Performance>
    {
        public void Configure(EntityTypeBuilder<Performance> builder)
        {
            builder.ToTable("Performance")
                .HasKey(x => x.Id);

            builder.HasOne(x => x.MusicalMetadata)
                .WithOne()
                .HasForeignKey<Performance>(x => x.MusicalMetadataId);
        }
    }   
}