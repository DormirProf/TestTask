using System;
using ScriptableObjects.Scripts;
using Scripts.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Cell
{
    public class CellView : MonoBehaviour
    {
        public event Action OnUserClicked;
        
        [SerializeField] private Image _itemImage;
        [SerializeField] private CellAnimation _cellAnimation;
        [SerializeField] private GameObject _particles;
        
        private Button _button;
        
        private void Awake()
        {
            _button = gameObject.GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(Click);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(Click);
        }

        private void Click()
        {
            OnUserClicked?.Invoke();
        }
        
        public void SetItemSprite(CellData cellData)
        {
            _itemImage.sprite = cellData.Sprite;
        }

        public void RotateItem(CellData cellData)
        {
            _itemImage.transform.rotation = Quaternion.identity;
            if(cellData.RotationSpriteAngle == 0) return;
            _itemImage.transform.Rotate(0,0, cellData.RotationSpriteAngle);
        }

        public void StartLevelPassedAnimation()
        {
            _particles.SetActive(true);
            _cellAnimation.PlayBounceEffect();
        }
        
        public void StopLevelPassedAnimation()
        {
            _particles.SetActive(false);
        }

        public void StartWrongClickAnimation()
        {
            _cellAnimation.PlayShakeEffect();
        }
    }
}