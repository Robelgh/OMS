//using Domain;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Persistence.EntityTypeConfiguration
//{
    

//    public class ProductProductTypeETC : IEntityTypeConfiguration<Product>
//    {
//        public void Configure(EntityTypeBuilder<Product> builder)
//        {
//            builder.ToTable("Products");
//            builder.HasKey(x => x.Id);

//            builder
//                 .HasOne(e => e.ProductTypes)
//                 .WithMany(e => e.Products)
//                 .HasForeignKey(e => e.ProductTypeId)
//                 .IsRequired()
//                 .OnDelete(DeleteBehavior.Cascade);


//        }
//    }
//}
