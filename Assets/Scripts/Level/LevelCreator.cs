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
        
        [Inject] private CellsLoader _cellsLoader;
        [Inject] private GridColumnsSizeUpdater _gridСolumnsSizeUpdater;
        [Inject] private UsedFindIdentifiers _usedFindIdentifiers;
        private PackData _currentPackData;
        private CellData _currentFindCell;
        private LevelSetSelector _levelSetSelector = new LevelSetSelector();
        private LevelData _levelData;

        public void Create(LevelData levelData)
        {
            _levelData = levelData;
            _gridСolumnsSizeUpdater.UpdateColumnsSize(_levelData.ColumnCount);
            _currentPackData = _levelSetSelector.GetRandomSet(_levelData.PackData);
            SetRandomFindIdentifier(_currentPackData);
            _cellsLoader.Load(_levelData, _currentPackData, _currentFindCell);
            OnCurrentCellIdentifierSelected?.Invoke(_currentFindCell.Identifier);
        }

        private void SetRandomFindIdentifier(PackData setData)
        {
            var randomCell = setData.Cells[Random.Range(0, setData.Cells.Length)];
            var cellIdentifier = randomCell.Identifier;
            var isIdentifierAlreadyUsed = _usedFindIdentifiers.HasIdentifier(cellIdentifier);
            if (isIdentifierAlreadyUsed)
            {
                SetRandomFindIdentifier(setData);
                return;
            }
            
            _currentFindCell = randomCell;
            _usedFindIdentifiers.AddIdentifier(cellIdentifier);
        }
    }
}