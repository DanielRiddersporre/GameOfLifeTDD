using GameOfLife_TDD_App;

// Settings
int generations = 1000;
int rows = 25;
int columns = 50;
int millisecondsTimeout = 100;


// Set up the initial state of the game

GameOfLife gameOfLife = new GameOfLife();
gameOfLife.InitializeGrid(rows, columns);

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        int random = new Random().Next(0, 2);

        switch (random)
        {
            case 0:
                gameOfLife.SetCell(i, j, false);
                break;
            case 1:
                gameOfLife.SetCell(i, j, true);
                break;
            default:
                break;
        }
    }
}

// Run the game for x generations
for (int i = 0; i < generations; i++)
{
    gameOfLife.DisplayGrid();
    gameOfLife.Update();

    // Pause for a moment
    Thread.Sleep(millisecondsTimeout);
    Console.Clear();
    Console.WriteLine("\x1b[3J");
}
