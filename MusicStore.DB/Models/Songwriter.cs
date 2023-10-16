using MusicStore.DB.Models.Base;

namespace MusicStore.DB.Models
{
    public class Songwriter : PersonBase
    {
        public Guid Id { get; private set; }

        public ISet<Music> Musics { get; private set; }

        public Songwriter(
            string firstName,
            string secondName,
            string? patronomyc,
            ISet<Music> musics) : base(
                firstName: firstName,
                secondName: secondName,
                patronomyc: patronomyc)
        {
            Id = Guid.NewGuid();
            Musics = musics;
        }

        private Songwriter() : base()
        { }
    }
}