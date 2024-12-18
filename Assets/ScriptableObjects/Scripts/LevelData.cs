using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Data/Level Data", order = 1)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private int _rowCount;
        [SerializeField] private int _columnCount;
        [SerializeField] private SetData[] _setsData;
        
        public int RowCount => _rowCount;
        public int ColumnCount => _columnCount;
        public SetData[] SetsData => _setsData;
    }
}