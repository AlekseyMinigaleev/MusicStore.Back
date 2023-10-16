using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.DB.Models;

namespace MusicStore.DB.ModelsConfigurations
{
    public class MusicalMetadataConfiguration : IEntityTypeConfiguration<MusicalMetadata>
    {
        public void Configure(EntityTypeBuilder<MusicalMetadata> builder)
        {
            builder.ToTable("MusicalMetadata")
                .HasKey(x => x.Id);
        }
    }
}
