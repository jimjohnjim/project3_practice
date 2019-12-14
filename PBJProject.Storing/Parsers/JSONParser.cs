using PBJProject.Domain.Models;
using Newtonsoft.Json;
using System.IO;

namespace PBJProject.Storing.Parsers
{
   public class JSONParser
   {
      private const string jsonExtension = ".json";
      public Character DeserializeJSON(string file)
      {
         Character character = new Character();
         character = JsonConvert.DeserializeObject<Character>(file);
         return character;
      }

      public void SerializeJSON(Character character, string path)
      {
         string jsonOutput = JsonConvert.SerializeObject(character);
         path = path + "\\" + character.FileName + jsonExtension;
         File.WriteAllText(path, jsonOutput);
      }
   }
}