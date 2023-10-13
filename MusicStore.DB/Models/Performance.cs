namespace MusicStore.DB.Models
{
    public class Performance
    {
        public Guid Id { get; set; }

        public string Place { get; set; }

        public string Name { get; set; }

        public Ensemble Ensamble { get; set; }

        public Music Music { get; set; }
        public Guid MusicId { get; set; }

        public MusicalMetadata MusicalMetadata { get; set; }

        public Performance(
            string place,
            string name,
            Ensemble ensamblel,
            MusicalMetadata musicalMetadata,
            Music music)
        {
            Id = Guid.NewGuid();
            Place = place;
            Name = name;
            Ensamble = ensamblel;
            MusicalMetadata = musicalMetadata;
            Music = music;
            MusicId = music.Id;
        }

        private Performance()
        { }
    }
}