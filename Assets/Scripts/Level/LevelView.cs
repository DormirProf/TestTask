using Scripts.Animations;
using Scripts.UI;
using UnityEngine;
using VContainer;

namespace Scripts.Level
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private GameObject _restartWindow;
        
        [Inject] private TextFadeEffect _textFadeEffect;
        [Inject] private CellAnimationActivator _cellAnimationActivator;
        [Inject] private LevelTransition _levelTransition;
        [Inject] private FindText _findText;
        
        private void Start()
        {
            _cellAnimationActivator.ActivateAnimation();
        }

        private void OnEnable()
        {
            _levelTransition.OnLevelUpdated += ActivateRestartWindow;
            _levelTransition.OnLevelReseted += StartAnimateText;
            _levelTransition.OnCurrentFindCellIdentifierSeted += OnCurrentCellIdentifierSelected;
        }

        private void OnDisable()
        {
            _levelTransition.OnLevelUpdated -= ActivateRestartWindow;
            _levelTransition.OnLevelReseted -= StartAnimateText;
            _levelTransition.OnCurrentFindCellIdentifierSeted -= OnCurrentCellIdentifierSelected;
        }

        private void ActivateRestartWindow()
        {
            _restartWindow.SetActive(true);
        }

        private void StartAnimateText()
        {
            _textFadeEffect.FadeIn();
        }

        private void OnCurrentCellIdentifierSelected(string identifier)
        {
            _findText.UpdateText(identifier);
        }
    }
}