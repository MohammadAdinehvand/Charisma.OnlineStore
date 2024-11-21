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
    public class ProfitConfiguration : IEntityTypeConfiguration<Profit>
    {
        public void Configure(EntityTypeBuilder<Profit> builder)
        {

            builder.ToTable(nameof(Profit));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);
            builder.Property("_title").HasColumnType("nvarchar(300)").HasColumnName("Title");
            builder.Property<decimal>("_fixedAmount").HasColumnName("FixedAmount");
            builder.Property(x=>x.Active);


        }
    }
}
