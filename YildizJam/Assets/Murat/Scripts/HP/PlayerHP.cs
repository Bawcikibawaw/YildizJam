using System.Collections;
using Ates.ScriptsAtes;
using Murat.Scripts.Runtime.Interfaces;
using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;

namespace Murat.Scripts.HP
{
    public class PlayerHP : MonoBehaviour
    {
        public Transform teleportTarget;
        private Transform transform;
        public Animator animator;
        private BokDash bokDash;
        private BokMovementFinal bokMovement;
        private BokJump bokJump;

        void Start()
        {
            transform = GetComponent<Transform>();
            bokDash = GameObject.FindGameObjectWithTag("Player").GetComponent<BokDash>();
            bokJump = GameObject.FindGameObjectWithTag("Player").GetComponent<BokJump>();
            bokMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<BokMovementFinal>();
        }
        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.TryGetComponent<IDamageable>(out var damageable))
            {
                StartCoroutine(Death());
            }
        }
        
        private IEnumerator Death()
        {
            animator.SetBool("hasDied", true);
            bokJump.enabled = false;
            bokDash.enabled = false;
            bokMovement.enabled = false;
            yield return new WaitForSeconds(1f);
            animator.SetBool("hasDied", false);
            transform.position = teleportTarget.position;
            yield return new WaitForSeconds(1f);
            bokJump.enabled = true;
            bokDash.enabled = true;
            bokMovement.enabled = true;
        }

    }
}