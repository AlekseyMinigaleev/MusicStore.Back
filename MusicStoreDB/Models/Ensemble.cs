using MusicStore.DB.TDOs;

namespace MusicStore.DB.Models
{
    public class Ensemble
    {
        private EnsembleTypeRuleDto[] ensumbleTypeRuleDto;
        private HashSet<Performance> performance;

        public Guid Id { get; private set; }

        public string Type { get; private set; }

        public string Name { get;  set; }
        
        public ISet<Performance> Performances { get; private set; }

        public ISet<Musicant> Musicants { get; set; }

        public Ensemble(
            string name,
            ISet<Musicant> musicants,
            EnsembleTypeRuleDto[] ensumbleTypeRuleDto,
            ISet<Performance> performance)
        {
            Id = Guid.NewGuid();
            Name = name;
            Musicants = musicants;
            Type = EvaluateEnsembleType(ensumbleTypeRuleDto);
            Performances = performance;
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