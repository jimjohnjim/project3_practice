using PBJProject.Domain.Models;
using Xunit;

namespace PBJProject.Testing.Specs.PBJProject.Domain.Models
{
   public class DiceTest
   {
      private const int ThreeDice = 3;
      private const int SixSided = 6;

      [Fact]
      public void Test_Dice_Roll_HasValues()
      {
         // arrange
         var sut = new Dice(ThreeDice, SixSided);

         // act
         sut.Roll();

         // assert
         Assert.NotEmpty(sut.Values);
      }

      [Fact]
      public void Test_Dice_Roll_HasValuesInRange()
      {
         // arrange
         var sut = new Dice(ThreeDice, SixSided);

         // act
         sut.Roll();

         // assert
         Assert.Collection(sut.Values, value => Assert.InRange(value, 1, 6),
                                       value => Assert.InRange(value, 1, 6),
                                       value => Assert.InRange(value, 1, 6)
         );
      }
   }
}