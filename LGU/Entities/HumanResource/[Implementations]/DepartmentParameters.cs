namespace LGU.Entities.HumanResource
{
    public sealed class DepartmentParameters : IDepartmentParameters
    {
        public DepartmentParameters()
        {
            Id = "@_Id";
            Description = "@_Description";
            Abbreviation = "@_Abbreviation";
            HeadId = "@_HeadId";
        }

        public string Id { get; }
        public string Description { get; }
        public string Abbreviation { get; }
        public string HeadId { get; }
    }
}
