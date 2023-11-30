namespace MusicStore.DB.Models
{
    public class Performance
    {
        public Guid Id { get; private set; }
        
        public string Place { get; private set; }
        
        public string Name { get; private set; }
        
        public Ensemble Ensemble { get; private set; }
        public Guid EnsembleId { get; set; }

        public Music? Music { get; private set; }
        public Guid? MusicId { get; private set; }

        public MusicalMetadata MusicalMetadata { get; private set; }
        public Guid MusicalMetadataId { get; private set; }

        public Performance(
            string place,
            string name,
            Ensemble ensambel,
            MusicalMetadata musicalMetadata,
            Music? music)
        {
            Id = Guid.NewGuid();
            Place = place;
            Name = name;
            Ensemble = ensambel;
            EnsembleId = ensambel.Id;
            MusicalMetadata = musicalMetadata;
            MusicalMetadataId = musicalMetadata.Id;
            Music = music;
            MusicId = music?.Id;
        }

        private Performance()
        { }
    }
}