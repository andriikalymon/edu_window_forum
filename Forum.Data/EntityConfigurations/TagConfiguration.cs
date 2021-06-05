using Forum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Data.EntityConfigurations
{
    class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.HasKey(tag => tag.Id);
            builder.Property(tag => tag.Name).IsRequired();
        }
    }
}
