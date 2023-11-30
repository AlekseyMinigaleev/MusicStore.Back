namespace MusicStore.DB.Models.Base
{
    public class PersonBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Patronomyc { get; set; }

        public PersonBase(
            string firstName,
            string lastName,
            string? patronomyc)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronomyc = patronomyc;
        }

        protected PersonBase()
        { }
    }
}
