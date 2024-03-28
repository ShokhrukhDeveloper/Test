namespace Test.Api.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



public class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : class {
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        
    }
}