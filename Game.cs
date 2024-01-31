class Game
{
    internal Mark CurrentTurn { get; set; } = Mark.X;
    internal Board Board { get; set; } = new();
    internal byte Round { get; set; } = 1;

    internal bool PlayRound()
    {
        Console.Clear();
        Console.WriteLine($"Current Turn: {CurrentTurn}");
        Board.Display();
        Console.Write("Enter the row and column for your next turn separated by a comma > ");
        string? input = null;
        while (true)
        {
            input = Console.ReadLine();
            if (input == null) continue;
            string[] splitInputs = input.Split(",");
            byte row;
            byte col;
            try
            {
                row = byte.Parse(splitInputs[0]);
                col = byte.Parse(splitInputs[1]);
                if (row < 1 || row > 3 || col < 1 || col > 3)
                {
                    Console.WriteLine("Out of bounds. Please select a placement.");
                    continue;
                }
            }
            catch { continue; }
            bool valid = Board.PlaceMark(CurrentTurn, row, col);
            if (!valid) continue;
            Round += 1;
            break;
        }
        return CheckWinCondition();
    }

    internal void Play()
    {
        while (true)
        {
            bool gameWon = PlayRound();
            if (gameWon)
            {
                Console.Clear();
                Board.Display();
                Console.WriteLine($"{CurrentTurn} has won!");
                break;
            }
            if (Round == 10)
            {
                Console.WriteLine("It was a draw!");
                break;
            }
            SwitchPlayer();
        }
    }

    internal void SwitchPlayer()
    {
        if (CurrentTurn == Mark.X) CurrentTurn = Mark.O;
        else if (CurrentTurn == Mark.O) CurrentTurn = Mark.X;
    }

    internal bool CheckWinCondition()
    {
        if
        (
            // Check if rows have win condition
            // Row 1
            Board.Spaces[0][0] == $"{CurrentTurn}" &&
            Board.Spaces[0][1] == $"{CurrentTurn}" &&
            Board.Spaces[0][2] == $"{CurrentTurn}" ||
            // Row 2
            Board.Spaces[1][0] == $"{CurrentTurn}" &&
            Board.Spaces[1][1] == $"{CurrentTurn}" &&
            Board.Spaces[1][2] == $"{CurrentTurn}" ||
            // Row 3
            Board.Spaces[2][0] == $"{CurrentTurn}" &&
            Board.Spaces[2][1] == $"{CurrentTurn}" &&
            Board.Spaces[2][2] == $"{CurrentTurn}" ||

            // Check if colums have win condition
            // Column 1
            Board.Spaces[0][0] == $"{CurrentTurn}" &&
            Board.Spaces[1][0] == $"{CurrentTurn}" &&
            Board.Spaces[2][0] == $"{CurrentTurn}" ||
            // Column 2
            Board.Spaces[0][1] == $"{CurrentTurn}" &&
            Board.Spaces[1][1] == $"{CurrentTurn}" &&
            Board.Spaces[2][1] == $"{CurrentTurn}" ||
            // Column 3
            Board.Spaces[0][2] == $"{CurrentTurn}" &&
            Board.Spaces[1][2] == $"{CurrentTurn}" &&
            Board.Spaces[2][2] == $"{CurrentTurn}" ||

            // Check if diagonals have win condition
            // Diagonal top left to bottom right
            Board.Spaces[0][0] == $"{CurrentTurn}" &&
            Board.Spaces[1][1] == $"{CurrentTurn}" &&
            Board.Spaces[2][2] == $"{CurrentTurn}" ||
            // Diagonal top right to bottom left
            Board.Spaces[0][2] == $"{CurrentTurn}" &&
            Board.Spaces[1][1] == $"{CurrentTurn}" &&
            Board.Spaces[2][0] == $"{CurrentTurn}"
        )
        {
            return true;
        }
        return false;
    }

}

enum Mark { X, O };
