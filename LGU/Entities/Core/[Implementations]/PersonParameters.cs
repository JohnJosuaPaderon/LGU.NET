namespace LGU.Entities.Core
{
    public class PersonParameters : IPersonParameters
    {
        public PersonParameters()
        {
            Id = "@_Id";
            FirstName = "@_FirstName";
            MiddleName = "@_MiddleName";
            LastName = "@_LastName";
            NameExtension = "@_NameExtension";
            BirthDate = "@_BirthDate";
            Deceased = "@_Deceased";
            GenderId = "@_GenderId";
        }

        public string Id { get; }
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string NameExtension { get; }
        public string BirthDate { get; }
        public string Deceased { get; }
        public string GenderId { get; }
    }
}
