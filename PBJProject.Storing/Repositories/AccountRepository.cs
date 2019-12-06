using System.Collections.Generic;
using PBJProject.Domain.Models;

namespace PBJProject.Storing.Repositories
{
  public class AccountRepository : IRepository<Account>
  {
      private List<Account> _accountsRepository;
      
      public List<Account> AccountLibrary
      {
         get => _accountsRepository;
      }

      public AccountRepository()
      {
         Initialize();
      }

      private void Initialize()
      {
         if(_accountsRepository == null)
         {
            _accountsRepository = new List<Account>();
         }

         Account account1 = new Account();
         account1.UserName = "Phillip";
         _accountsRepository.Add(account1);

         Account account2 = new Account();
         account2.UserName = "Joshua";
         _accountsRepository.Add(account2);

         Account account3 = new Account();
         account3.UserName = "Benjamin";
         _accountsRepository.Add(account3);
      }

      public void Create(Account account)
      {
         _accountsRepository.Add(account);
      }
   }
}