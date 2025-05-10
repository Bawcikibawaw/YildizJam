using DG.Tweening;
using UnityEngine;

namespace Murat.Scripts.Runtime.Objects
{
    public class MoveObj : MonoBehaviour
    {
        [SerializeField] private Vector3 movePos;
        [SerializeField] private float duration;
        [SerializeField] private Ease easeMod;

        private Transform _startPos;

        private void Awake()
        {
            _startPos = transform;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                MoveLocation();
            }
        }

        private void MoveLocation()
        {
            transform.DOMove(movePos, duration).SetEase(easeMod);
        }

        public void ResetLevel()
        {
            transform.position = _startPos.position;
        }
        
    }
}
