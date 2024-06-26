using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Api.Entities.Configurations;

public class QuestionConfiguration : EntityBaseConfiguration<Question>
{
    public override void Configure(EntityTypeBuilder<Question> builder)
    {
        base.Configure(builder);
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.Property(b => b.TestId).IsRequired(true);
        builder.Property(b => b.Content).HasMaxLength(2024).IsRequired(true);
        builder.Property(b => b.Image).HasColumnType("varchar(255)");
        builder.HasMany<Option>(b => b.Options).WithOne(b => b.Question).HasForeignKey(e => e.QuestionId).OnDelete(DeleteBehavior.Cascade);;
    }
}