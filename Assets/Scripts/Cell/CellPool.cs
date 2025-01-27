using System.Collections.Generic;
using ScriptableObjects.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scripts.Cell
{
    public class CellPool
    {
        [Inject] private IObjectResolver _resolver;
        private readonly GameObject _cellPrefab = Resources.Load<GameObject>("Prefabs/Cell");
        private Transform _parent;
        
        private List<Cell> _cells = new List<Cell>();
        
        public IEnumerable<Cell> Cells => _cells;
        
        public void SetParentForCells(Transform parent)
        {
            _parent = parent;
        }
        
        public void UpdatePoolSize(int requiredCount)
        {
            while (_cells.Count < requiredCount)
            {
                AddNewCell();
            }
        }

        public void ConfigureCells(List<CellData> usedCells, CellData currentFindCell)
        {
            for (int i = 0; i < usedCells.Count; i++)
            {
                _cells[i].gameObject.SetActive(true);
                _cells[i].InitializeCellModel(usedCells[i], currentFindCell);
            }

            for (int i = usedCells.Count; i < _cells.Count; i++)
            {
                _cells[i].gameObject.SetActive(false);
            }
        }

        private void AddNewCell()
        {
            var cell = _resolver.Instantiate(_cellPrefab, Vector3.zero, Quaternion.identity, _parent);
            _cells.Add(cell.GetComponent<Cell>());
        }
    }
}