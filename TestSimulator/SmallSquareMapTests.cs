using Simulator.Maps;

namespace Simulator.Tests
{
    public class SmallSquareMapTests
    {
        [Fact]
        public void Constructor_ShouldInitialize_WhenSizeIsWithinBounds()
        {
            var map = new SmallSquareMap(10);

            Assert.Equal(10, map.SizeX);
            Assert.Equal(10, map.SizeY);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenSizeIsTooSmall()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(4));
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenSizeIsTooLarge()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(21));
        }

        [Fact]
        public void Exist_ShouldReturnTrue_WhenPointIsWithinBounds()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(5, 5);

            Assert.True(map.Exist(point));
        }

        [Fact]
        public void Exist_ShouldReturnFalse_WhenPointIsOutsideBounds()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(10, 10);

            Assert.False(map.Exist(point));
        }

        [Fact]
        public void Next_ShouldReturnNextPoint_WhenNextPointIsWithinBounds()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(5, 5);
            var nextPoint = map.Next(point, Direction.Right);

            Assert.Equal(new Point(6, 5), nextPoint);
        }

        [Fact]
        public void Next_ShouldReturnSamePoint_WhenNextPointIsOutsideBounds()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(9, 9);
            var nextPoint = map.Next(point, Direction.Right);

            Assert.Equal(point, nextPoint);
        }

        [Fact]
        public void NextDiagonal_ShouldReturnNextPoint_WhenNextPointIsWithinBounds()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(5, 5);
            var nextPoint = map.NextDiagonal(point, Direction.Right);

            Assert.Equal(new Point(6, 4), nextPoint);
        }

        [Fact]
        public void NextDiagonal_ShouldReturnSamePoint_WhenNextPointIsOutsideBounds()
        {
            var map = new SmallSquareMap(10);
            var point = new Point(9, 0);
            var nextPoint = map.NextDiagonal(point, Direction.Right);

            Assert.Equal(point, nextPoint);
        }
    }
}
