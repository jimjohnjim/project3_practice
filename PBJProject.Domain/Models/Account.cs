using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PBJProject.Domain.Models;

namespace PBJProject.Domain.Models
{
  public class Account
  {
    public int AccountId { get; set; }
    public string UserName { get; set; }
    public string FirstName {get; set;}
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    [NotMapped]
    public List<Character> MyCharacters { get; set; }

    public virtual ICollection<Character> Characters { get; set; }
  }
}