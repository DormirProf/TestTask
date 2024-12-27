using DG.Tweening;
using UnityEngine;

namespace Scripts.Animations
{
    public class CellAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _scaleUpMultiplier;
        [SerializeField] private float _scaleDownMultiplier;
        [SerializeField] private float _moveDistance; 
        [SerializeField] private float _itemDuration;
        [SerializeField] private Transform _item;

        public void PlayBounceEffect()
        {
            Sequence bounceSequence = DOTween.Sequence();

            bounceSequence.Append(transform.DOScale(Vector3.one * _scaleUpMultiplier, _duration / 3)
                    .SetEase(Ease.OutQuad))
                .Append(transform.DOScale(Vector3.one * _scaleDownMultiplier, _duration / 3)
                    .SetEase(Ease.InQuad))
                .Append(transform.DOScale(Vector3.one, _duration / 3)
                    .SetEase(Ease.OutQuad));
        }
        
        public void PlayShakeEffect()
        {
            Sequence shakeSequence = DOTween.Sequence();

            shakeSequence.Append(_item.DOLocalMoveX(_moveDistance, _itemDuration / 4)
                    .SetEase(Ease.InOutQuad))
                .Append(_item.DOLocalMoveX(-_moveDistance, _itemDuration / 4)
                    .SetEase(Ease.InOutQuad))
                .Append(_item.DOLocalMoveX(_moveDistance / 2, _itemDuration / 4)
                    .SetEase(Ease.InOutQuad))
                .Append(_item.DOLocalMoveX(0, _itemDuration / 4)
                    .SetEase(Ease.InOutQuad));
        }
    }
}