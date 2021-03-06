using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.ViewModels.Topic
{
    public class TopicToCreateViewModel
    {
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }
        public IEnumerable<int> Tags { get; set; } = new List<int>();
    }
}
