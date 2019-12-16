using PBJProject.Domain.Models;
using PBJProject.Storing.Adapters;
using System.Collections.Generic;

namespace PBJProject.Storing.Repositories
{
  public class AccountRepository : IAccountRepository
  {
     private static readonly SQLAdapter _sqlAdapter = new SQLAdapter();
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
         
         this.AccountLibrary.Clear();
         this.AccountLibrary.AddRange(_sqlAdapter.GetAccounts());
      }

      public void Create(Account account)
      {
         _accountsRepository.Add(account);
         _sqlAdapter.PersistAccount(account);
      }

      public int GetAccountIdByAccountUserName(string userName)
      {
         return _sqlAdapter.GetAccountIdByAccountUserName(userName);
      }
  }
}