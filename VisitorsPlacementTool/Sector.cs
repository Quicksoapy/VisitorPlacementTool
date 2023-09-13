namespace VisitorsPlacementTool;

public class Sector
{
    //init with sector.Letter = (CountToLetter)1; to cast
    public CountToLetter Letter { get; set; }
    public Ticket[,] SeatArray { get; set; }
    public int RowCount { get; set; }
    public int ColumnCount { get; set; }

    public Sector()
    {
        RowCount = 0;
        ColumnCount = 0;
        Letter = CountToLetter.A;
    }
    
    public Sector(int rowCount, int columnCount, CountToLetter letter)
    {
        RowCount = rowCount;
        ColumnCount = columnCount;
        Letter = letter;
    }     
    
}