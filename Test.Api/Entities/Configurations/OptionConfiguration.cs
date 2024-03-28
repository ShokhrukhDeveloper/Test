using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Api.Entities.Configurations;

public class OptionConfiguration : EntityBaseConfiguration<Option>
{
    public override void Configure(EntityTypeBuilder<Option> builder)
    {
        base.Configure(builder);
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.Property(b => b.Content).HasMaxLength(255).IsRequired(true);
        builder.HasOne<Question>(e => e.Question).WithMany(e => e.Options).HasForeignKey(k => k.QuestionId);
    }
}