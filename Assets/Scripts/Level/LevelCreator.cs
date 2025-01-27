using System;
using ScriptableObjects.Scripts;
using Scripts.Cell;
using Scripts.UI;
using VContainer;
using Random = UnityEngine.Random;

namespace Scripts.Level
{
    public class LevelCreator
    {
        public event Action<string> OnCurrentCellIdentifierSelected;
        
        [Inject] private GridColumnsSizeUpdater _gridСolumnsSizeUpdater;
        [Inject] private CellGenerator _cellGenerator;
        [Inject] private CellPool _cellPool;
        [Inject] private RandomFindIdentifier _randomFindIdentifier;
        
        private PackData _currentPackData;
        private CellData _currentFindCell;
        private LevelSetSelector _levelSetSelector = new LevelSetSelector();
        private LevelData _levelData;

        public void Create(LevelData levelData)
        {
            _levelData = levelData;
            _gridСolumnsSizeUpdater.UpdateColumnsSize(_levelData.ColumnCount);
            _currentPackData = _levelSetSelector.GetRandomSet(_levelData.PackData);
            _randomFindIdentifier.SetRandomFindIdentifier(_currentPackData);
            _currentFindCell = _randomFindIdentifier.GetRandomFindIdentifier(_currentPackData);
            _cellGenerator.GenerateCells(_levelData, _currentPackData, _currentFindCell);
            OnCurrentCellIdentifierSelected?.Invoke(_currentFindCell.Identifier);
        }
    }
}