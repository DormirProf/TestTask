using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class GridColumnsSizeUpdater : MonoBehaviour
    {
        private GridLayoutGroup _gridLayoutGroup;

        public void UpdateColumnsSize(int value)
        {
            _gridLayoutGroup = gameObject.GetComponent<GridLayoutGroup>();
            _gridLayoutGroup.constraintCount = value;
        }
    }
}