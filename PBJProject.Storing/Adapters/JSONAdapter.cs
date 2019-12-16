using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using PBJProject.Domain.Models;
using PBJProject.Storing.Parsers;

namespace PBJProject.Storing.Adapters
{
   public class JSONAdapter
   {
      private static readonly JSONParser _jsonParser = new JSONParser();
      private static readonly JSONSchemas _jsonSchema = new JSONSchemas();

      public Character Load(string characterBlob)
      {
         Character character = new Character();

         if(ValidateJSON(characterBlob, _jsonSchema.SchemaDnD))
         {
               character = _jsonParser.DeserializeJSON(characterBlob);
               return character;
         }
         
         return null;
      }

      public bool ValidateJSON(string jsonString, string schema)
      {
         JSchema characterSchema = JSchema.Parse(schema);
         JObject tempObject = JObject.Parse(jsonString);
         
         return tempObject.IsValid(characterSchema);
      }
   }
}