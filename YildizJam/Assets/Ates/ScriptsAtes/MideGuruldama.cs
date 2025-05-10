using System.Collections;
using System.Collections.Generic;
using Ates.ScriptsAtes;
using UnityEngine;

public class MideGuruldama : MonoBehaviour
{
    public bool hasGuruldama;
    private BokDash bokdash;
    private BokJump bokjump;
    public bool loopStarted;

    void Start()
    {
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
