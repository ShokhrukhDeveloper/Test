using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Api.Entities.Configurations;

public class AnswerConfiguration: EntityBaseConfiguration<Answer>
{
    public override void Configure(EntityTypeBuilder<Answer> builder)
    {
        base.Configure(builder);
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.Property(b => b.TestId).IsRequired(true);
        builder.Property(b => b.ResultId).IsRequired(true);
        builder.Property(b => b.QuestionId).IsRequired(true);
        builder.Property(b => b.CorrectOpionId).IsRequired(true);
        builder.Property(b => b.SelectedOpionId).IsRequired(true);
    }  
}