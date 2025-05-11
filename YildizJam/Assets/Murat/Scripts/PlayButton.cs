using DG.Tweening;
using UnityEngine;

namespace Murat.Scripts
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Vector2[] goPoses;
        [SerializeField] private float duration;
        [SerializeField] private Ease easeMod;
        
        private int _currentIndex;

        public void Play()
        {
            if (_currentIndex > goPoses.Length) return;
            Go();
        }

        private void Go()
        {
            rectTransform.DOLocalMove(goPoses[_currentIndex], duration).SetEase(easeMod);
            _currentIndex++;
        }
        
    }
}
