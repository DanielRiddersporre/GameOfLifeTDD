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

        [Fact]
        public void SetCell_CreatesCellWithSpecifiedState()
        {
            // Arrange
            gameOfLife.InitializeGrid(3, 3);

            // Act
            gameOfLife.SetCell(1, 1, true);
            var cell = gameOfLife.GetCell(1, 1);

            // Assert
            Assert.True(cell);
        }

        [Fact]
        public void Update_UpdatesGridAccordingToGameOfLifeRules()
        {
            // Arrange
            gameOfLife.InitializeGrid(3, 3);
            gameOfLife.SetCell(1, 1, true);
            gameOfLife.SetCell(1, 2, true);
            gameOfLife.SetCell(2, 1, true);

            // Act
            gameOfLife.Update();
            var grid = gameOfLife.GetGrid();

            // Assert
            Assert.True(grid[1, 1]);
            Assert.True(grid[1, 2]);
            Assert.True(grid[2, 1]);
            Assert.True(grid[2, 2]);
        }
    }
}