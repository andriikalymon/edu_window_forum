using System.Collections.Generic;

namespace Forum.Data.Entities
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
