using System.Collections;
using Murat.Scripts.Runtime.Managers;
using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class BokJump : MonoBehaviour
    {
        public float jumpForce = 10f;
        public Transform groundCheck; // an empty child object at player's feet
        public float groundCheckRadius = 0.1f;
        public LayerMask groundLayer;
        private Rigidbody2D rb;
        private bool isGrounded;
        private int extraJumps;
        public bool hasJumped;
        public int maxExtraJumps = 1; // Allow 1 extra jump in air
        private BokStamina bokStamina;
        public Animator animator;

        public AudioSource audioSource;
        public AudioClip audioClip;
    
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            rb = GetComponent<Rigidbody2D>();
            extraJumps = maxExtraJumps;
            bokStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<BokStamina>();
        }
    
        void Update()
        {
            // Check if grounded by seeing if groundCheck position overlaps with ground
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            if (isGrounded)
            {
                animator.SetInteger("Jump" , 0);
                extraJumps = maxExtraJumps; // Reset extra jumps when grounded
                Debug.Log("BABANA SOKAYIIIIIIIIM");
            }
            // Jump input detected
            if (Input.GetButtonDown("Jump") && bokStamina.stamina >= 20)
            {
                animator.SetInteger("Jump" , 1);
                if (isGrounded)
                {
                    Jump();
                    bokStamina.stamina -= 20;
                }
                else if (extraJumps > 0)
                {
                    Jump();
                    extraJumps--;
                    bokStamina.stamina -= 20;
                }
            }
        }
    
        void Jump()
        {
            //ses buraya gelccek 
            audioSource.PlayOneShot(audioClip);
            AudioManager.Instance.PlaySound("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Reset vertical velocity before jump
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }
        
    }
}
