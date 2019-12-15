using System;

namespace PBJProject.Domain.Models
{
  public class Character
  {
    public int CharacterId { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public int Constitution { get; set; }
    public string CharacterClass { get; set; }

    public virtual Account Account { get; set; }
    public Nullable<int> AccountId { get; set; }
  }
}