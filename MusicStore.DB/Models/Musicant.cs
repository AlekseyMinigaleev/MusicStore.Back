using MusicStore.DB.Models.Base;

namespace MusicStore.DB.Models
{
    public class Musicant : PersonBase
    {
        public Guid Id { get; private set; }

        public string MusicalInstrument { get; private set; }

        public ISet<Ensemble> Ensembles { get; private set; }

        public Musicant(
            string firstName,
            string secondName,
            string? patronomyc,
            string musicalInstrument,
            ISet<Ensemble> ensembles
            ):base(
                firstName:firstName,
                secondName:secondName,
                patronomyc:patronomyc)
        {
            Id = Guid.NewGuid();
            MusicalInstrument = musicalInstrument;
            Ensembles = ensembles;
        }

        private Musicant(): base()
        { }
    }
}