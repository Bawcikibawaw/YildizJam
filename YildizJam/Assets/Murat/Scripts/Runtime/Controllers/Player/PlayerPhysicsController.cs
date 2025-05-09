using System;
using Murat.Scripts.Runtime.Helpers;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPhysicsController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.Damage();
        }
    }
    
    
}
