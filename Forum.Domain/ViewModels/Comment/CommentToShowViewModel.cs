using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.ViewModels.Comment
{
    public class CommentToShowViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public bool CanBeDeleted { get; set; }
    }
}
