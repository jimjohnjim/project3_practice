namespace PBJProject.Domain.Models
{
  public class Character
  {
    public int ID { get; set; }
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
    public int AccountID { get; set; }
    public string FileName { get; set; }

    public virtual Account Account { get; set; }
  }
}