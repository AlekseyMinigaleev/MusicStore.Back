namespace MusicStore.DB.Models
{
    public class ManufacturingCompany
    {
        public Guid Id { get; private set; }
        
        public string Name { get; private set; }
        
        public string? ShortName { get; private set; }
        
        public string Address { get; private set; }
        
        public decimal WhosalerPrice { get; private set; }

        public ISet<CompactDisk> ManufacturedDisks { get; private set; }

        public ManufacturingCompany(
            string name,
            string? shortName,
            string address,
            decimal whosalerPrice,
            ISet<CompactDisk> manufacturedDisks)
        {
            Id = Guid.NewGuid();
            Name = name;
            ShortName = shortName;
            Address = address;
            WhosalerPrice = whosalerPrice;
            ManufacturedDisks = manufacturedDisks;
        }

        private ManufacturingCompany()
        { }
    }
}