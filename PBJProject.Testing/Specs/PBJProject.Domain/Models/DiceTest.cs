using PBJProject.Domain.Models;
using Xunit;

namespace PBJProject.Testing.Specs.PBJProject.Domain.Models
{
   public class DiceTest
   {
      private const int FourDice = 4;
      private const int ThreeDice = 3;
      private const int TwoDice = 2;
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

      [Theory]
      [InlineData(ThreeDice, SixSided)]
      public void Test_Dice_Roll_HasValuesInRange(int numDice, int sidesDice)
      {
         // arrange
         var sut = new Dice(numDice, sidesDice);

         // act
         sut.Roll();

         // assert
         Assert.Collection(sut.Values, value => Assert.InRange(value, 1, sidesDice),
                                       value => Assert.InRange(value, 1, sidesDice),
                                       value => Assert.InRange(value, 1, sidesDice)
         );
      }

      [Theory]
      [InlineData(new int[] {1, 2, 3})]
      public void Test_Dice_Sum(int[] values)
      {
         // arrange
         var sut = new Dice(ThreeDice, SixSided);

         // act
         sut.Values.AddRange(values);

         // assert
         Assert.Equal(sut.Sum, 6);
      }

      [Theory]
      [InlineData(new int[] {1, 2, 3})]
      public void Test_Dice_Highest(int[] values)
      {
         // arrange
         var sut = new Dice(ThreeDice, SixSided);

         // act
         sut.Values.AddRange(values);

         // assert
         Assert.Equal(sut.Highest, 3);
      }

      [Theory]
      [InlineData(ThreeDice)]
      public void Test_Dice_RemoveOneDieFromPool(int numDice)
      {
         // arrange
         var sut = new Dice(numDice, SixSided);

         // act
         sut.RemoveOneDieFromPool();

         // assert
         Assert.Equal(sut.NumberOfDice, 2);
      }

      [Theory]
      [InlineData(ThreeDice)]
      public void Test_Dice_AddOneDieToPool(int numDice)
      {
         // arrange
         var sut = new Dice(numDice, SixSided);

         // act
         sut.AddOneDieToPool();

         // assert
         Assert.Equal(sut.NumberOfDice, 4);
      }
   }
}