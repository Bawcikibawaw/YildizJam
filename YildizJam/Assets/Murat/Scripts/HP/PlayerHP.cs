using System.Collections;
using Murat.Scripts.Runtime.Interfaces;
using Unity.Cinemachine;
using UnityEngine;

namespace Murat.Scripts.HP
{
    public class PlayerHP : MonoBehaviour
    {
        public Transform teleportTarget;
        private Transform transform;

        void Start()
        {
            transform = GetComponent<Transform>();
        }
        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                transform.position = teleportTarget.position;
                Debug.Log("öldü");
            }
        }

    }
}
