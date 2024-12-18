using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Scripts.Animations
{
    public class TextFadeEffect : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _fadeScale;
        
        private void OnEnable()
        {
            FadeIn();
        }

        public void FadeIn()
        {
            _text.color = new Color(0, 0, 0, 0);
            _text.DOFade(_fadeScale, 1.5f);
        }
    }
}