using Charisma.OnlineStore.Domain.Models.DiscountAggregate;
using Charisma.OnlineStore.Domain.Models.OrderAggregate;
using Charisma.OnlineStore.Domain.Models.ProductAggregate;
using Charisma.OnlineStore.Domain.Models.ProfitAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charisma.OnlineStore.Infrastructure.EntityFramework.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {

            builder.ToTable(nameof(Discount));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property("_title").HasColumnType("nvarchar(300)").HasColumnName("Title");
            builder.Property<DiscountType>("_discountType").HasColumnName("DiscountType");
            builder.Property<decimal>("_value").HasColumnName("Value");
            builder.Property(x=>x.Active).HasColumnName("Active");


        }
    }
}
