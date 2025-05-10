using Murat.Scripts.Runtime.Managers;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.PlaySound("Walking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
