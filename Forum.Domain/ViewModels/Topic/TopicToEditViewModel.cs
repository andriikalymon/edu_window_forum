using System.ComponentModel.DataAnnotations;

namespace Forum.Domain.ViewModels.Topic
{
    public class TopicToEditViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }
    }
}
