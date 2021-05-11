using System;

namespace Domain.Common
{
    public interface IMultiTenant
    {
        Guid? TenantId { get; }
    }
}
