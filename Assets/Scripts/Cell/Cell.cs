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
        [SerializeField] private GameObject _particles;
        
        [Inject] private LevelTransition _levelTransition;
        private Button _button;
        private bool _isParticleAnimating;
        
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
                if (_isParticleAnimating)
                {
                    return;
                }
                _isParticleAnimating = true;
                _particles.SetActive(true);
                _cellAnimation.PlayBounceEffect();
                Invoke(nameof(GoToNextLevel), 1.8f);
            }
            else
            {
                _cellAnimation.PlayShakeEffect();
            }
        }

        private void GoToNextLevel()
        {
            _isParticleAnimating = false;
            _particles.SetActive(false);
            _levelTransition.NextLevel();
        }
    }
}