using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using PBJProject.Domain.Models;
using PBJProject.Storing.Parsers;

namespace PBJProject.Storing.Adapters
{
   public class JSONAdapter
   {
      private const string jsonExtension = ".json";
      private static readonly JSONParser _jsonParser = new JSONParser();

      public void Create(Character character, string path)
      {
         _jsonParser.SerializeJSON(character, path);
      }

      public List<Character> Load(string path)
      {
         Character character = new Character();
         List<Character> characterList = new List<Character>();
         string jsonString = "";

         List<string> filesList = GetFilesAtPath(path);

         foreach(var jsonFile in filesList)
         {
            jsonString = File.ReadAllText(jsonFile);
            if(ValidateJSON(jsonString))
            {
               character = _jsonParser.DeserializeJSON(jsonString);
               characterList.Add(character);
            }
         }

         return characterList;
      }

      private List<string> GetFilesAtPath(string path)
      {
         List<Character> characterList = new List<Character>();

         string[] fileArray = Directory.GetFiles(path);
         List<string> filesList = new List<string>();
         string fileExtension = "";
         
         foreach(var item in fileArray)
         {
            fileExtension = Path.GetExtension(item);
            if(fileExtension == jsonExtension)
            {
               filesList.Add(item);
            }
         }

         return filesList;
      }

      private bool ValidateJSON(string jsonString)
      {
         string characterSchemaString = @"{
         'description': 'Character schema',
         'type': 'object',
         'properties':
         {
            'Name': { 'type': 'string' },
            'Race': { 'type': 'string' },
            'CharacterClass': { 'type': 'string'},
            'Level': { 'type': 'integer' },
            'Strength': { 'type': 'integer' },
            'Intelligence': { 'type': 'integer' },
            'Dexterity': { 'type': 'integer' },
            'Wisdom': { 'type': 'integer' },
            'Charisma': { 'type': 'integer' },
            'Constitution': { 'type': 'integer' },
            'FileName': { 'type': 'string' }
            },
            'additionalProperties': false
         }";

         JSchema characterSchema = JSchema.Parse(characterSchemaString);
         JObject tempObject = JObject.Parse(jsonString);
         
         return tempObject.IsValid(characterSchema);
      }
   }
}