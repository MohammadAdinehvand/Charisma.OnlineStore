using Charisma.OnlineStore.Domain.Models.BuyerAggregate;
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
    public class BuyerConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {

            builder.ToTable(nameof(Buyer));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)"); ;
            builder.Property(x => x.Family).HasColumnType("nvarchar(100)"); ;
            builder.Property(x => x.PhoneNumber).HasColumnType("varchar(15)"); ;

        }
    }
}
