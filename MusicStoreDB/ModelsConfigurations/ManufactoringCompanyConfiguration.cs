using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.DB.Models;

namespace MusicStore.DB.ModelsConfigurations
{
    public class ManufactoringCompanyConfiguration : IEntityTypeConfiguration<ManufacturingCompany>
    {
        public void Configure(EntityTypeBuilder<ManufacturingCompany> builder)
        {
            builder.ToTable("ManufactoringCompany")
                .HasKey(x => x.Id);
        }
    }
}