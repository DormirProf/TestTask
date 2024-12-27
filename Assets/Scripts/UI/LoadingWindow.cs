using Scripts.Animations;
using Scripts.Level;
using UnityEngine;
using VContainer;

namespace Scripts.UI
{
    [RequireComponent(typeof(FadeEffect))]
    public class LoadingWindow : MonoBehaviour
    {
        [Inject] private LevelTransition _levelTransition;
        private FadeEffect _fadeEffect;
        
        private void Awake()
        {
            _fadeEffect = gameObject.GetComponent<FadeEffect>();
        }

        private void OnEnable()
        {
            Invoke(nameof(DisableWindow), 1.5f);
        }

        private void DisableWindow()
        {
            _fadeEffect.FadeOut();
            _levelTransition.ResetLevel();
        }
    }
}