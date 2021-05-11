using AutoMapper;
using Application.Common.Mappings;
using Domain.Entities;
using System;
using Domain.Enums;

namespace Application.ProductServiceLocator.Queries.GetProductServiceLocator
{
    public class ProductServiceLocatorItemDto : IMapFrom<ProductServiceLocatorItem>
    {
        public int Id { get; set; }

        public Guid? TenantId  { get; set; }
        public ProcessType ProcessType { get; set; }
        public InstitutionType InstitutionType { get; set; } 
        public bool IsDeleted { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductServiceLocatorItem, ProductServiceLocatorItemDto>()
                .ForMember(d => d.ProcessType, opt => opt.MapFrom(s => (int)s.ProcessType));
        }
    }
}
