using MusicStore.DB.Enums;

namespace MusicStore.DB.Models
{
    public class MusicalMetadata
    {
        public Guid Id { get; private set; }

        public double Duration { get; private set; }

        public MusicTempo Tempo { get; private set; }

        public string Arrangement { get; private set; }

        public string Dynamics { get; private set; }

        public string Interpretation { get; private set; }

        public Performance Performance { get; set; }
        public Guid PerformanceId { get; set; }

        public MusicalMetadata(
            double duration,
            MusicTempo tempo,
            string arrangement,
            string dynamics,
            string interpretation,
            Performance performance)
        {
            Id = Guid.NewGuid();
            Duration = duration;
            Tempo = tempo;
            Arrangement = arrangement;
            Dynamics = dynamics;
            Interpretation = interpretation;
            Performance = performance;
            PerformanceId = performance.Id;
        }

        private MusicalMetadata()
        { }
    }
}