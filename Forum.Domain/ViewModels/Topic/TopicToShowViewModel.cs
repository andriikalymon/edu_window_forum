using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.ViewModels.Topic
{
    public class TopicToShowViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public bool CanBeEdited { get; set; }
        public ICollection<string> Tags { get; set; } = new List<string>();
    }
}
