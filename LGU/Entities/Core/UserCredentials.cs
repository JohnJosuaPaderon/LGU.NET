﻿using System.Security;

namespace LGU.Entities.Core
{
    public struct UserCredentials
    {
        public SecureString SecureUsername { get; set; }
        public SecureString SecurePassword { get; set; }
    }
}
