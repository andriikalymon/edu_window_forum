using Forum.Data.Entities;
using Forum.Data.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Forum.Domain.ViewModels.User;
using System.Linq;
using System.Threading.Tasks;
using Forum.Web.Utils;
using ProjectConstants = Forum.Web.Constants.Constants;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
                        await Authenticate(loginedUser.Id);
                        TempData["Username"] = loginedUser.Name;
                        return RedirectToAction("AllTopics", "Topic");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Password is incorrect");
                        return View(user);
                    } 
                }

                string userEmail = user.Email.Replace("@", "%40");
                string userPassword = user.Password;
                string link = 
                    ProjectConstants.LocalLink + "/User/ConfirmEmail?Email=" + userEmail + "&Password=" + userPassword;

                string text = $"Please confirm your registartion by following link: {link}";

                await EmailService.SendEmailAsync(
                    ProjectConstants.SenderEmail, 
                    ProjectConstants.SenderPassword, 
                    ProjectConstants.SenderName, 
                    user.Email, 
                    ProjectConstants.Topic, 
                    text);

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

            await Authenticate(userRepository.Query().FirstOrDefault(u => u.Email == email).Id);
            TempData["Username"] = user.Name;
            return RedirectToAction("AllTopics", "Topic");
        }

        private async Task Authenticate(int userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userId.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(
                claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        [Route("~/User/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Authenticate", "User");
        }
    }
}
