using System.Collections.Generic;

namespace PBJProject.Client.Models
{
  public class Dice
  {
    public int NumberOfSides { get; set; }
    public int NumberOfDice { get; set; }
    public List<int> Values { get; set; }
    public int Sum { get; set; }
    public int Highest { get; set; }
  }
}