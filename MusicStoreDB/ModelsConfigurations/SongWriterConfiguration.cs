using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.DB.Models;

namespace MusicStore.DB.ModelsConfigurations
{
    internal class SongWriterConfiguration : IEntityTypeConfiguration<Songwriter>
    {
        public void Configure(EntityTypeBuilder<Songwriter> builder)
        {
            builder.ToTable("Songwriter")
                .HasKey(x => x.Id);
        }
    }
}