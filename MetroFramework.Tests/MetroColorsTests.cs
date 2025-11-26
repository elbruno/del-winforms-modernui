using System.Drawing;
using Xunit;

namespace MetroFramework.Tests
{
    public class MetroColorsTests
    {
        [Fact]
        public void Black_ShouldReturnCorrectColor()
        {
            var color = MetroColors.Black;
            
            Assert.Equal(0, color.R);
            Assert.Equal(0, color.G);
            Assert.Equal(0, color.B);
        }

        [Fact]
        public void White_ShouldReturnCorrectColor()
        {
            var color = MetroColors.White;
            
            Assert.Equal(255, color.R);
            Assert.Equal(255, color.G);
            Assert.Equal(255, color.B);
        }

        [Fact]
        public void Blue_ShouldReturnCorrectColor()
        {
            var color = MetroColors.Blue;
            
            Assert.Equal(0, color.R);
            Assert.Equal(174, color.G);
            Assert.Equal(219, color.B);
        }

        [Fact]
        public void Green_ShouldReturnCorrectColor()
        {
            var color = MetroColors.Green;
            
            Assert.Equal(0, color.R);
            Assert.Equal(177, color.G);
            Assert.Equal(89, color.B);
        }

        [Fact]
        public void Silver_ShouldReturnCorrectColor()
        {
            var color = MetroColors.Silver;
            
            Assert.Equal(85, color.R);
            Assert.Equal(85, color.G);
            Assert.Equal(85, color.B);
        }

        [Fact]
        public void Lime_ShouldReturnCorrectColor()
        {
            var color = MetroColors.Lime;
            
            Assert.Equal(142, color.R);
            Assert.Equal(188, color.G);
            Assert.Equal(0, color.B);
        }

        [Fact]
        public void Orange_ShouldReturnCorrectColor()
        {
            var color = MetroColors.Orange;
            
            Assert.Equal(243, color.R);
            Assert.Equal(119, color.G);
            Assert.Equal(53, color.B);
        }

        [Fact]
        public void Red_ShouldReturnCorrectColor()
        {
            var color = MetroColors.Red;
            
            Assert.Equal(209, color.R);
            Assert.Equal(17, color.G);
            Assert.Equal(65, color.B);
        }

        [Fact]
        public void Yellow_ShouldReturnCorrectColor()
        {
            var color = MetroColors.Yellow;
            
            Assert.Equal(255, color.R);
            Assert.Equal(196, color.G);
            Assert.Equal(37, color.B);
        }

        [Theory]
        [InlineData(nameof(MetroColors.Black))]
        [InlineData(nameof(MetroColors.White))]
        [InlineData(nameof(MetroColors.Blue))]
        [InlineData(nameof(MetroColors.Green))]
        [InlineData(nameof(MetroColors.Lime))]
        [InlineData(nameof(MetroColors.Teal))]
        [InlineData(nameof(MetroColors.Orange))]
        [InlineData(nameof(MetroColors.Brown))]
        [InlineData(nameof(MetroColors.Pink))]
        [InlineData(nameof(MetroColors.Magenta))]
        [InlineData(nameof(MetroColors.Purple))]
        [InlineData(nameof(MetroColors.Red))]
        [InlineData(nameof(MetroColors.Yellow))]
        [InlineData(nameof(MetroColors.Silver))]
        public void AllColors_ShouldBeNonEmpty(string colorName)
        {
            var property = typeof(MetroColors).GetProperty(colorName);
            Assert.NotNull(property);

            var color = (Color)property.GetValue(null);
            Assert.False(color.IsEmpty);
        }
    }
}
