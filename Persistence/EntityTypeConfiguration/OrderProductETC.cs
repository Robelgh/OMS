using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Persistence.EntityTypeConfiguration
{

    public class OrderProductETC : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder
                 .HasOne(e => e.ProductTypes)
                 .WithMany(e => e.Orders)
                 .HasForeignKey(e => e.ProductId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);
          

        }
    }
}
