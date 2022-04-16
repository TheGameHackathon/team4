namespace thegame.Models
{
    public static class Extensions
    {
        public static CellDto[] GetRow(this CellDto[] cells, int rowIndex, int numOfColElements)
        {
            var numOfRowElements = cells.Length / numOfColElements;

            var row = new CellDto[numOfRowElements];
            for (int i = 0, j = rowIndex; i < numOfRowElements; i++, j += numOfColElements)
                row[i] = cells[j];

            return row;
        }

        public static void SetRow(this CellDto[] cells, CellDto[] row, int rowIndex, int numOfColElements)
        {
            var numOfRowElements = cells.Length / numOfColElements;

            for (int i = 0, j = rowIndex; i < numOfRowElements; i++, j += numOfColElements)
                cells[j] = row[i];
        }

        public static CellDto[] GetColumn(this CellDto[] cells, int colIndex, int numOfColElements)
        {
            var col = new CellDto[numOfColElements];
            for (int i = 0, j = colIndex * numOfColElements; i < numOfColElements; i++, j++)
                col[i] = cells[j];

            return col;
        }

        public static void SetColumn(this CellDto[] cells, CellDto[] column, int colIndex)
        {
            var numOfColElements = column.Length;
            for (int i = 0, j = colIndex * numOfColElements; i < numOfColElements; i++, j++)
                cells[j] = column[i];
        }
    }
}
