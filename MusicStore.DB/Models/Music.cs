namespace MusicStore.DB.Models
{
    public class Music
    {
        public Guid Id { get; private set;} 
        
        public string Name { get; private set;} 
        
        public string Genre { get; private set;}

        public Songwriter Autor { get; private set; }
        public Guid AuthorId { get; private set; }

        public ISet<Performance> Performances { get; private set; }

        public ISet<CompactDisk> CompactDisks { get; private set; }

        public Music(
            Songwriter author,
            string name,
            string genre,
            ISet<Performance> performances,
            ISet<CompactDisk> compactDisks)
        {
            Id = Guid.NewGuid();
            Name = name;
            Genre = genre;
            Performances = performances;
            CompactDisks = compactDisks;
            Autor = author;
            AuthorId = author.Id;
        }

        private Music() { }
    }
}
