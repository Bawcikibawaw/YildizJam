using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class KabızIshal : MonoBehaviour
    {
        public bool isKabiz;
        public bool isIshal;
        public float cooldown = 2f;  // Cooldown süresi (saniye)
        public float sUse = 20;
        private float lastTimeEventTriggered = -Mathf.Infinity;
        private BokStamina bokStamina;
        private BoxCollider2D boxCollider;
        private Vector2 originalSize;
        public Vector2 shrinkSize = new Vector2(0.2f, 0.2f);


        void Start()
        {
            isKabiz = false;
            isIshal = false;
            bokStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<BokStamina>();
            boxCollider = GetComponent<BoxCollider2D>();
            originalSize = boxCollider.size;
        }

        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Time.time >= lastTimeEventTriggered + cooldown)
                {
                    EventChoser();
                    bokStamina.stamina -= sUse;
                    lastTimeEventTriggered = Time.time;
                }
                else
                {
                    Debug.Log("Bekleme süresi dolmadı!");
                }
            }
        }

        void EventChoser()
        {
            int choice = Random.Range(0, 2); // 0 veya 1 değerini alır 

            if (choice == 0)
            {
                StartCoroutine(Kabiz());
            }
            else
            {
                StartCoroutine(Ishal());
            }

        }

        

        private IEnumerator Kabiz()
        {
            isKabiz = true;
            yield return new WaitForSecondsRealtime(1f);
            isKabiz = false;
        }

        private IEnumerator Ishal()
        {
            isIshal = true;
            boxCollider.size = shrinkSize;
            yield return new WaitForSecondsRealtime(1f);
            boxCollider.size = originalSize;
            isIshal = false;
        }
        

    }
}
