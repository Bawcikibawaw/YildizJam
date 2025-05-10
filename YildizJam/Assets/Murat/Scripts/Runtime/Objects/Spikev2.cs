using System;
using System.Collections;
using Murat.Scripts.Runtime.Interfaces;
using UnityEngine;

public class Spikev2 : MonoBehaviour, IDamageable
{
    [SerializeField] private float timer;
    [SerializeField] private Animator myAnimator;

    private void Start()
    {
        InvokeRepeating(nameof(AnimInvoke), timer, timer);
    }

    private void AnimInvoke()
    {
        myAnimator.SetTrigger("Spike");
    }
    
    public void Damage()
    {
        
    }
    
}
