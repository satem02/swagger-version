using System;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class ProductServiceLocatorItem : AuditableEntity, IMultiTenant
    {
        public Guid? TenantId  { get; set; }
        public ProcessType ProcessType { get; set; }
        public InstitutionType InstitutionType { get; set; }       
    }
}