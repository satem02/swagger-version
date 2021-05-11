﻿using System;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        Guid TenantId{ get; }
    }
}
