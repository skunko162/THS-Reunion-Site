#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TroyHsReunionPage.Models;
public class User


{
    [Key]
    public int UserId {get;set;}
    [Required (ErrorMessage = "The First Name Is required")]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters in Length")]
    public string FirstName {get;set;}
    [Required]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters in Length")]
    public string LastName {get;set;}
    [Required]
    [MinLength(2, ErrorMessage = "Username must be at least 2 characters in Length")]
    public string Username {get;set;}
    [EmailAddress]
    [UniqueEmail]
    [Required]
    public string Email {get;set;}
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters in length")]
    public string Password {get;set;}
    public DateTime CreatedAt {get;set;}=DateTime.Now;
    public DateTime UpdatedAt {get;set;}=DateTime.Now;

    // Form my one to many relationship--------------
    public List<Story> CreatedStories {get;set;} = new List<Story>();

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name = "Confirm Password")]
    public string Confirm {get;set;}
}
public class UniqueEmailAttribute :ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Email is required!");
        }
        MyContext _context = (MyContext) validationContext.GetService(typeof(MyContext));
        if(_context.Users.Any(e => e.Email == value.ToString()))
        {
            return new ValidationResult("Email must be unique!");
        } else {
            return ValidationResult.Success;
        }
    }

}