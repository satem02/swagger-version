﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<ProductServiceLocatorItem> ProductServiceLocatorItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
