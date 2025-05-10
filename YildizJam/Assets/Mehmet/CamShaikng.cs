using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CamShaikng : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool isShaking = false;
    private MideGuruldama mideGuruldama;
    
    
    
    [SerializeField] private float camShakingDuration;
    [SerializeField] private float camShakingStreng;

    private void Start()
    {
      mideGuruldama= GameObject.FindGameObjectWithTag("Manager").GetComponent<MideGuruldama>();
    }

    private void Update()
    {
        if (mideGuruldama.hasGuruldama)
        {
            ShakeCamera(camShakingDuration,camShakingStreng);
        }
    }

    public void ShakeCamera(float duration, float strength)
    {
        if (!isShaking) StartCoroutine(Shake(duration, strength));
    }

    private System.Collections.IEnumerator Shake(float duration, float strength)
    {
        isShaking = true;
        originalPosition = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;

            transform.localPosition = originalPosition + new Vector3(x, y, 0f);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
        isShaking = false;
    }
}
