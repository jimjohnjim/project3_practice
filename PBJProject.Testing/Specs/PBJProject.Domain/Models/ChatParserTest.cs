using System;
using System.Collections.Generic;
using PBJProject.Domain.Models;
using Xunit;

namespace PBJProject.Testing.Specs.PBJProject.Domain.Models
{
  public class ChatParserTest
  {
    [Fact]
    public void Test_GetRoll()
    {
      var sut = new ChatParser();
      var expected = new List<int>(){1,20};

      var actual = sut.GetRoll("The bridge has collapsed! Roll 1d20");

      Assert.Equal(expected,actual);
    }
  }
}