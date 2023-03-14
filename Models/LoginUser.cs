#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace TroyHsReunionPage.Models;
public class LoginUser
{

    [EmailAddress]
    [Required(ErrorMessage = "The Email Field is required!")]
    public string LEmail {get;set;}

    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    public string LPassword {get;set;}
    

}