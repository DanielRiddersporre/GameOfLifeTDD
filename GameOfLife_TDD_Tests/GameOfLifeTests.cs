using GameOfLife_TDD_App;

namespace GameOfLife_TDD_Tests
{
    public class GameOfLifeTests
    {
        private readonly GameOfLife gameOfLife;
        public GameOfLifeTests()
        {
            gameOfLife = new GameOfLife();
        }

        [Fact]
        public void InitializeGrid_CreatesGridWithSpecifiedRowsAndColumns()
        {
            // Arrange
            gameOfLife.InitializeGrid(3, 3);

            // Act
            var grid = gameOfLife.GetGrid();

            // Assert
            Assert.True(grid.GetLength(0) == 3);
            Assert.True(grid.GetLength(1) == 3);
        }
    }
}