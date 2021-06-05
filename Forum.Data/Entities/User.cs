using System.Collections.Generic;

namespace Forum.Data.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
