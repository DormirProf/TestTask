using ScriptableObjects.Scripts;
using Scripts.Cell;
using UnityEngine;
using VContainer;
using Random = UnityEngine.Random;

namespace Scripts.Level
{
    [RequireComponent(typeof(LevelSetSelector))]
    public class LevelCreator : MonoBehaviour
    {
        [SerializeField] private GridColumnsSizeUpdater _gridСolumnsSizeUpdater;
        [SerializeField] private CellsLoader _cellsLoader;
        [SerializeField] private FindText _findText;
        
        [Inject] private UsedFindIdentifiers _usedFindIdentifiers;
        private SetData _currentSet;
        private CellData _currentFindCell;
        private LevelSetSelector _levelSetSelector;
        private LevelData _levelData;
        
        private void Awake()
        {
            _levelSetSelector = gameObject.GetComponent<LevelSetSelector>();
        }

        public void Load(LevelData levelData)
        {
            _levelData = levelData;
            _gridСolumnsSizeUpdater.UpdateColumnsSize(_levelData.ColumnCount);
            _currentSet = _levelSetSelector.GetRandomSet(_levelData.SetsData);
            SetRandomFindIdentifier(_currentSet);
            _cellsLoader.Load(_levelData, _currentSet, _currentFindCell);
            _findText.UpdateText(_currentFindCell.Identifier);
        }

        private void SetRandomFindIdentifier(SetData setData)
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