using PBJProject.Storing.Adapters;
using Xunit;

namespace PBJProject.Testing.Specs.PBJProject.Storing.Adapters
{
   public class JSONAdapterTest
   {
      [Fact]
      public void Test_ValidateJSON()
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
   }
}