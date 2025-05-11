using Murat.Scripts.Runtime.Interfaces;
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
        }
    }
}
