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
        builder.HasOne<Result>(q => q.Result).WithMany(e => e.Answers).HasForeignKey(k => k.ResultId);
        // builder.HasOne<Option>(q => q.SelectedOpion).WithMany(e => e.Answers).HasForeignKey(k => k.SelectedOpionId);
        // builder.HasOne<Option>(q => q.CorrectOpion).WithMany(e => e.Answers).HasForeignKey(k => k.CorrectOpionId);
        builder.HasOne<Question>(q => q.Question).WithMany(e => e.Answers).HasForeignKey(k => k.QuestionId);
        builder.HasOne<Test>(q => q.Test).WithMany(e => e.Answers).HasForeignKey(k => k.TestId);

    }  
}