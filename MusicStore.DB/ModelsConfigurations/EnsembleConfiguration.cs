using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.DB.Models;

namespace MusicStore.DB.ModelsConfigurations
{
    public class EnsembleConfiguration : IEntityTypeConfiguration<Ensemble>
    {
        public void Configure(EntityTypeBuilder<Ensemble> builder)
        {
            builder.ToTable("Ensemble")
                .HasKey(x => x.Id);

            builder.HasMany(x => x.Musicants)
                .WithMany(x => x.Ensembles)
                .UsingEntity(x => x.ToTable("EnsambleMusicant"));

            builder.HasMany(x => x.Performances)
                .WithOne(x => x.Ensemble)
                .HasForeignKey(x => x.EnsembleId);
        }
    }
}