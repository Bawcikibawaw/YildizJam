using Murat.Scripts.Runtime.Interfaces;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            // Player Dead
        }
    }
}
