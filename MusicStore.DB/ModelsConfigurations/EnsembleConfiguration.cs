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

            builder.HasOne(x => x.Leader)
                .WithMany(x => x.LeaderEnsembles)
                .HasForeignKey(x => x.LeaderId)
                .HasConstraintName("FK_Ensemble_EnsembleMembers_Leader");

            builder.HasOne(x => x.Composer)
                .WithMany(x => x.ComposerEnsembles)
                .HasForeignKey(x => x.ComposerId)
                .HasConstraintName("FK_Ensemble_EnsembleMembers_Composer");

            builder.HasOne(x => x.OrchestraConductor)
                .WithMany(x => x.OrchestraConductorEnsembles)
                .HasForeignKey(x => x.OrchestraConductorId)
                .HasConstraintName("FK_Ensemble_EnsembleMembers_OrhestraConductor");

            builder.HasMany(x => x.Musicants)
                .WithMany(x => x.MusicantEnsembles)
                .UsingEntity(x => x.ToTable("EnsambleMusicant"));
        }
    }
}