using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PBJProject.Client.Validations
{
  public class Alpha : ValidationAttribute
  {
     public override bool IsValid(object o)
     {
        var s = o as string;

        if(Regex.IsMatch(s, @"^[a-zA-Z]+$"))
        {
           return true;
        }
        return false;
     }
  }
}