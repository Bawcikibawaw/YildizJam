using System.Collections;
using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class MideGuruldama : MonoBehaviour
    {
        public bool hasGuruldama;
        private BokDash bokdash;
        private BokJump bokjump;
        public bool loopStarted;
        public AudioSource audioSource;
        public AudioClip guruldamaSound;

        void Start()
        {
            audioSource = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
            hasGuruldama = false;
            bokdash = GameObject.FindGameObjectWithTag("Player").GetComponent<BokDash>();
            bokjump = GameObject.FindGameObjectWithTag("Player").GetComponent<BokJump>();
        }
    
        void Update()
        {
            if (!hasGuruldama && !loopStarted)
            {
                loopStarted = true;
                StartCoroutine(Guruldama());
            }
        }

        private IEnumerator Guruldama()
        {
            yield return new WaitForSeconds(5f);
            audioSource.PlayOneShot(guruldamaSound);
            hasGuruldama = true;
            bokdash.enabled = false;
            bokjump.enabled = false;
            yield return new WaitForSeconds(5f);
            hasGuruldama = false;
            bokdash.enabled = true;
            bokjump.enabled = true;
            loopStarted = false;
        }
    
    
    }
}
