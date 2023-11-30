using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.DB.Models;

namespace MusicStore.DB.ModelsConfigurations
{
    public class CompactDiskConfiguration : IEntityTypeConfiguration<CompactDisk>
    {
        public void Configure(EntityTypeBuilder<CompactDisk> builder)
        {
            builder.ToTable("CompactDisk")
                .HasKey(x => x.Id);

            builder.HasOne(x => x.ManufacturingCompany)
                .WithMany(x => x.ManufacturedDisks)
                .HasForeignKey(x => x.ManufacturingCompanyId);

            builder.HasOne(x => x.Music)
                .WithMany(x => x.CompactDisks)
                .HasForeignKey(x => x.MusicId);
        }
    }
}