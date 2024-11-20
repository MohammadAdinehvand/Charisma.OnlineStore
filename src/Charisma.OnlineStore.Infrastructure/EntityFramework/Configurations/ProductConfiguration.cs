using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Infrastructure.EntityFramework.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable(nameof(Product));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property(x => x.ProductType);
            builder.Property(x => x.Name).HasColumnType("nvarchar(300)");

        }
    }
}
