﻿namespace LGU.Entities.HumanResource
{
    public class ApplicantStatus : Entity<short>
    {
        public static ApplicantStatus Applied { get; }
        public static ApplicantStatus Rejected { get; }

        public string Description { get; set; }
        public int Step { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
