using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PBJProject.Domain.Models
{
  public class ChatParser
  {
    public List<int> GetRoll(string input)
    {
      Regex rx = new Regex(@"\d*d\d*$",RegexOptions.IgnoreCase);
      Match match = rx.Match(input);
      
      var dice = match.Value.Split('d');
  
      int.TryParse(dice[0], out int numDice);
      int.TryParse(dice[1], out int typeDice);

      return new List<int>(){numDice,typeDice};
    }
  }
}