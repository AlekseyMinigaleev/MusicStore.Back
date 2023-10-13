namespace MusicStore.DB.TDOs
{
    public class EnsembleTypeRuleDto
    {
        public string Type { get; set; }

        public bool? HasLeader { get; set; }

        public bool? HasComposer { get; set; }

        public bool? HasOrchestraConductor { get; set; }

        public Dictionary<string, int> MusicalInstrumentCount { get; set; }
    }
}
