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

        Character character1 = new Character();

        character1.Level = 1;
        character1.Name = "Dummy";
        character1.Strength = 18;
        character1.Intelligence = 8;
        character1.Dexterity = 12;
        character1.Wisdom = 10;
        character1.Charisma = 10;
        character1.Constitution = 16;
        character1.CharacterClass = "Strongman";

        _characterRepository.Add(character1);
     }
     public void Create(Character character)
     {
        _characterRepository.Add(character);
     }
  }
}