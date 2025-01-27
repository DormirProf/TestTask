using ScriptableObjects.Scripts;
using UnityEngine;
using VContainer;

namespace Scripts
{
    public class RandomFindIdentifier
    {
        [Inject] private UsedFindIdentifiers _usedFindIdentifiers;

        private CellData _currentCell;
        
        public CellData GetRandomFindIdentifier(PackData setData)
        {
            if (_currentCell == null)
            {
                SetRandomFindIdentifier(setData);
            }
            return _currentCell;
        }

        public void SetRandomFindIdentifier(PackData setData)
        {
            var randomCell = setData.Cells[Random.Range(0, setData.Cells.Length)];
            var cellIdentifier = randomCell.Identifier;
            var isIdentifierAlreadyUsed = _usedFindIdentifiers.HasIdentifier(cellIdentifier);
            if (isIdentifierAlreadyUsed)
            {
                SetRandomFindIdentifier(setData);
                return;
            }
            _currentCell = randomCell;
            _usedFindIdentifiers.AddIdentifier(cellIdentifier);
        }
    }
}