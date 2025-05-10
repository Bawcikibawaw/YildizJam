using Murat.Scripts.Runtime.Events;
using Murat.Scripts.Runtime.Extensions;
using Murat.Scripts.Runtime.Helpers;
using UnityEngine;

namespace Murat.Scripts.Runtime.Managers
{
    public class MusicManager : MonoSingleton<MusicManager>
    {
        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioClip mainMenu;
        [SerializeField] private AudioClip gameplay;

        private float _globalVolume = .5f;

        private void OnEnable()
        {
            SFXEvents.Instance.onMusicVolumeChanged += OnMusicVolumeChange;
            audioSource.volume = PlayerPrefs.GetFloat(Const.SFX_KEY, _globalVolume);
        }

        private void OnMusicVolumeChange(float value)
        {
            _globalVolume = value;
            audioSource.volume = _globalVolume;
            PlayerPrefs.SetFloat(Const.MUSIC_KEY,_globalVolume);
        }
        
    }
}
