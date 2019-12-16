using PBJProject.Domain.Models;

namespace PBJProject.Storing.Repositories
{
  public interface ICharacterRepository
  {
     void Load(string character);
  }
}