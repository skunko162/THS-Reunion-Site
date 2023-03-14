using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

using TroyHsReunionPage.Models;

namespace TroyHsReunionPage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context= context;
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("NewUser")]
    public IActionResult NewUser()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction ("Login");
        } else {
            return View("NewUser");
        }
    }
    [HttpGet("Login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("users/login")]
    public IActionResult UserLogin(LoginUser LogUser)
    {
        if(ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == LogUser.LEmail);
            if(userInDb ==null)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Login");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(LogUser, userInDb.Password, LogUser.LPassword);
            if(result == 0)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Login");
            } else {
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("WelcomePage", "Internal");
            }
        } else {
            return View("Login");
        }
    }
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    //image upload.......


}
public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            if(userId == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
