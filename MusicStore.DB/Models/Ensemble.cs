using MusicStore.DB.TDOs;

namespace MusicStore.DB.Models
{
    public class Ensemble
    {
        public Guid Id { get; set; }

        public ISet<Musicant> Musicants { get; set; }

        public EnsembleMember? Leader { get; set; }
        public Guid? LeaderId { get; set; }

        public EnsembleMember? Composer { get; set; }
        public Guid? ComposerId { get; set; }

        public EnsembleMember? OrchestraConductor { get; set; }
        public Guid? OrchestraConductorId { get; set; }

        public string Type { get; set; }

        public Performance Performance { get; set; }
        public Guid PerformanceId { get; set; }

        public Ensemble(
            ISet<Musicant> musicants,
            EnsembleMember leader,
            EnsembleMember composer,
            EnsembleMember orchestraConductor,
            EnsembleTypeRuleDto[] ensumbleTypeRuleDto,
            Performance performance)
        {
            Id = Guid.NewGuid();
            Musicants = musicants;
            Leader = leader;
            LeaderId = leader.Id;
            Composer = composer;
            ComposerId = composer.Id;
            OrchestraConductor = orchestraConductor;
            OrchestraConductorId = orchestraConductor.Id;
            Type = EvaluateEnsembleType(ensumbleTypeRuleDto);
            Performance = performance;
            PerformanceId = performance.Id;
        }

        private Ensemble()
        { }

        public string EvaluateEnsembleType(EnsembleTypeRuleDto[] rules)
        {
            foreach (var rule in rules)
                if (IsEnsembleTypeMatch(rule))
                    return rule.Type;

            return "Undefined";
        }

        private bool IsEnsembleTypeMatch(EnsembleTypeRuleDto rule)
        {
            if (rule.HasLeader.HasValue && rule.HasLeader != (Leader != null))
                return false;

            if (rule.HasOrchestraConductor.HasValue && rule.HasOrchestraConductor != (OrchestraConductor != null))
                return false;

            if (rule.HasComposer.HasValue && rule.HasComposer != (Composer != null))
                return false;

            foreach (var musicalInstrumentCount in rule.MusicalInstrumentCount)
            {
                var rightMusiciansCount = Musicants
                    .Count(x => x.MusicalInstrument.Equals(musicalInstrumentCount.Key));

                if (musicalInstrumentCount.Value != rightMusiciansCount)
                    return false;
            }

            return true;
        }
    }
}