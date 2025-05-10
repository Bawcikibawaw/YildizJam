using Murat.Scripts.Runtime.Extensions;
using Murat.Scripts.Runtime.Handler;
using Murat.Scripts.Runtime.Keys;
using UnityEngine;

namespace Murat.Scripts.Runtime.Managers
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        [SerializeField] private SoundLibrary soundLibrary;
        
        [SerializeField] private AudioSource audioSource;

        public void PlaySound(string name)
        {
            SFXSO sfx = soundLibrary.GetClipFromName(name);
            audioSource.PlayOneShot(sfx.GetClip(), sfx.volume);
        }
        
    }
}
