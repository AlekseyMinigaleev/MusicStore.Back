using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.DB.Models;

namespace MusicStore.DB.ModelsConfigurations
{
    public class MusicantConfiguration : IEntityTypeConfiguration<Musicant>
    {
        public void Configure(EntityTypeBuilder<Musicant> builder)
        {
            builder.ToTable("Musicant")
                .HasKey(x => x.Id);
        }
    }
}
