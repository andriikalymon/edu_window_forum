using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Entities
{
    public class Topic : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
