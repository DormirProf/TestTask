using ScriptableObjects.Scripts;
using Scripts.Animations;
using UnityEngine;
using VContainer;

namespace Scripts.Level
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] private LevelCreator _levelCreator;
        [SerializeField] private LevelData[] _levelDatas;
        [SerializeField] private GameObject _restartWindow;
        
        [Inject] private CellAnimationActivator _cellAnimationActivator;
        [Inject] private TextFadeEffect _textFadeEffect;
        [Inject] private UsedFindIdentifiers _usedFindIdentifiers;
        private int _currentLevelIndex;
        
        private void Start()
        {
            _levelCreator.Load(_levelDatas[_currentLevelIndex]);
            _cellAnimationActivator.ActivateAnimation();
        }

        public void NextLevel()
        {
            _currentLevelIndex += 1;
            if (_currentLevelIndex >= _levelDatas.Length)
            {
                ActivateRestartWindow();
            }
            else
            {
                _levelCreator.Load(_levelDatas[_currentLevelIndex]);
            }
        }

        public void ResetLevel()
        {
            _currentLevelIndex = 0;
            _usedFindIdentifiers.ClearIdentifiers();
            _levelCreator.Load(_levelDatas[_currentLevelIndex]);
            _cellAnimationActivator.ActivateAnimation();
            _textFadeEffect.FadeIn();
        }

        private void ActivateRestartWindow()
        {
            _restartWindow.SetActive(true);
        }
    }
}