using Microsoft.AspNetCore.Mvc;
using TroyHsReunionPage.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace TroyHsReunionPage.Controllers;

public class InternalController : Controller
{
    private readonly ILogger<InternalController> _logger;
    private MyContext _context;

    public InternalController(ILogger<InternalController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }
    [SessionCheck]
    [HttpGet("WelcomePage")]
    public IActionResult WelcomePage()
    {
        return View();
    }
    [SessionCheck]
    [HttpGet("Classmates")]
    public IActionResult Classmates()
    {
        return View();
    }
    [SessionCheck]
    [HttpGet("Schedule")]
    public IActionResult Schedule()
    {
        return View();
    }
    // Veiw stories_________________________
    [SessionCheck]
    [HttpGet("Stories")]
    public IActionResult Stories()
    {
        List<Story> AllStories = _context.Stories.Include(s => s.Creator).ToList();
        return View(AllStories);
    }
    //view one story________________________
    [SessionCheck]
    [HttpGet("story/{StoryId}")]
    public IActionResult VeiwOneStory(int StoryId)
    {
        Story? OneStory = _context.Stories.Include(s => s.Creator).FirstOrDefault(a => a.StoryId == StoryId);
        return View("ViewOneStory", OneStory);
    }

    //delete story__________________________
    [HttpPost("stories/{StoryId}/destroy")]
    public IActionResult DestroyStory(int StoryId)
    {
        Story? StoryToDestroy = _context.Stories.SingleOrDefault(a => a.StoryId == StoryId);
        if(StoryToDestroy==null)
        {
            return RedirectToAction("Stories");
        }
        _context.Remove(StoryToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Stories");
    }
}
