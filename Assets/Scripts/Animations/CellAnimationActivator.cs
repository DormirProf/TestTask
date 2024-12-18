using Scripts.Cell;
using UnityEngine;
using VContainer;

namespace Scripts.Animations
{
    public class CellAnimationActivator : MonoBehaviour
    {
        [Inject] private CellsLoader _cellsLoader;

        public void ActivateAnimation()
        {
            foreach (var cell in _cellsLoader.Cells)
            {
                cell.GetComponent<CellAnimation>().PlayBounceEffect();
            }
        }
    }
}