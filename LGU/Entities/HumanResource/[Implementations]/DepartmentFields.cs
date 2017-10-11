namespace LGU.Entities.HumanResource
{
    public sealed class DepartmentFields : IDepartmentFields
    {
        public DepartmentFields()
        {
            Id = "Id";
            Description = "Description";
            Abbreviation = "Abbreviation";
            HeadId = "HeadId";
        }

        public string Id { get; }
        public string Description { get; }
        public string Abbreviation { get; }
        public string HeadId { get; }
    }
}
