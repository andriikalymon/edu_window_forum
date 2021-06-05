using Forum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Forum.Data.EntityConfigurations
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(comment => comment.Id);
            builder.Property(comment => comment.Text).IsRequired();
            builder.HasOne(comment => comment.User)
                   .WithMany(user => user.Comments)
                   .HasForeignKey(comment => comment.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(commnent => commnent.Topic)
                   .WithMany(topic => topic.Comments)
                   .HasForeignKey(comment => comment.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
