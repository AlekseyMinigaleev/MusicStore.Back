namespace MusicStore.DB.Models
{
    public class CompactDisk
    {
        public Guid Id { get; private set; }

        public string Name { get;  set; }

        public DateTime CreationDate { get; private set; }

        public decimal RetailPrice { get; private set; }

        public decimal WhosalerPrice { get; private set; }

        public int CountInStock { get; private set; }

        public int? CountSoldPreviousYear { get; private set; }

        public int CountSoldCurrentYear { get; private set; }

        public Music Music { get; private set; }
        public Guid MusicId { get; private set; }

        public ManufacturingCompany ManufacturingCompany { get; private set; }
        public Guid ManufacturingCompanyId { get; private set; }

        public CompactDisk(
            Music music,
            ManufacturingCompany manufacturingCompany,
            decimal retailPrice,
            decimal whosalerPrice,
            int countInStock)
        {
            Id = Guid.NewGuid();
            Name = music.Name;
            Music = music;
            MusicId = music.Id;
            ManufacturingCompany = manufacturingCompany;
            ManufacturingCompanyId = manufacturingCompany.Id;
            RetailPrice = retailPrice;
            WhosalerPrice = whosalerPrice;
            CountInStock = countInStock;
            CreationDate = DateTime.Now;
        }

        private CompactDisk()
        { }

        public void IncreaseCountSoldCurrentYear() => CountSoldCurrentYear++;

        public void SetSoldPreviousYear() => CountSoldPreviousYear = CountSoldCurrentYear;
    }
}