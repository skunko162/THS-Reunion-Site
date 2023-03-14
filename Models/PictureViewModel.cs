#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TroyHsReunionPage.Models;

public class PictureViewModel
{
    [Required]
    public string Name {get;set;}
    [Required]
    public IFormFile Picture {get;set;}
}