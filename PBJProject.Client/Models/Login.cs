using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PBJProject.Client.Validations;

namespace PBJProject.Client.Models
{
  public class Login
  {
    [Required(ErrorMessage="Please enter a valid username.")]
    [UserName]
    [Alpha]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [PassWord]
    public string Password { get; set; }

    [Required]
    [Alpha]
    public string FirstName {get; set;}

    [Required]
    [Alpha]
    public string LastName { get; set; }
    public string Email { get; set; }
  }
}