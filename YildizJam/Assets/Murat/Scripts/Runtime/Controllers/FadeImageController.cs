using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Murat.Scripts.Runtime.Controllers
{
    public class FadeImageController : MonoBehaviour
    {
        [SerializeField] private Image fadeImage;
        [SerializeField] private float duration;
        [SerializeField] private Ease easeMod;

        private void Start()
        {
            Fade(0);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Respawn();
            }
        }

        public void Respawn()
        {
            Fade(1);
            // TODO : ChangeLevel
            Invoke(nameof(ForInvoke), duration + .1f);
        }

        private void ForInvoke()
        {
            Fade(0);
        }
        
        private void Fade(float target)
        {
            fadeImage.DOFade(target,duration).SetEase(easeMod);
        }
        
    }
}
