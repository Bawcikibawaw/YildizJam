using UnityEngine;
using UnityEngine.UI;

namespace Ates.ScriptsAtes
{
    public class BokStamina : MonoBehaviour
    {
        public float stamina = 100.0f;
        public float maxStamina = 100.0f;
        public float increaseStamina = 1.0f;
        public Image staminaBarFill; // Reference to the stamina bar fill image

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
            
            UpdateStaminaBar();
        }
        
        private void UpdateStaminaBar()
        {
            // Update the fill amount of the stamina bar
            staminaBarFill.fillAmount = stamina / maxStamina;
        }
    }
}
