using MusicStore.DB.Enums;

namespace MusicStore.DB.Models
{
    public class MusicalMetadata
    {
        public Guid Id { get; private set; }

        public TimeSpan Duration { get; private set; }

        public MusicTempo Tempo { get; private set; }

        public string Interpretation { get; private set; }

        public MusicalMetadata(
            TimeSpan duration,
            MusicTempo tempo,
            string interpretation)
        {
            Id = Guid.NewGuid();
            Duration = duration;
            Tempo = tempo;
            Interpretation = interpretation;

        }

        private MusicalMetadata()
        { }
    }
}