using System;
using System.Threading.Tasks;
using ScriptableObjects.Scripts;

namespace Scripts.Cell
{
    public class CellModel
    {
        public event Action OnCellCheckPassed;
        public event Action OnCellCheckFailed;
        public event Action OnTimerAfterPassingCheckStarted;
        
       
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
                StartTimerAfterPassingCheck();
            }
            else
            {
                OnCellCheckFailed?.Invoke();
            }
        }
        private async void StartTimerAfterPassingCheck()
        {
            OnTimerAfterPassingCheckStarted?.Invoke();
            await Task.Delay(1800);
            _isTimeForNextLevelPassed = true;
            OnCellCheckPassed?.Invoke();
        }
    }
}