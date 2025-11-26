using System.Drawing;
using Xunit;

namespace MetroFramework.Tests
{
    public class MetroBrushesTests
    {
        [Fact]
        public void Black_ShouldReturnSolidBrushWithCorrectColor()
        {
            using var brush = MetroBrushes.Black;
            
            Assert.NotNull(brush);
            Assert.Equal(MetroColors.Black, brush.Color);
        }

        [Fact]
        public void White_ShouldReturnSolidBrushWithCorrectColor()
        {
            using var brush = MetroBrushes.White;
            
            Assert.NotNull(brush);
            Assert.Equal(MetroColors.White, brush.Color);
        }

        [Fact]
        public void Blue_ShouldReturnSolidBrushWithCorrectColor()
        {
            using var brush = MetroBrushes.Blue;
            
            Assert.NotNull(brush);
            Assert.Equal(MetroColors.Blue, brush.Color);
        }

        [Fact]
        public void Green_ShouldReturnSolidBrushWithCorrectColor()
        {
            using var brush = MetroBrushes.Green;
            
            Assert.NotNull(brush);
            Assert.Equal(MetroColors.Green, brush.Color);
        }

        [Fact]
        public void Red_ShouldReturnSolidBrushWithCorrectColor()
        {
            using var brush = MetroBrushes.Red;
            
            Assert.NotNull(brush);
            Assert.Equal(MetroColors.Red, brush.Color);
        }

        [Theory]
        [InlineData(nameof(MetroBrushes.Black))]
        [InlineData(nameof(MetroBrushes.White))]
        [InlineData(nameof(MetroBrushes.Blue))]
        [InlineData(nameof(MetroBrushes.Green))]
        [InlineData(nameof(MetroBrushes.Lime))]
        [InlineData(nameof(MetroBrushes.Teal))]
        [InlineData(nameof(MetroBrushes.Orange))]
        [InlineData(nameof(MetroBrushes.Brown))]
        [InlineData(nameof(MetroBrushes.Pink))]
        [InlineData(nameof(MetroBrushes.Magenta))]
        [InlineData(nameof(MetroBrushes.Purple))]
        [InlineData(nameof(MetroBrushes.Red))]
        [InlineData(nameof(MetroBrushes.Yellow))]
        [InlineData(nameof(MetroBrushes.Silver))]
        public void AllBrushes_ShouldReturnNonNullBrush(string brushName)
        {
            var property = typeof(MetroBrushes).GetProperty(brushName);
            Assert.NotNull(property);

            using var brush = (SolidBrush)property.GetValue(null);
            Assert.NotNull(brush);
            Assert.False(brush.Color.IsEmpty);
        }

        [Fact]
        public void Brushes_ShouldReturnClonedInstances()
        {
            using var brush1 = MetroBrushes.Blue;
            using var brush2 = MetroBrushes.Blue;
            
            Assert.NotSame(brush1, brush2);
            Assert.Equal(brush1.Color, brush2.Color);
        }
    }
}
