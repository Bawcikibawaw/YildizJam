using System.Collections;
using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class BokMovement : MonoBehaviour
    {
        public float moveSpeed = 2.0f;
        private float gurulMoveSpeed = 1.0f;
        
        public float maxSpeed = 10.0f;
        private float gurulMaxSpeed = 1.0f;
        
        public float minSpeed = 2.0f;
        private float gurulMinSpeed = 1.0f;
        
        public float acceleration = 5.0f;
        private float gurulAcceleration = 2.5f;
       
        private Transform transform;
        public Animator animator;
        private MideGuruldama mideGuruldama;
        private KabızIshal kabızIshal;

        void Start()
        {
            transform = GetComponent<Transform>();
            mideGuruldama = GameObject.FindGameObjectWithTag("Manager").GetComponent<MideGuruldama>();
            kabızIshal = GameObject.FindGameObjectWithTag("Player").GetComponent<KabızIshal>();
        }

        void Update()
        {
            Move();
            DeAcceleration();
            Side();

            if (mideGuruldama.hasGuruldama && mideGuruldama.loopStarted)
            {
                StartCoroutine(GurulMove());
            }
        }

        void Move()
        {
            if (Input.GetKey(KeyCode.D) && kabızIshal.isKabiz)
            {
                if(moveSpeed < maxSpeed) moveSpeed += acceleration * Time.deltaTime / 2;
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                animator.SetInteger("Walk", 1);
            }

            if (Input.GetKey(KeyCode.A) && kabızIshal.isKabiz)
            {
                if(moveSpeed < maxSpeed) moveSpeed += acceleration * Time.deltaTime / 2;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                animator.SetInteger("Walk", 1);
            }
            
            if (Input.GetKey(KeyCode.D) && kabızIshal.isIshal)
            {
                if(moveSpeed < maxSpeed) moveSpeed += acceleration * Time.deltaTime * 2;
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                animator.SetInteger("Walk", 1);
            }

            if (Input.GetKey(KeyCode.A) && kabızIshal.isIshal)
            {
                if(moveSpeed < maxSpeed) moveSpeed += acceleration * Time.deltaTime * 2;
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                animator.SetInteger("Walk", 1);
            }
            
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

        private IEnumerator GurulMove()
        {
            minSpeed = gurulMinSpeed;
            maxSpeed = gurulMaxSpeed;
            acceleration = gurulAcceleration;
            yield return new WaitForSecondsRealtime(5f);
            minSpeed = 2f;
            maxSpeed = 10f;
            acceleration = 5f;
        }
    }
}
