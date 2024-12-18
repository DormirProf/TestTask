using TMPro;
using UnityEngine;

namespace Scripts
{
    public class FindText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _find;

        public void UpdateText(string identifier)
        {
            _find.text = $"Find: {identifier}";
        }
    }
}