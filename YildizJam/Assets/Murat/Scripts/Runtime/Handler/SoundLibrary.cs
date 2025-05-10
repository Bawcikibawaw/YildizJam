using Murat.Scripts.Runtime.Keys;
using UnityEngine;

namespace Murat.Scripts.Runtime.Handler
{
    public class SoundLibrary : MonoBehaviour
    {
        [SerializeField] SFXSO[] soundEffects;

        public SFXSO GetClipFromName(string name)
        {
            foreach (SFXSO soundEffect in soundEffects)
            {
                if(soundEffect.groupName == name)
                {
                    return soundEffect;
                }
            }
            
            return null;
        }
    }
}