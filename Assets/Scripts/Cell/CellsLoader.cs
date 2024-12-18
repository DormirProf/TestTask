using System.Collections.Generic;
using ScriptableObjects.Scripts;
using Scripts.Level;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Scripts.Cell
{
    public class CellsLoader : MonoBehaviour
    {
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private LevelTransition levelTransition;
        
        [Inject] private IObjectResolver _resolver;
        private List<CellConfig> _cells = new List<CellConfig>();
        private List<CellData> _usedCells = new List<CellData>();
        private LevelData _levelData;
        private SetData _setData;
        private CellData _currentFindCell;
        private int _cellCount;

        public IEnumerable<CellConfig> Cells => _cells;

        public void Load(LevelData levelData, SetData setData, CellData currentFindCell)
        {
            _levelData = levelData;
            _setData = setData;
            _currentFindCell = currentFindCell;
            
            _usedCells.Clear();
            _usedCells.Add(currentFindCell);
            
            
            GenerateCells();
        }
        
        private void GenerateCells()
        {
            _cellCount = _levelData.ColumnCount * _levelData.RowCount;
            UpdateCellCount(_cellCount);
            SetUsedCells();
            SetCurrentIdentifierToRandomPosition();
            UnloadUnusedCells();
            UpdateCellConfigs();
        }

        private void SetUsedCells()
        {
            for (int i = 0; i < _cellCount - 1; i++)
            {
                AddRandomCellToList();
            }
        }

        private void AddRandomCellToList()
        {
            var randomCellData = _setData.Cells[Random.Range(0, _setData.Cells.Length)];
            foreach (var searchIdentifier in _usedCells)
            {
                if (randomCellData.Identifier == searchIdentifier.Identifier)
                {
                    AddRandomCellToList();
                    return;
                }
            }
            _usedCells.Add(randomCellData);
        }

        private void UpdateCellCount(int cellCount)
        {
            while (cellCount > _cells.Count)
            {
                AddNewCell();
            }
        }
        
        private void AddNewCell()
        {
            var cell = _resolver.Instantiate(_cellPrefab, _cellPrefab.transform.position, Quaternion.identity, transform);
            var cellConfig = cell.GetComponent<CellConfig>();
            _cells.Add(cellConfig);
        }
        
        private void SetCurrentIdentifierToRandomPosition()
        {
            var randomIndex = Random.Range(0, _usedCells.Count);
            var selectedCell = _usedCells[randomIndex];
            _usedCells[randomIndex] = _currentFindCell;
            _usedCells[0] = selectedCell;
        }

        private void UnloadUnusedCells()
        {
            foreach (var cell in _cells)
            {
                cell.gameObject.SetActive(false);
            }
        }

        private void UpdateCellConfigs()
        {
            for (int i = 0; i < _usedCells.Count; i++)
            {
                _cells[i].gameObject.SetActive(true);
                _cells[i].SetConfig(_usedCells[i], _currentFindCell);
            }
        }
    }
}