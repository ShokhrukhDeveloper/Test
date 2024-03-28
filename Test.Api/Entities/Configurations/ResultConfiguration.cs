using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Api.Entities.Configurations;

public class ResultConfiguration : EntityBaseConfiguration<Result>
{
    public override void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.HasOne<User>(e => e.User).WithMany(e => e.Results).HasForeignKey(e => e.UserId);
        builder.HasOne<Test>(e => e.Test).WithMany(e => e.Results).HasForeignKey(e => e.TestId);
        builder.HasMany<Answer>(q => q.Answers).WithOne(e => e.Result).HasForeignKey(k => k.ResultId);

    }
}