using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "SetData", menuName = "Data/Set Data", order = 3)]
    public class SetData : ScriptableObject
    {
        [SerializeField] private CellData[] _cells;

        public CellData[] Cells => _cells;
    }
}