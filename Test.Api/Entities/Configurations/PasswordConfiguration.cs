using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Api.Entities.Configurations;

public class PasswordConfiguration : EntityBaseConfiguration<Password>
{
    public override void Configure(EntityTypeBuilder<Password> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnType("integer")
            .ValueGeneratedOnAdd();
        builder.Property(b => b.PasswordHash).
            HasColumnType("char(64)").
            IsRequired(true);
        builder.HasOne<User>(u => u.User).
            WithOne(w => w.Password).
            HasForeignKey<Password>(e => e.UserId);
    }

}