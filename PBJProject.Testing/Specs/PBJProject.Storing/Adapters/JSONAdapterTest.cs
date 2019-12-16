using PBJProject.Domain.Models;
using PBJProject.Storing.Adapters;
using Xunit;

namespace PBJProject.Testing.Specs.PBJProject.Storing.Adapters
{
   public class JSONAdapterTest
   {
      [Fact]
      public void Test_ValidateJSONWithBadData()
      {
         // arrange
         var sut = new JSONAdapter();
         var schema = new JSONSchemas();
         var testString = @"{
               CPU: 'Intel',
               Drives: [
                  'DVD read/writer',
                  '500 gigabyte hard drive'
               ]
         }";

         // act
         var actual = sut.ValidateJSON(testString, schema.SchemaDnD);

         // assert
         Assert.False(actual);
      }

      [Fact]
      public void Test_ValidateJSONWithGoodData()
      {
         //arrange
         var sut = new JSONAdapter();
         var schema = new JSONSchemas();
         var testString = @"{
            'Name': 'Geralt of Rivia',
            'Race': 'Mutant',
            'CharacterClass': 'Witcher',
            'Level': 100,
            'Strength': 18,
            'Intelligence': 16,
            'Dexterity': 22,
            'Wisdom': 16,
            'Charisma': 12,
            'Constitution': 18
         }";

         // act
         var actual = sut.ValidateJSON(testString, schema.SchemaDnD);

         // assert
         Assert.True(actual);
      }

      [Fact]
      public void Test_LoadWithBadDataReturnsNull()
      {
         // arrange
         var sut = new JSONAdapter();
         var schema = new JSONSchemas();
         var testString = @"{
               CPU: 'Intel',
               Drives: [
                  'DVD read/writer',
                  '500 gigabyte hard drive'
               ]
         }";

         // act
         var actual = sut.Load(testString);

         // assert
         Assert.Null(actual);
      }

      [Fact]
      public void Test_LoadWithGoodDataReturnsCharacter()
      {
         // arrange
         var sut = new JSONAdapter();
         var schema = new JSONSchemas();
         var testString = @"{
            'Name': 'Geralt of Rivia',
            'Race': 'Mutant',
            'CharacterClass': 'Witcher',
            'Level': 100,
            'Strength': 18,
            'Intelligence': 16,
            'Dexterity': 22,
            'Wisdom': 16,
            'Charisma': 12,
            'Constitution': 18
         }";

         // act
         var actual = sut.Load(testString);

         // assert
         Assert.IsType<Character>(actual);
      }
   }
}