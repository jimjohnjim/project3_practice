using PBJProject.Domain.Models;
using Newtonsoft.Json;
using System.IO;

namespace PBJProject.Storing.Parsers
{
   public class JSONParser
   {
      private const string jsonExtension = ".json";
      
      public Character DeserializeJSON(string characterBlob)
      {
         Character character = new Character();
         return JsonConvert.DeserializeObject<Character>(characterBlob);
      }

      public void SerializeJSON(Character character)
      {
         string jsonOutput = JsonConvert.SerializeObject(character);
      }
   }
}