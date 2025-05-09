using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class BokMovement : MonoBehaviour
    {
        public float moveSpeed = 5.0f;
        public float maxSpeed = 10.0f;
        public float acceleration = 5.0f;
        private Transform transform;

        void Start()
        {
            transform = GetComponent<Transform>();
        }

        void Update()
        {
            Move();
            DeAcceleration();
        }

        void Move()
        {
            if (Input.GetKey(KeyCode.D))
            {
                if(moveSpeed < maxSpeed) moveSpeed += acceleration * Time.deltaTime;
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                if(moveSpeed < maxSpeed) moveSpeed += acceleration * Time.deltaTime;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
        }

        void DeAcceleration()
        {
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) )
            {
                moveSpeed = 5;
            }
        }
    }
}
