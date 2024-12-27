using ScriptableObjects.Scripts;

namespace Scripts.Cell
{
    public class CellConfig
    {
        private CellData _cellData;
        private CellData _currentFindCell;
        
        public CellData CellData => _cellData;
        public CellData CurrentFindCell => _currentFindCell;

        public CellConfig(CellData cellData, CellData currentFindCell)
        {
            _cellData = cellData;
            _currentFindCell = currentFindCell;
        }
    }
}