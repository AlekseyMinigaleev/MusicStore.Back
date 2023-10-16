using MusicStore.DB.Enums;

namespace MusicStore.DB.Models
{
    public class MusicalMetadata
    {
        public Guid Id { get; private set; }

        public double Duration { get; private set; }

        public MusicTempo Tempo { get; private set; }

        public string Interpretation { get; private set; }

        public Performance Performance { get; private set; }
        public Guid PerformanceId { get; private set; }

        public MusicalMetadata(
            double duration,
            MusicTempo tempo,
            string interpretation,
            Performance performance)
        {
            Id = Guid.NewGuid();
            Duration = duration;
            Tempo = tempo;
            Interpretation = interpretation;
            Performance = performance;
            PerformanceId = performance.Id;
        }

        private MusicalMetadata()
        { }
    }
}