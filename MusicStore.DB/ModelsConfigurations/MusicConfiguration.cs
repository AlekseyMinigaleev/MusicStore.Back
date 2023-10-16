using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.DB.Models;

namespace MusicStore.DB.ModelsConfigurations
{
    public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.ToTable("Music")
                .HasKey(x => x.Id);

            builder.HasMany(x => x.Performances)
                .WithOne(x => x.Music)
                .HasForeignKey(x => x.MusicId);

            builder.HasOne(x => x.Autor)
                .WithMany(x => x.Musics)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}