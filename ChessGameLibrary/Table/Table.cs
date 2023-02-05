namespace ConsoleChessLibrary.Table;

public class Table
{

    public int Lines {get; set;}
    public int Columns {get; set;}
    private Piece[,] Pieces;

    public Table(int lines, int columns)
    {
        Lines = lines;
        Columns = columns;
        Pieces = new Piece[Lines, Columns];
    }

    public Piece Piece(int line, int column)
    {
        return Pieces[line, column];
    }
}
