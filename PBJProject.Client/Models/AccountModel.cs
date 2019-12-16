using System.Collections.Generic;
//using PBJProject.Domain.Models;

namespace PBJProject.Client.Models
{
  public class AccountModel
  {
    public int AccountId { get; set; }
    public string UserName { get; set; }
    public string FirstName {get; set;}
    public string LastName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    //public List<Character> MyCharacters { get; set; }
  }
}