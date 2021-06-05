using Forum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Data.EntityConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.Id);
            builder.Property(user => user.Email).IsRequired();
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.Name).IsRequired();
        }
    }
}
