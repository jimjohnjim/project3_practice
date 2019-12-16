using PBJProject.Domain.Models;
using PBJProject.Storing.Adapters;
using System.Collections.Generic;

namespace PBJProject.Storing.Repositories
{
  public class DiceRepository
  {
     private static readonly SQLAdapter _sqlAdapter = new SQLAdapter();
      private List<DiceEntity> _diceRepository;
      
      public List<DiceEntity> DiceLibrary
      {
         get => _diceRepository;
      }

      public DiceRepository()
      {
         Initialize();
      }

      private void Initialize()
      {
         if(_diceRepository == null)
         {
            _diceRepository = new List<DiceEntity>();
         }
         
         this.DiceLibrary.Clear();
         this.DiceLibrary.AddRange(_sqlAdapter.GetDice());
      }

      public void Create(DiceEntity dice)
      {
         _diceRepository.Add(dice);
         _sqlAdapter.PersistDice(dice);
      }

      public void Save()
      {
         _sqlAdapter.Save();
      }
  }
}