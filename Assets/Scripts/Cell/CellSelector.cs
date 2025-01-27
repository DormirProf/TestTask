using System.Collections.Generic;
using System.Linq;
using ScriptableObjects.Scripts;
using UnityEngine;

namespace Scripts.Cell
{
    public class CellSelector
    {
        private LevelData _levelData;
        private PackData _packData;
        private CellData _currentFindCell;
        private List<CellData> _selectedCells = new List<CellData>();
        
        public void Initialize(LevelData levelData, PackData packData, CellData currentFindCell)
        {
            _levelData = levelData;
            _packData = packData;
            _currentFindCell = currentFindCell;
        }

        public List<CellData> SelectCells()
        {
            _selectedCells.Clear();
            _selectedCells.Add(_currentFindCell);

            int requiredCount = _levelData.ColumnCount * _levelData.RowCount - 1;
            while (_selectedCells.Count <= requiredCount)
            {
                AddRandomCell();
            }

            ShuffleCurrentCell();
            return _selectedCells;
        }

        private void AddRandomCell()
        {
            var randomCell = _packData.Cells[Random.Range(0, _packData.Cells.Length)];
            if (!_selectedCells.Any(c => c.Identifier == randomCell.Identifier))
            {
                _selectedCells.Add(randomCell);
            }
        }

        private void ShuffleCurrentCell()
        {
            int randomIndex = Random.Range(0, _selectedCells.Count);
            var temp = _selectedCells[randomIndex];
            _selectedCells[randomIndex] = _selectedCells[0];
            _selectedCells[0] = temp;
        }
    }
}