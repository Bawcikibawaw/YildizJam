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
        private float lastTimeEventTriggered = -Mathf.Infinity;


        void Start()
        {
            isKabiz = false;
            isIshal = false;
        }

        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (Time.time >= lastTimeEventTriggered + cooldown)
                {
                    EventChoser();
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
            yield return new WaitForSecondsRealtime(1f);
            isIshal = false;
        }
        

    }
}
