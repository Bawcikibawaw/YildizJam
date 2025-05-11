using System.Collections;
using UnityEngine;

public class SnakeCollider : MonoBehaviour
{
    public float SnakeCooldown;
    private Vector2 originalSize;
    public Vector2 shrinkSize = new Vector2(0.2f, 0.2f);
    private BoxCollider2D boxCollider;
    private bool loopStarter = true;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        originalSize = boxCollider.size;
    }
    
    
    void Update()
    {
        if(loopStarter)
        {
            StartCoroutine(Snake()); 
        }
        
    }

    private IEnumerator Snake()
    {
        loopStarter = false;
        boxCollider.size = shrinkSize;
        yield return new WaitForSeconds(SnakeCooldown);
        boxCollider.size = originalSize;
        yield return new WaitForSeconds(SnakeCooldown);
        loopStarter = true;
    }
}
