using Xunit;

namespace MetroFramework.Tests
{
    public class MetroStyleTests
    {
        [Fact]
        public void MetroColorStyle_ShouldHaveAllExpectedValues()
        {
            var values = System.Enum.GetValues<MetroColorStyle>();
            
            Assert.Contains(MetroColorStyle.Black, values);
            Assert.Contains(MetroColorStyle.White, values);
            Assert.Contains(MetroColorStyle.Silver, values);
            Assert.Contains(MetroColorStyle.Blue, values);
            Assert.Contains(MetroColorStyle.Green, values);
            Assert.Contains(MetroColorStyle.Lime, values);
            Assert.Contains(MetroColorStyle.Teal, values);
            Assert.Contains(MetroColorStyle.Orange, values);
            Assert.Contains(MetroColorStyle.Brown, values);
            Assert.Contains(MetroColorStyle.Pink, values);
            Assert.Contains(MetroColorStyle.Magenta, values);
            Assert.Contains(MetroColorStyle.Purple, values);
            Assert.Contains(MetroColorStyle.Red, values);
            Assert.Contains(MetroColorStyle.Yellow, values);
        }

        [Fact]
        public void MetroThemeStyle_ShouldHaveLightAndDark()
        {
            var values = System.Enum.GetValues<MetroThemeStyle>();
            
            Assert.Contains(MetroThemeStyle.Light, values);
            Assert.Contains(MetroThemeStyle.Dark, values);
            Assert.Equal(2, values.Length);
        }

        [Theory]
        [InlineData(MetroColorStyle.Black, 0)]
        [InlineData(MetroColorStyle.White, 1)]
        [InlineData(MetroColorStyle.Silver, 2)]
        [InlineData(MetroColorStyle.Blue, 3)]
        [InlineData(MetroColorStyle.Green, 4)]
        public void MetroColorStyle_ShouldHaveCorrectNumericValues(MetroColorStyle style, int expectedValue)
        {
            Assert.Equal(expectedValue, (int)style);
        }

        [Theory]
        [InlineData(MetroThemeStyle.Light, 0)]
        [InlineData(MetroThemeStyle.Dark, 1)]
        public void MetroThemeStyle_ShouldHaveCorrectNumericValues(MetroThemeStyle theme, int expectedValue)
        {
            Assert.Equal(expectedValue, (int)theme);
        }
    }
}
