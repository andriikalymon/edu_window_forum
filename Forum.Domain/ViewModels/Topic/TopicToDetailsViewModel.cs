using Forum.Domain.ViewModels.Comment;
using System.Collections.Generic;

namespace Forum.Domain.ViewModels.Topic
{
    public class TopicToDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Dislikes { get; set; }
        public int Likes { get; set; }
        public bool CanBeLikeDislike { get; set; }
        public ICollection<CommentToShowViewModel> Comments { get; set; } = new List<CommentToShowViewModel>();
        public ICollection<string> Tags { get; set; } = new List<string>();
    }
}
