using UnityEngine;

namespace Murat.Scripts.Runtime.Objects
{
    public class CollideObject : MonoBehaviour
    {
        public Vector3 newPlayerPosition;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                // Sana çarpan Player nesnesinin transformunu değiştir
                collision.gameObject.transform.position = newPlayerPosition;

            }
        }
    }
}
