namespace MusicStore.DB.Models
{
    public class EnsembleMember
    {
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string? Patronomyc { get; private set; }

        public string ProfileLink { get; private set; }

        public ISet<Ensemble> LeaderEnsembles { get; set; }
        public ISet<Ensemble> ComposerEnsembles { get; set; }
        public ISet<Ensemble> OrchestraConductorEnsembles { get; set; }
        
        public EnsembleMember(
            string firstName,
            string lastName,
            string? patronomyc,
            string profileLink,
            ISet<Ensemble> leaderEnsembles,
            ISet<Ensemble> composerEnsembles,
            ISet<Ensemble> orchestraConductorEnsembles)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Patronomyc = patronomyc;
            ProfileLink = profileLink;
            LeaderEnsembles = leaderEnsembles;
            ComposerEnsembles = composerEnsembles;
            OrchestraConductorEnsembles = orchestraConductorEnsembles;
        }

        protected EnsembleMember()
        { }
    }
}