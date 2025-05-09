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
        public int maxExtraJumps = 1; // Allow 1 extra jump in air
    
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            extraJumps = maxExtraJumps;
        }
    
        void Update()
        {
            // Check if grounded by seeing if groundCheck position overlaps with ground
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            if (isGrounded)
            {
                extraJumps = maxExtraJumps; // Reset extra jumps when grounded
            }
            // Jump input detected
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    Jump();
                }
                else if (extraJumps > 0)
                {
                    Jump();
                    extraJumps--;
                }
            }
        }
    
        void Jump()
        {
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
