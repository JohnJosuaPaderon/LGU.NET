﻿using LGU.Models.HumanResource;
using Prism.Events;

namespace LGU.Events.HumanResource
{
    public sealed class KioskEmployeeChangedEvent : PubSubEvent<EmployeeModel>
    {
    }
}