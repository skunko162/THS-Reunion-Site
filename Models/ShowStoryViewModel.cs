#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TroyHsReunionPage.Models;

public class ShowStoryViewModel
{
    public Story Story {get;set;}
    public List<Story> AllStories {get;set;}
    public string Picture {get;set;}
    public User OneUser {get;set;}
    public User User {get;set;}
    public User? Creator {get;set;}
}