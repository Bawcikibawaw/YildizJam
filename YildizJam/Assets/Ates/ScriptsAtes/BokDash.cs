using System.Collections;
using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class BokDash : MonoBehaviour
    {
       private bool canDash = true;
       private bool isDashing;
       public float dashingPower = 24f;
       public float dashingTime = 0.2f;
       public float dashingCooldown = 1f;
       public bool hasDashed;
       private Rigidbody2D rb;
       private BokStamina bokStamina;

       void Start()
       {
           rb = GetComponent<Rigidbody2D>();
           bokStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<BokStamina>();
       }

       void Update()
       {
           Dash();
       }

       void Dash()
       {
           if (Input.GetKeyDown(KeyCode.Q) && canDash && bokStamina.stamina >= 20)
           {
               rb.AddForce(Vector2.left * dashingPower, ForceMode2D.Impulse);
               StartCoroutine(DashCooldown());
               bokStamina.stamina -= 20;
           }

           if (Input.GetKeyDown(KeyCode.E) && canDash && bokStamina.stamina >= 20)
           {
               rb.AddForce(Vector2.right * dashingPower, ForceMode2D.Impulse);
               StartCoroutine(DashCooldown());
               bokStamina.stamina -= 20;
           }
       }

       private IEnumerator DashCooldown()
       {
           isDashing = true;
           canDash = false;
           hasDashed = true;
           yield return new WaitForSeconds(dashingTime);
           isDashing = false;
           hasDashed = false;
           yield return new WaitForSeconds(dashingCooldown);
           canDash = true;
       }
       
       
    } 
}
