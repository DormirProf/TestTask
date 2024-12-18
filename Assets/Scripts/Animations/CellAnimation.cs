using DG.Tweening;
using UnityEngine;

namespace Scripts.Animations
{
    public class CellAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private float _scaleUpMultiplier = 1.2f;
        [SerializeField] private float _scaleDownMultiplier = 0.8f;
        [SerializeField] private float _moveDistance = 50f; 
        [SerializeField] private float _itemDuration = 0.5f;
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