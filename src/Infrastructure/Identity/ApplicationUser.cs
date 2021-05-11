using System;
using Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser, IMultiTenant
    {
        public Guid? TenantId { get; set; }
    }
}
