using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.OrderAgg;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "order");

            builder.OwnsOne(b => b.Discount, options =>
            {
                options.Property(b => b.DiscountTitle)
                    .HasMaxLength(50);
            });


            builder.OwnsMany(b => b.Items, options =>
            {
                options.ToTable("Items", "order");
            });

            builder.OwnsOne(b => b.Address, options =>
            {
                options.ToTable("Addresses", "order");
                options.HasKey(b => b.Id);

                options.Property(b => b.City)
                    .HasMaxLength(50).IsRequired();

                options.Property(b => b.PhoneNumber)
                    .HasMaxLength(11).IsRequired();

                options.Property(b => b.Family)
                    .HasMaxLength(100).IsRequired();

                options.Property(b => b.Name)
                    .HasMaxLength(100).IsRequired();

                options.Property(b => b.City)
                    .HasMaxLength(50).IsRequired();

                options.Property(b => b.Nationalcode)
                    .HasMaxLength(11).IsRequired();

                options.Property(b => b.PostalCode)
                    .HasMaxLength(11).IsRequired();

                options.Property(b => b.PostalAddress)
                    .HasMaxLength(50).IsRequired();
            });
        }
    }
}
