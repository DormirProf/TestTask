using System;
using ScriptableObjects.Scripts;
using Scripts.Cell;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Scripts.Level
{
    public class LevelCreator : MonoBehaviour
    {
        public event Action<string> OnLevelCreated;
        
        [SerializeField] private GridColumnsSizeUpdater _gridСolumnsSizeUpdater;
        [SerializeField] private CellsLoader _cellsLoader;
        [SerializeField] private FindText _findText;
        
        [Inject] private UsedFindIdentifiers _usedFindIdentifiers;
        private PackData _currentPackData;
        private CellData _currentFindCell;
        private LevelSetSelector _levelSetSelector;
        private LevelData _levelData;
        
        private void Awake()
        {
            _levelSetSelector = new LevelSetSelector();
        }

        public void Create(LevelData levelData)
        {
            _levelData = levelData;
            _gridСolumnsSizeUpdater.UpdateColumnsSize(_levelData.ColumnCount);
            _currentPackData = _levelSetSelector.GetRandomSet(_levelData.PackData);
            SetRandomFindIdentifier(_currentPackData);
            _cellsLoader.Load(_levelData, _currentPackData, _currentFindCell);
            OnLevelCreated?.Invoke(_currentFindCell.Identifier);
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