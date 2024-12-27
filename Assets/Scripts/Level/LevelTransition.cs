using System;
using ScriptableObjects.Scripts;
using UnityEngine;
using VContainer;

namespace Scripts.Level
{
    public class LevelTransition : MonoBehaviour
    {
        public event Action OnLevelUpdated;
        public event Action OnLevelReseted;
        public event Action<string> OnCurrentFindCellIdentifierSeted;
        
        [SerializeField] private LevelData[] _levelDatas;
        
        [Inject] private UsedFindIdentifiers _usedFindIdentifiers;
        [Inject] private readonly IObjectResolver _container;
        private int _currentLevelIndex;
        private string _currentFindCellIdentifier;
        private LevelCreator _levelCreator;
        
        private void Awake()
        {
            _levelCreator = new LevelCreator();
            _container.Inject(_levelCreator);
            _levelCreator.OnCurrentCellIdentifierSelected += SetCurrentFindCellIdentifier;
            _levelCreator.Create(_levelDatas[_currentLevelIndex]);
        }

        private void OnDestroy()
        {
            _levelCreator.OnCurrentCellIdentifierSelected -= SetCurrentFindCellIdentifier;
        }

        public void NextLevel()
        {
            _currentLevelIndex += 1;
            if (_currentLevelIndex >= _levelDatas.Length)
            {
                OnLevelUpdated?.Invoke();
            }
            else
            {
                _levelCreator.Create(_levelDatas[_currentLevelIndex]);
            }
        }

        public void ResetLevel()
        {
            _currentLevelIndex = 0;
            _usedFindIdentifiers.ClearIdentifiers();
            _levelCreator.Create(_levelDatas[_currentLevelIndex]);
            OnLevelReseted?.Invoke();
        }

        private void SetCurrentFindCellIdentifier(string identifier)
        {
            _currentFindCellIdentifier = identifier;
            OnCurrentFindCellIdentifierSeted?.Invoke(_currentFindCellIdentifier);
        }
    }
}