using System.Collections;
using Murat.Scripts.Runtime.Interfaces;
using Murat.Scripts.Runtime.Managers;
using UnityEngine;

namespace Murat.Scripts.Runtime.Controllers.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
    
    
        private void OnCollisionEnter2D(Collision2D other)
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var  damageable))
            {
                damageable.Damage();
                StartCoroutine(ResetGame());
            }
        }

        private IEnumerator ResetGame()
        {
            //Dead
            // Disable input
            yield return new WaitForSeconds(1);
            LevelManager.Instance.Reset();
        }
    
    
    }
}
