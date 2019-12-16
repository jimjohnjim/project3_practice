using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PBJProject.Domain.Models;
using PBJProject.Storing.Repositories;

namespace PBJProject.Client.Validations
{
  public class PassWord : ValidationAttribute
  {
     private static readonly AccountRepository _ar = new AccountRepository();
    public override bool IsValid(object o)
    {
      var s = o as string;
      Account account = new Account();
      account.Password = s;

      if(_ar.AccountLibrary.Where(x => x.Password == s).FirstOrDefault() == null)
      {
         return false;
      }

      return true;
    }
  }
}