using Forum.Data.Entities;
using Forum.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Forum.Data.Context
{
    public class ForumContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .HasMany(t => t.Topics)
                .WithMany(topic => topic.Tags)
                .UsingEntity(j => j.ToTable("TopicTag"));

            modelBuilder.Entity<Topic>()
                .HasMany(t => t.UserLikes)
                .WithMany(u => u.TopicLikes)
                .UsingEntity(j => j.ToTable("TopicUserLike"));

            modelBuilder.Entity<Topic>()
                .HasMany(t => t.UserDislikes)
                .WithMany(u => u.TopicDislikes)
                .UsingEntity(j => j.ToTable("TopicUserDislike"));

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }
}
