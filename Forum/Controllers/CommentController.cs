using Forum.Data.Entities;
using Forum.Data.Infrastructure;
using Forum.Domain.ViewModels.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly IRepository<Comment> commentRepository;

        public CommentController(IRepository<Comment> commentRepository) => this.commentRepository = commentRepository;

        [Authorize]
        [HttpPost]
        [Route("~/Comment/Create")]
        public async Task<IActionResult> Create(CommentToAddViewModel model)
        {
            int selectedTopic = (int)TempData["SelectedTopic"];
            TempData.Keep();

            var comment = new Comment() { Text = model.Text, TopicId = selectedTopic, UserId = int.Parse(User.Identity.Name) };
            if(ModelState.IsValid)
            {
                await commentRepository.AddAsync(comment);
                await commentRepository.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Topic", new { id = selectedTopic });
        }

        [Authorize]
        [Route("~/Comment/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int selectedTopic = (int)TempData["SelectedTopic"];
            TempData.Keep();

            commentRepository.Delete(new Comment() { Id = id });
            await commentRepository.SaveChangesAsync();

            return RedirectToAction("Details", "Topic", new { id = selectedTopic });
        }
    }
}
