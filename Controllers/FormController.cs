using Microsoft.AspNetCore.Mvc;
using TroyHsReunionPage.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace TroyHsReunionPage.Controllers;

public class FormController : Controller
{
    private readonly ILogger<FormController> _logger;
    private MyContext _context;

    public FormController(ILogger<FormController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

// Create a new Where are they now story

    [SessionCheck]
    [HttpGet("NewStory")]
    public IActionResult NewStory()
    {
        return View("NewStory");
    }


    [SessionCheck]
    [HttpPost("story/create")]
    
    public IActionResult CreateStory(Story newStory)
    {
        if(ModelState.IsValid)
        {
            newStory.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newStory);
            _context.SaveChanges();
            return RedirectToAction("ClassMates", newStory);
        } else {
            return View("NewStory");
        }
    }
    
    // Edit Classmate stories ________________________
    [SessionCheck]
    [HttpGet("stories/{StoryId}/edit")]

    public IActionResult EditStory(int StoryId)
    {
        Story? StoryToEdit = _context.Stories.FirstOrDefault(i => i.StoryId == StoryId);
        return View(StoryToEdit);
    }
    

    [SessionCheck]
    [HttpPost("stories/{StoryId}/update")]

    public IActionResult UpdateStory(Story newStory, int StoryId)
    {
        if(ModelState.IsValid)
        {
            Story? OldStory = _context.Stories.FirstOrDefault(i => i.StoryId == StoryId);
        
        
            OldStory.FirstName = newStory.FirstName;
            OldStory.ImageUrl = newStory.ImageUrl;
            OldStory.LastName = newStory.LastName;
            OldStory.Content = newStory.Content;

            _context.SaveChanges();
            return RedirectToAction("Stories", "Internal");
        } else {
            return RedirectToAction("EditStory");
        }

    }   
}