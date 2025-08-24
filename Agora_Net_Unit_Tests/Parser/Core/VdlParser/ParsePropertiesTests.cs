namespace AgoraNet.Tests.Parser.Core.VdlParser
{
    public class ParsePropertiesTests
    {
        [Fact]
        public void ParseProperties_ShouldExtractSimpleProperties()
        {
            //Arrange
            string rawElement = "[Square : x = 10, y = 10, z = -1, fillColor = #808080, opacity = 0.80, size = 15]";

            // Act
            Dictionary<string, string>? result = typeof(AgoraNet.Core.Parser.Core.VdlParser)
                .GetMethod("ParseProperties", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!
                .Invoke(null, new object[] { rawElement }) as Dictionary<string, string>;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("10", result["x"]);
            Assert.Equal("20", result["y"]);
            Assert.Equal("-1", result["z"]);
            Assert.Equal("#808080", result["fillColor"]);
            Assert.Equal("0.80", result["opacity"]);
            Assert.Equal("15", result["size"]);
        }
    }
}