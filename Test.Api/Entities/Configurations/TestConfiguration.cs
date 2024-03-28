using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Api.Entities.Configurations;

public class TestConfiguration: EntityBaseConfiguration<Test>
{
    public override void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Description).HasMaxLength(1023).IsRequired();
        builder.HasMany<Question>(q => q.Questions).WithOne(e => e.Test).HasForeignKey(k => k.TestId);

    }
}