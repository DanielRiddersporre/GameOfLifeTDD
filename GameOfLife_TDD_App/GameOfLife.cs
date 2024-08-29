
namespace GameOfLife_TDD_App
{
    public class GameOfLife
    {
        private bool[,] _grid;

        public void InitializeGrid(int rows, int columns)
        {
            _grid = new bool[rows, columns];
        }

        public bool[,] GetGrid()
        {
            return _grid;
        }

        public void SetCell(int row, int column, bool isAlive)
        {
            try
            {
                _grid[row, column] = isAlive;
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new System.ArgumentOutOfRangeException();
            }
        }

        public bool GetCell(int row, int column)
        {
            return _grid[row, column];
        }

        public void Update()
        {
            var newGrid = (bool[,])_grid.Clone();

            for (int i = 0; i < newGrid.GetLength(0); i++)
            {
                for (int j = 0; j < newGrid.GetLength(1); j++)
                {
                    var liveNeighbours = CountLiveNeighbours(i, j);
                    if (_grid[i, j])
                    {
                        if (liveNeighbours < 2 || liveNeighbours > 3)
                        {
                            newGrid[i, j] = false;
                        }
                    }
                    else
                    {
                        if (liveNeighbours == 3)
                        {
                            newGrid[i, j] = true;
                        }
                    }
                }
            }

            _grid = newGrid;
        }

        private int CountLiveNeighbours(int row, int column)
        {
            var count = 0;

            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = column - 1; j <= column + 1; j++)
                {
                    if (i < 0 || i >= _grid.GetLength(0) || j < 0 || j >= _grid.GetLength(1) || (i == row && j == column))
                    {
                        continue;
                    }

                    if (_grid[i, j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public void DisplayGrid()
        {
            Console.Clear();
            Console.WriteLine("+" + new string('-', _grid.GetLength(1)) + "+"); // Top border
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                Console.Write("|"); // Left border
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    Console.Write(_grid[i, j] ? "X" : ".");
                }
                Console.WriteLine("|"); // Right border
            }
            Console.WriteLine("+" + new string('-', _grid.GetLength(1)) + "+"); // Bottom border
            Console.WriteLine(); // Extra line for spacing
        }
    }
}
