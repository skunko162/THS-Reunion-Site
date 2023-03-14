#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TroyHsReunionPage.Models;

public class Story
{   
    [Key]
    public int StoryId {get;set;}
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string ImageUrl {get;set;}
    public string Content {get;set;}
    public DateTime CreatedAt {get;set;}=DateTime.Now;
    public DateTime UpdatedAt {get;set;}=DateTime.Now;
//one to manny--------------------------------
    public int UserId {get;set;}
    public User? Creator {get;set;}
}