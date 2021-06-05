using Forum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Data.EntityConfigurations
{
    class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topic");
            builder.HasKey(topic => topic.Id);
            builder.Property(topic => topic.Name).IsRequired();
            builder.Property(topic => topic.Text).IsRequired();
            builder.HasOne(topic => topic.User)
                   .WithMany(user => user.Topics)
                   .HasForeignKey(topic => topic.UserId);
        }
    }
}
