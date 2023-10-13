namespace MusicStore.DB.Models
{
    public class Musicant : EnsembleMember
    {
        public string MusicalInstrument { get; private set; }

        public ISet<Ensemble> MusicantEnsembles { get; set; }

        public Musicant(
            string firstName,
            string lastName,
            string? patronomyc,
            string profileLink,
            ISet<Ensemble> leaderEnsembles,
            ISet<Ensemble> composerEnsembles,
            ISet<Ensemble> orchestraConductorEnsembles,
            string musicalInstrument) : base(
                firstName:firstName,
                lastName:lastName,
                patronomyc:patronomyc,
                profileLink:profileLink,
                orchestraConductorEnsembles: orchestraConductorEnsembles,
                composerEnsembles:composerEnsembles,
                leaderEnsembles:leaderEnsembles)
        {
            MusicalInstrument = musicalInstrument;
        }

        private Musicant() :base()
        { }


    }
}