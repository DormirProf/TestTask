using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Animations
{
    public class FadeEffect : MonoBehaviour
    {
        [SerializeField] private Image _fadeImage;
        [SerializeField] private float _fadeScale;
        
        private void OnEnable()
        {
            FadeIn();
        }

        public void FadeIn()
        {
            _fadeImage.gameObject.SetActive(true);
            _fadeImage.color = new Color(0, 0, 0, 0);
            _fadeImage.DOFade(_fadeScale, 1f);
        }

        public void FadeOut()
        {
            _fadeImage.DOFade(0, 1f)
                .OnKill(() => _fadeImage.gameObject.SetActive(false));
        }
    }
}