using System;
using System.Threading.Tasks;
using ScriptableObjects.Scripts;

namespace Scripts.Cell
{
    public class CellModel
    {
        public event Action OnLevelPassed;
        public event Action OnLevelFailed;
        public event Action OnTimeForNextLevelStarted;
        
       
        private CellConfig _cellConfig;
        private bool _isTimeForNextLevelPassed = true;

        public void Initialize(CellData cellData, CellData currentFindCell)
        {
            _cellConfig = new CellConfig(cellData, currentFindCell);
        }
        
        public void StartCheckingCells()
        {
            if (_cellConfig.CellData.Identifier == _cellConfig.CurrentFindCell.Identifier)
            {
                if (!_isTimeForNextLevelPassed)
                {
                    return;
                }
                _isTimeForNextLevelPassed = false;
                OnTimeForNextLevelStarted?.Invoke();
                GoToNextLevel();
            }
            else
            {
                OnLevelFailed?.Invoke();
            }
        }
        private async void GoToNextLevel()
        {
            await Task.Delay(1800);
            _isTimeForNextLevelPassed = true;
            OnLevelPassed?.Invoke();
        }
    }
}