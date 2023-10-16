namespace MusicStore.DB.Models.Base
{
    public class PersonBase
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string? Patronomyc { get; set; }

        public PersonBase(
            string firstName,
            string secondName,
            string? patronomyc)
        {
            FirstName = firstName;
            SecondName = secondName;
            Patronomyc = patronomyc;
        }

        protected PersonBase()
        { }
    }
}
