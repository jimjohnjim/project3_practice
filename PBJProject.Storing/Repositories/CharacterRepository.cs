using System.Collections.Generic;
using PBJProject.Domain.Models;

namespace PBJProject.Storing.Repositories
{
  public class CharacterRepository : IRepository<Character>
  {
     private List<Character> _characterRepository;

     public List<Character> CharacterLibrary
     {
        get => _characterRepository;
     }
     public CharacterRepository()
     {
        Initialize();
     }

     private void Initialize()
     {
        if(_characterRepository == null)
        {
           _characterRepository = new List<Character>();
        }
     }
     public void Create(Character character)
     {
        _characterRepository.Add(character);
     }
  }
}