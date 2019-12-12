using PBJProject.Domain.Models;

namespace PBJProject.Storing.Repositories
{
  public interface ICharacterRepository
  {
    void Create(Character character, string path);
  }
}