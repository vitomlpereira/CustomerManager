using CustomerService.Core.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerService.Infrastructure.Data.Config;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
  public void Configure(EntityTypeBuilder<Customer> builder)
  {
    builder.ToTable("Customers");

    builder.Property(p => p.Id)
      .HasColumnType("uniqueidentifier")
      .IsRequired();


    builder.Property(p => p.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(p => p.CompanyName)
       .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
       .IsRequired();
  }
}
