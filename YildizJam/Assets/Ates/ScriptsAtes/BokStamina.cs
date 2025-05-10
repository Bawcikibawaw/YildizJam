using UnityEngine;

namespace Ates.ScriptsAtes
{
    public class BokStamina : MonoBehaviour
    {
        public float stamina = 100.0f;
        public float maxStamina = 100.0f;
        public float increaseStamina = 1.0f;

        void Start()
        {
            stamina = maxStamina;
        }

        void Update()
        {
            if (stamina < maxStamina)
            {
                stamina += increaseStamina;
            }
        }
    }
}
