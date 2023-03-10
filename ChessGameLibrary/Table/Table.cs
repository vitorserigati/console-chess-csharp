namespace ConsoleChessLibrary.Table;
using ConsoleChessLibrary.Table.Exception;

public class Table
{

    public int Lines { get; set; }
    public int Columns { get; set; }
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

    public Piece Piece(Position position)
    {
        return Pieces[position.Line, position.Column];
    }

    public void PlacePiece(Piece piece, Position position)
    {
        if(PieceExists(position)) throw new TableException("There is already a piece in this position");
        Pieces[position.Line, position.Column] = piece;
        piece.Position = position;
    }

    public Piece RemovePiece(Position position)
    {
        if(Piece(position) == null)
        {
            return null;
        }
        Piece aux = Piece(position);
        aux.Position = null;
        Pieces[position.Line, position.Column] = null;
        return aux;
    }

    public bool PieceExists(Position position)
    {
        ValidatePosition(position);
        return Piece(position) != null;
    }

    public void ValidatePosition(Position position)
    {
        if (!ValidPosition(position)) throw new TableException("Invalid Position!");
    }

    public bool ValidPosition(Position position)
    {
        if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns) return false;

        return true;
    }
}
