using System.Collections.Generic;
using System.Linq;
using PBJProject.Domain.Models;

namespace PBJProject.Storing.Adapters
{
   public class SQLAdapter
   {
      private static readonly PbjDbContext _db = new PbjDbContext();

      public void PersistCharacter(Character character)
      {
         _db.Character.Add(character);
         _db.SaveChanges();
      }

      public List<Character> GetCharacters()
      {
         return _db.Character.ToList();
      }

      public List<Character> GetCharactersByAccountId(int accountId)
      {
         return _db.Character.Where(x => x.AccountId == accountId).ToList();
      }

      public int GetAccountIdByAccountUserName(string userName)
      {
         return _db.Account.FirstOrDefault(x => x.UserName == userName).AccountId;
      }

      public void PersistAccount(Account account)
      {
         _db.Account.Add(account);
         _db.SaveChanges();
      }
   }
}