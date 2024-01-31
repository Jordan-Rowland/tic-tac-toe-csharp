
internal class Board
{
    internal string[][] Spaces = new string[3][];
    internal Board()
    {
        Spaces[0] = new string[3];
        Spaces[1] = new string[3];
        Spaces[2] = new string[3];
    }

    internal void Display()
    {
        string separator = "---+---+---";
        byte sepCount = 0;
        foreach (string[] row in Spaces)
        {
            Console.WriteLine($" {row[0] ?? " "} | {row[1] ?? " "} | {row[2] ?? " "} ");
            if (sepCount < 2)
            {
                Console.WriteLine(separator);
                sepCount += 1;
            }
        }
    }

    internal bool PlaceMark(Mark mark, byte r, byte c)
    {
        if (Spaces[r - 1][c - 1] != null)
        {
            Console.WriteLine("Cannot place a mark in a space that's occupied.");
            return false;
        }
        Spaces[r - 1][c - 1] = $"{mark}";
        return true;
    }
}


