using System.Collections;
using Murat.Scripts.Runtime.Interfaces;
using Unity.Cinemachine;
using UnityEngine;

namespace Murat.Scripts.HP
{
    public class PlayerHP : MonoBehaviour
    {
        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                Debug.Log("öldü ");
            }

            if (other.TryGetComponent<CollideObject>(out var obj))
            {
                transform.position = obj.GoPos;
            }
        }

    }
}
