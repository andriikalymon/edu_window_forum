using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.ViewModels.Comment
{
    public class CommentToAddViewModel
    {
        public string Text { get; set; }
        public int TopicId { get; set; }
    }
}
