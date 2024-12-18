using Scripts.Animations;
using Scripts.Level;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Scripts.Cell
{
    [RequireComponent(typeof(Button), typeof(CellConfig))]
    public class Cell : MonoBehaviour
    {
        [SerializeField] private CellConfig _cellConfig;
        [SerializeField] private CellAnimation _cellAnimation;
        
        [Inject] private LevelTransition _levelTransition;
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
            if (_cellConfig.CellData.Identifier == _cellConfig.CurrentFindCell.Identifier)
            {
                _levelTransition.NextLevel();
            }
            else
            {
                _cellAnimation.PlayShakeEffect();
            }
        }
    }
}