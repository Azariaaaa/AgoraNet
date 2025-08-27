using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgoraNet.Core.Models;

namespace AgoraNet.Tests.Parser.Core.VdlParser
{
    public class ParseListTests
    {
        [Fact]
        public void ParseList_ShouldReturnCorrectNumberOfElements()
        {
            //Arrange
            List<string> testRawElements = new List<string>
            {
                "[Square : x = 25, y = 40, z = 0, fillColor = #FF5733, opacity = 0.65, size = 20]",
                "[Square : x = -15, y = 80, z = 3, fillColor = #33FF99, opacity = 0.50, size = 10]",
                "[Text : x = 100, y = -20, z = 5, fillColor = #FFA500, opacity = 1, content = Another Example, fontFamilly = Times New Roman, fontSize = 16]",
                "[Square : x = 5, y = -30, z = -2, fillColor = #123456, opacity = 0.75, size = 25]",
                "[Text : x = 200, y = 60, z = -1, fillColor = #808000, opacity = 0.85, content = Lorem Ipsum, fontFamilly = Calibri, fontSize = 18]"
            };

            // Act
            List<Element>? result = typeof(AgoraNet.Core.Parser.Core.VdlParser)
                .GetMethod("ParseList", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!
                .Invoke(null, new object[] { testRawElements }) as List<Element>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.Count, testRawElements.Count);
        }
    }
}
