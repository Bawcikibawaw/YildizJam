using UnityEngine;

public class BOK : MonoBehaviour
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

}
