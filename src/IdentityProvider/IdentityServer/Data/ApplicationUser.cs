﻿using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Data
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CareerStartedDate { get; set; }
        public string? FullName { get; set; }
    }
}
