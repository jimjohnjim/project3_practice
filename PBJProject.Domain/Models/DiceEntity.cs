using System.ComponentModel.DataAnnotations.Schema;

namespace PBJProject.Domain.Models
{
   public class DiceEntity
   {
      public int PrimaryId { get; set; }
      public int Value { get; set; }
      public int Sum { get; set; }
      public int Highest { get; set; }
      public int RollId { get; set; }
   }
}