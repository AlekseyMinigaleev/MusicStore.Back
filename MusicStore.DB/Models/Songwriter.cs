using MusicStore.DB.Models.Base;

namespace MusicStore.DB.Models
{
    public class Songwriter : PersonBase
    {
        public Guid Id { get; private set; }

        public ISet<Music> Musics { get; private set; }

        public Songwriter(
            string firstName,
            string lastName,
            string? patronomyc,
            ISet<Music> musics) : base(
                firstName: firstName,
                lastName: lastName,
                patronomyc: patronomyc)
        {
            Id = Guid.NewGuid();
            Musics = musics;
        }

        private Songwriter() : base()
        { }
    }
}