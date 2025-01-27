using System.Collections.Generic;
using ScriptableObjects.Scripts;
using VContainer;

namespace Scripts.Cell
{
    public class CellGenerator
    {
        [Inject] private CellPool _cellPool;
        [Inject] private CellSelector _cellSelector;

        private List<CellData> _usedCells = new List<CellData>();

        public void GenerateCells(LevelData levelData, PackData packData, CellData currentFindCell)
        {
            _cellSelector.Initialize(levelData, packData, currentFindCell);
            _usedCells = _cellSelector.SelectCells();

            _cellPool.UpdatePoolSize(levelData.ColumnCount * levelData.RowCount);
            _cellPool.ConfigureCells(_usedCells, currentFindCell);
        }
    }
}