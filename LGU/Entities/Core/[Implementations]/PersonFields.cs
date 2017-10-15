namespace LGU.Entities.Core
{
    public class PersonFields : EntityFields, IPersonFields
    {
        public PersonFields()
        {
            FirstName = "FirstName";
            MiddleName = "MiddleName";
            LastName = "LastName";
            NameExtension = "NameExtension";
            BirthDate = "BirthDate";
            Deceased = "Deceased";
            GenderId = "GenderId";
        }
        
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }
        public string NameExtension { get; }
        public string BirthDate { get; }
        public string Deceased { get; }
        public string GenderId { get; }
    }
}
