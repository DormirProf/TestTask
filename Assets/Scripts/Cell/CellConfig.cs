using ScriptableObjects.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Cell
{
    public class CellConfig : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        
        private CellData _cellData;
        private CellData _currentFindCell;
        
        public CellData CellData => _cellData;
        public CellData CurrentFindCell => _currentFindCell;
        
        public void SetConfig(CellData cellData, CellData currentFindCell)
        {
            _cellData = cellData;
            _currentFindCell = currentFindCell;
            SetItemSprite();
            RotateItem();
        }

        private void SetItemSprite()
        {
            _itemImage.sprite = _cellData.Sprite;
        }

        private void RotateItem()
        {
            _itemImage.transform.rotation = Quaternion.identity;
            if(_cellData.RotationSpriteAngle == 0) return;
            _itemImage.transform.Rotate(0,0, _cellData.RotationSpriteAngle);
        }
    }
}