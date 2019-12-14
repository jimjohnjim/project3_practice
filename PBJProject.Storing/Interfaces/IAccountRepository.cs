using PBJProject.Domain.Models;

namespace PBJProject.Storing.Repositories
{
  public interface IAccountRepository
  {
    void Create(Account account);
  }
}