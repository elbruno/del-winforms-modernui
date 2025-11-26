using System.Drawing;
using Xunit;

namespace MetroFramework.Tests
{
    public class MetroFontsTests
    {
        [Fact]
        public void Title_ShouldReturnCorrectFont()
        {
            using var font = MetroFonts.Title;
            
            Assert.NotNull(font);
            Assert.Equal(24f, font.Size);
        }

        [Fact]
        public void Subtitle_ShouldReturnCorrectFont()
        {
            using var font = MetroFonts.Subtitle;
            
            Assert.NotNull(font);
            Assert.Equal(14f, font.Size);
        }

        [Fact]
        public void Button_ShouldReturnCorrectFont()
        {
            using var font = MetroFonts.Button;
            
            Assert.NotNull(font);
            Assert.Equal(FontStyle.Bold, font.Style);
            Assert.Equal(11f, font.Size);
        }

        [Fact]
        public void Tile_ShouldReturnCorrectFont()
        {
            using var font = MetroFonts.Tile;
            
            Assert.NotNull(font);
            Assert.Equal(14f, font.Size);
        }

        [Fact]
        public void TileCount_ShouldReturnCorrectFont()
        {
            using var font = MetroFonts.TileCount;
            
            Assert.NotNull(font);
            Assert.Equal(44f, font.Size);
        }

        [Fact]
        public void DefaultLight_ShouldReturnLightFont()
        {
            using var font = MetroFonts.DefaultLight(16f);
            
            Assert.NotNull(font);
            Assert.Equal(16f, font.Size);
            Assert.Equal(FontStyle.Regular, font.Style);
        }

        [Fact]
        public void Default_ShouldReturnRegularFont()
        {
            using var font = MetroFonts.Default(16f);
            
            Assert.NotNull(font);
            Assert.Equal(16f, font.Size);
            Assert.Equal(FontStyle.Regular, font.Style);
        }

        [Fact]
        public void DefaultBold_ShouldReturnBoldFont()
        {
            using var font = MetroFonts.DefaultBold(16f);
            
            Assert.NotNull(font);
            Assert.Equal(16f, font.Size);
            Assert.Equal(FontStyle.Bold, font.Style);
        }

        [Theory]
        [InlineData(MetroLabelSize.Small, MetroLabelWeight.Light, 12f)]
        [InlineData(MetroLabelSize.Small, MetroLabelWeight.Regular, 12f)]
        [InlineData(MetroLabelSize.Small, MetroLabelWeight.Bold, 12f)]
        [InlineData(MetroLabelSize.Medium, MetroLabelWeight.Light, 14f)]
        [InlineData(MetroLabelSize.Medium, MetroLabelWeight.Regular, 14f)]
        [InlineData(MetroLabelSize.Medium, MetroLabelWeight.Bold, 14f)]
        [InlineData(MetroLabelSize.Tall, MetroLabelWeight.Light, 18f)]
        [InlineData(MetroLabelSize.Tall, MetroLabelWeight.Regular, 18f)]
        [InlineData(MetroLabelSize.Tall, MetroLabelWeight.Bold, 18f)]
        public void Label_ShouldReturnCorrectFontSize(MetroLabelSize size, MetroLabelWeight weight, float expectedSize)
        {
            using var font = MetroFonts.Label(size, weight);
            
            Assert.NotNull(font);
            Assert.Equal(expectedSize, font.Size);
        }

        [Theory]
        [InlineData(MetroLinkSize.Small, MetroLinkWeight.Light, 12f)]
        [InlineData(MetroLinkSize.Medium, MetroLinkWeight.Regular, 14f)]
        [InlineData(MetroLinkSize.Tall, MetroLinkWeight.Bold, 18f)]
        public void Link_ShouldReturnCorrectFontSize(MetroLinkSize size, MetroLinkWeight weight, float expectedSize)
        {
            using var font = MetroFonts.Link(size, weight);
            
            Assert.NotNull(font);
            Assert.Equal(expectedSize, font.Size);
        }

        [Theory]
        [InlineData(MetroTextBoxSize.Small, MetroTextBoxWeight.Light, 12f)]
        [InlineData(MetroTextBoxSize.Medium, MetroTextBoxWeight.Regular, 14f)]
        [InlineData(MetroTextBoxSize.Tall, MetroTextBoxWeight.Bold, 18f)]
        public void TextBox_ShouldReturnCorrectFontSize(MetroTextBoxSize size, MetroTextBoxWeight weight, float expectedSize)
        {
            using var font = MetroFonts.TextBox(size, weight);
            
            Assert.NotNull(font);
            Assert.Equal(expectedSize, font.Size);
        }

        [Theory]
        [InlineData(MetroProgressBarSize.Small, MetroProgressBarWeight.Light, 12f)]
        [InlineData(MetroProgressBarSize.Medium, MetroProgressBarWeight.Regular, 14f)]
        [InlineData(MetroProgressBarSize.Tall, MetroProgressBarWeight.Bold, 18f)]
        public void ProgressBar_ShouldReturnCorrectFontSize(MetroProgressBarSize size, MetroProgressBarWeight weight, float expectedSize)
        {
            using var font = MetroFonts.ProgressBar(size, weight);
            
            Assert.NotNull(font);
            Assert.Equal(expectedSize, font.Size);
        }

        [Theory]
        [InlineData(MetroTabControlSize.Small, MetroTabControlWeight.Light, 12f)]
        [InlineData(MetroTabControlSize.Medium, MetroTabControlWeight.Regular, 14f)]
        [InlineData(MetroTabControlSize.Tall, MetroTabControlWeight.Bold, 18f)]
        public void TabControl_ShouldReturnCorrectFontSize(MetroTabControlSize size, MetroTabControlWeight weight, float expectedSize)
        {
            using var font = MetroFonts.TabControl(size, weight);
            
            Assert.NotNull(font);
            Assert.Equal(expectedSize, font.Size);
        }
    }
}
