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

      public void PersistAccount(Account account)
      {
         _db.Account.Add(account);
         _db.SaveChanges();
      }
   }
}