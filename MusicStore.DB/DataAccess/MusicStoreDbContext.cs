using Microsoft.EntityFrameworkCore;
using MusicStore.DB.Models;

namespace MusicStore.DB.DataAccess
{
    public class MusicStoreDbContext : DbContext
    {
        public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options)
            :base (options)
        { }

        public DbSet<ManufacturingCompany> Manufacturings { get; set; }
        public DbSet<CompactDisk> CompactDisks { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Ensemble> Ensembles { get; set; }
        public DbSet<MusicalMetadata> MusicalMetadatas { get; set; }
        public DbSet<Musicant> Musicants { get; set; }
        public DbSet<EnsembleMember> EnsembleMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MusicStoreDbContext).Assembly);
        }

    }
}
