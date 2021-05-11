using Domain.Const;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductServiceLocatorItemConfiguration : IEntityTypeConfiguration<ProductServiceLocatorItem>
    {
        public void Configure(EntityTypeBuilder<ProductServiceLocatorItem> builder)
        {
            builder.Property(t => t.TenantId)
                .HasMaxLength(ProductServiceLocatorConsts.TenantIdLenght);

            builder.Property(t => t.InstitutionType)
                .HasMaxLength(ProductServiceLocatorConsts.InstitutionTypeLenght)
                .IsRequired();
                
            builder.Property(t => t.ProcessType)
                .HasMaxLength(ProductServiceLocatorConsts.ProcessTypeLenght)
                .IsRequired();
        }
    }
}