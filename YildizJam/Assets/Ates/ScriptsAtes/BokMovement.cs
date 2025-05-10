using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class BokMovement : MonoBehaviour
    {
        public float moveSpeed = 1.0f;
        public float maxSpeed = 10.0f;
        public float minSpeed = 1.0f;
        public float acceleration = 5.0f;
        private Transform transform;
        public Animator animator;

        void Start()
        {
            transform = GetComponent<Transform>();
        }

        void Update()
        {
            Move();
            DeAcceleration();
            Side();
        }

        void Move()
        {
            if (Input.GetKey(KeyCode.D))
            {
                if(moveSpeed < maxSpeed) moveSpeed += acceleration * Time.deltaTime;
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                animator.SetInteger("Walk", 1);
            }

            if (Input.GetKey(KeyCode.A))
            {
                if(moveSpeed < maxSpeed) moveSpeed += acceleration * Time.deltaTime;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                animator.SetInteger("Walk", 1);
            }
        }

        void DeAcceleration()
        {
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) )
            {
                moveSpeed = minSpeed;
                animator.SetInteger("Walk", 0);
                
            }
        }
        
        void Side()
        {

            // Flip the player sprite based on movement direction
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localScale = new Vector3(1, 1, 1); // Facing right
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector3(-1, 1, 1); // Facing left
            }
        }
    }
}
