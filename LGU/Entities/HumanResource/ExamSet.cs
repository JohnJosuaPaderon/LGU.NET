﻿namespace LGU.Entities.HumanResource
{
    public class ExamSet : Entity<int>
    {
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}