using Scripts.Cell;
using UnityEngine;
using VContainer;

namespace Scripts.Animations
{
    public class CellAnimationActivator
    {
        [Inject] private CellPool _cellPool;

        public void ActivateAnimation()
        {
            foreach (var cell in _cellPool.Cells)
            {
                cell.GetComponent<CellAnimation>().PlayBounceEffect();
            }
        }
    }
}