using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using PBJProject.Domain.Models;
using PBJProject.Storing.Parsers;
using PBJProject.Storing.Adapters;

namespace PBJProject.Storing.Adapters
{
   public class JSONAdapter
   {
      private const string jsonExtension = ".json";
      private static readonly JSONParser _jsonParser = new JSONParser();
      private static readonly JSONSchemas _jsonSchema = new JSONSchemas();

      // public Character Create(string characterBlob)
      // {
      //    return _jsonParser.SerializeJSON(characterBlob);
      // }

      public Character Load(string characterBlob)
      {
         Character character = new Character();
         string jsonString = "";

         if(ValidateJSON(characterBlob, _jsonSchema.SchemaDnD))
         {
               character = _jsonParser.DeserializeJSON(jsonString);
               return character;
         }
         return null;
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

      private bool ValidateJSON(string jsonString, string schema)
      {
         JSchema characterSchema = JSchema.Parse(schema);
         JObject tempObject = JObject.Parse(jsonString);
         
         return tempObject.IsValid(characterSchema);
      }
   }
}