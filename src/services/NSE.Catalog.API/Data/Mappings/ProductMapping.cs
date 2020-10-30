using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Catalog.API.Models;

namespace NSE.Catalog.API.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(me => me.Id);

            builder.ToTable("Products");

            builder.Property(me => me.Name).IsRequired().HasColumnType("varchar(250)");
            builder.Property(me => me.Description).IsRequired().HasColumnType("varchar(500)");
            builder.Property(me => me.Image).IsRequired().HasColumnType("varchar(250)");
         
        }
    }
}
