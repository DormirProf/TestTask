using Scripts.Level;
using TMPro;
using UnityEngine;
using VContainer;

namespace Scripts
{
    public class FindText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _find;

        [Inject] private LevelCreator _levelCreator;

        private void OnEnable()
        {
            _levelCreator.OnLevelCreated += UpdateText;
        }

        private void OnDisable()
        {
            _levelCreator.OnLevelCreated -= UpdateText;
        }

        private void UpdateText(string identifier)
        {
            _find.text = $"Find: {identifier}";
        }
    }
}