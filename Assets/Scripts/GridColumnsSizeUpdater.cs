using UnityEngine;
using UnityEngine.UI;

namespace Scripts
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GridColumnsSizeUpdater : MonoBehaviour
    {
        private GridLayoutGroup _gridLayoutGroup;

        private void Awake()
        {
            _gridLayoutGroup = gameObject.GetComponent<GridLayoutGroup>();
        }

        public void UpdateColumnsSize(int value)
        {
            _gridLayoutGroup.constraintCount = value;
        }
    }
}