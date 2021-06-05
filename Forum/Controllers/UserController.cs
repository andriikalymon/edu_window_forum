using Forum.Data.Entities;
using Forum.Data.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Forum.Domain.ViewModels.User;
using System.Linq;
using System.Threading.Tasks;
using Forum.Web.Email;
using ProjectConstants = Forum.Web.Constants.Constants;

namespace Forum.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IRepository<User> userRepository;

        public UserController(IRepository<User> userRepository) => this.userRepository = userRepository;

        [HttpGet]
        [Route("~/User/Authenticate")]
        public IActionResult Authenticate() => View();

        [HttpPost]
        [Route("~/User/Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var loginedUser = userRepository.Query().FirstOrDefault(u => u.Email == user.Email);

                if (loginedUser is not null)
                {
                    if (loginedUser.Password == user.Password)
                    {
                        TempData["UserId"] = loginedUser.Id;
                        return RedirectToAction("Authenticate", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Password is incorrect");
                        return View(user);
                    } 
                }

                string userEmail = user.Email.Replace("@", "%40");
                string userPassword = user.Password;
                string link = ProjectConstants.LocalLink + "/User/ConfirmEmail?Email=" + userEmail + "&Password=" + userPassword;

                string text = $"Please confirm your registartion by following link: {link}";
                string senderEmail = "edu.window.sender@gmail.com";
                string senderPassword = "edu_window_sender_2021";
                string senderName = "EduWindow";
                string topic = "Authentication";

                await EmailService.SendEmailAsync(senderEmail, senderPassword, senderName, user.Email, topic, text);

                return RedirectToAction("SuccessfulAuthenticate", "User");
            }
            return View(user);
        }

        [HttpGet]
        [Route("~/User/SuccessfulAuthenticate")]
        public IActionResult SuccessfulAuthenticate()
        {
            return View();
        }

        [HttpGet]
        [Route("~/User/ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email, string password)
        {
            if (email == null || password == null)
            {
                return View("Error");
            }
            var user = new User() { Email = email, Password = password, Name = email.Substring(0, email.IndexOf("@")) };
            
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();

            TempData["UserId"] = userRepository.Query().FirstOrDefault(u => u.Email == email).Id;

            return RedirectToAction("Authenticate", "User");
        }
    }
}
