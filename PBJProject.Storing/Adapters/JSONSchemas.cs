namespace PBJProject.Storing.Adapters
{
   public class JSONSchemas
   {
      public string SchemaDnD
      {
         get
         {
            return @"{
            'description': 'Dungeons&Dragons character schema',
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
                  'Constitution': { 'type': 'integer' }
               },
               'additionalProperties': false
            }";
         }
      }
      public string SchemaVampire
      {
         get
         {
            return @"{
         'description': 'Vampire: The Masquerade character schema',
         'type': 'object',
         'properties':
            {
               'Name': { 'type': 'string' },
               'Player': { 'type': 'string' },
               'Chronicle': { 'type': 'string' },
               'Nature': { 'type': 'string' },
               'Demeanor': { 'type': 'string' },
               'Concept': { 'type': 'string' },
               'Clan': { 'type': 'string' },
               'Generation': { 'type': 'int' },
               'Sire': { 'type': 'string' },

               'Strength': { 'type': 'int' },
               'Dexterity': { 'type': 'int' },
               'Stamina': { 'type': 'int' },
               'Charisma': { 'type': 'int' },
               'Manipulation': { 'type': 'int' },
               'Appearance': { 'type': 'int' },
               'Perception': { 'type': 'int' },
               'Intelligence': { 'type': 'int' },
               'Wit': { 'type': 'int' }
            },
            'additionalProperties': false
            }";
         }
      }
   }
}