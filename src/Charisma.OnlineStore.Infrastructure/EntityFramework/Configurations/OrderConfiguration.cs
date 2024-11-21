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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnOrder(1);
            builder.Property(x => x.BuyerId).HasColumnOrder(2);
            builder.Property(x => x.OrderDate).HasColumnOrder(3);
            builder.Property<decimal>("_totalDiscount").HasColumnName("TotalDiscount").HasColumnOrder(4);

            builder
                  .HasOne(typeof(Buyer))
                  .WithMany()
                  .HasForeignKey(nameof(Order.BuyerId))
                  .IsRequired(false);

            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(x => x.Country).HasColumnName("Country").HasColumnType("nvarchar(50)").HasColumnOrder(5);
                address.Property(x => x.State).HasColumnName("State").HasColumnType("nvarchar(50)").HasColumnOrder(6);
                address.Property(x => x.City).HasColumnName("City").HasColumnType("nvarchar(50)").HasColumnOrder(7);
                address.Property(x => x.Street).HasColumnName("Street").HasColumnType("nvarchar(50)").HasColumnOrder(8);
                address.Property(x => x.ZipCode).HasColumnName("ZipCode").HasColumnType("nvarchar(50)").HasColumnOrder(9);

            });


            builder.OwnsMany(df => df.OrderItems,
                    dfNavigationBuilder =>
                    {
                        dfNavigationBuilder.ToTable("OrderItem");

                        dfNavigationBuilder.HasKey(x=>x.Id);

                        dfNavigationBuilder.WithOwner()
                                         .HasForeignKey("OrderId");

                        dfNavigationBuilder.Ignore(x => x.FinalPrice);
                        dfNavigationBuilder.Property<decimal>("_unitPrice").HasColumnName("UnitPrice");
                        dfNavigationBuilder.Property<int>("_units").HasColumnName("Units");
                        dfNavigationBuilder.Property<decimal>("_profitMargin").HasColumnName("ProfitMargin");
                        dfNavigationBuilder.Property("_productName").HasColumnType("nvarchar(300)").HasColumnName("ProductName");
                        dfNavigationBuilder.Property(x => x.ProductId);

                        dfNavigationBuilder
                                    .HasOne(typeof(Product))
                                    .WithMany()
                                    .HasForeignKey(nameof(OrderItem.ProductId))
                                    .IsRequired(false);

                    }
                );
        }
    }
}
