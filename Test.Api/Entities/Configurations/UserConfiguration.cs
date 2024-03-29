using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Api.Entities.Configurations;

public class UserConfiguration : EntityBaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(b => b.Id);
        
        builder.Property(b => b.Id)
            .HasColumnType("integer");
        
        builder.Property(b => b.Phone)
            .HasColumnType("char(13)");
       
        builder.Property(b => b.Phone)
            .HasColumnType("varchar(64)");
        
        builder.HasMany<Result>(e => e.Results).
            WithOne(e => e.User).
            HasForeignKey(k => k.UserId).
            OnDelete(DeleteBehavior.Cascade);;
    }

}