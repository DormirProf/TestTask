using ScriptableObjects.Scripts;
using Scripts.Level;
using UnityEngine;
using VContainer;

namespace Scripts.Cell
{
    [RequireComponent(typeof(CellView))]
    public class Cell : MonoBehaviour
    {
        [Inject] private LevelTransition _levelTransition;
        private CellModel _cellModel;
        private CellView _cellView;

        private void Awake()
        {
            _cellModel = new CellModel();
            _cellView = gameObject.GetComponent<CellView>();
        }

        private void OnEnable()
        {
            _cellModel.OnLevelPassed += OnLevelPassed;
            _cellModel.OnLevelFailed += OnLevelFailed;
            _cellModel.OnTimeForNextLevelStarted += OnTimeForNextLevelStarted;
            _cellView.OnUserClicked += OnUserClickedOnCell;
        }

        private void OnDisable()
        {
            _cellModel.OnLevelPassed -= OnLevelPassed;
            _cellModel.OnLevelFailed -= OnLevelFailed;
            _cellModel.OnTimeForNextLevelStarted -= OnTimeForNextLevelStarted;
            _cellView.OnUserClicked -= OnUserClickedOnCell;
        }

        public void InitializeCellModel(CellData cellData, CellData currentFindCell)
        {
            _cellModel.Initialize(cellData, currentFindCell);
            _cellView.RotateItem(cellData);
            _cellView.SetItemSprite(cellData);
        }

        private void OnUserClickedOnCell()
        {
            _cellModel.StartCheckingCells();
        }

        private void OnLevelPassed()
        {
            _cellView.StopLevelPassedAnimation();
            _levelTransition.NextLevel();
        }

        private void OnLevelFailed()
        {
            _cellView.StartWrongClickAnimation();
        }

        private void OnTimeForNextLevelStarted()
        {
            _cellView.StartLevelPassedAnimation();
        }
    }
}