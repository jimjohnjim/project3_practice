using System.Collections.Generic;
using PBJProject.Domain.Models;
using PBJProject.Storing.Adapters;

namespace PBJProject.Storing.Repositories
{
  public class CharacterRepository : ICharacterRepository
  {
     private List<Character> _characterRepository;
     private static readonly JSONAdapter _jsonAdapter = new JSONAdapter();
     private static readonly SQLAdapter _sqlAdapter = new SQLAdapter();

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
        this.CharacterLibrary.Clear();
        this.CharacterLibrary.AddRange(_sqlAdapter.GetCharacters());
     }

     public void Load(string characterBlob)
     {
        Character character = _jsonAdapter.Load(characterBlob);
        _characterRepository.Add(character);
        _sqlAdapter.PersistCharacter(character);
     }
  }
}