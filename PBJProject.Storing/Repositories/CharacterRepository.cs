using System.Collections.Generic;
using PBJProject.Domain.Models;
using PBJProject.Storing.Adapters;

namespace PBJProject.Storing.Repositories
{
  public class CharacterRepository : ICharacterRepository
  {
     private List<Character> _characterRepository;
     private static readonly JSONAdapter _jsonAdapter = new JSONAdapter();

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
     public void Create(Character character, string path)
     {
        _jsonAdapter.Create(character, path);
        _characterRepository.Add(character);
     }

     public void LoadCharacters(string path)
     {
        List<Character> charactersList = new List<Character>();
        charactersList = _jsonAdapter.Load(path);
        _characterRepository.Clear();
        _characterRepository.AddRange(charactersList);
     }
  }
}