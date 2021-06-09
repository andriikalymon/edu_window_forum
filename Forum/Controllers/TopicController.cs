using Forum.Data.Entities;
using Forum.Data.Infrastructure;
using Forum.Domain.ViewModels.Comment;
using Forum.Domain.ViewModels.Topic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class TopicController : Controller
    {
        private readonly IRepository<Topic> topicRepository;

        public TopicController(IRepository<Topic> topicRepository) => this.topicRepository = topicRepository;

        [Route("~/Topic/AllTopics")]
        public IActionResult AllTopics()
        {
            int currentUserId = int.Parse(User.Identity.Name);

            return View(topicRepository.Query().Select(
                t => new TopicToShowViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Text = t.Text.Substring(0, 180) + " ...",
                    CanBeEdited = t.UserId == currentUserId,
                    Tags = t.Tags.Select(tag => tag.Name).ToList()
                }));
        }

        [HttpGet]
        [Route("~/Topic/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            var topic = await topicRepository.GetByIdAsync(id);

            if(topic is not null)
            {
                return View((new TopicToDetailsViewModel()
                {
                    Id = topic.Id,
                    Name = topic.Name,
                    Text = topic.Text,
                    Comments = topic.Comments.Select(c => 
                    new CommentToShowViewModel()
                    {
                        Id = c.Id,
                        Text = c.Text,
                        UserName = c.User.Name,
                        CanBeDeleted = currentUserId == c.UserId
                    }).ToList(),
                    Tags = topic.Tags.Select(tag => tag.Name).ToList()
                }, new CommentToAddViewModel()));
            }

            return RedirectToAction("AllTopics", "Topic");
        }

        [Route("~/Topic/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            topicRepository.Delete(new Topic() { Id = id });
            await topicRepository.SaveChangesAsync();

            return RedirectToAction("AllTopics", "Topic");
        }
    }
}
