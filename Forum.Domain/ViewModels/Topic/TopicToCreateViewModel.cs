using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
