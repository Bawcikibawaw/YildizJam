using System;
using Murat.Scripts.Runtime.Events;
using Murat.Scripts.Runtime.Extensions;
using Murat.Scripts.Runtime.Handler;
using Murat.Scripts.Runtime.Helpers;
using Murat.Scripts.Runtime.Keys;
using UnityEngine;

namespace Murat.Scripts.Runtime.Managers
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        [SerializeField] private SoundLibrary soundLibrary;
        
        [SerializeField] private AudioSource audioSource;

        private float _globalVolume = .5f;

        private void OnEnable()
        {
            SFXEvents.Instance.onSFXVolumeChanged += OnSFXVolumeChange;
            audioSource.volume = PlayerPrefs.GetFloat(Const.SFX_KEY, _globalVolume);
        }

        private void OnSFXVolumeChange(float value)
        {
            _globalVolume = value;
            PlayerPrefs.SetFloat(Const.SFX_KEY,_globalVolume);
        }

        public void PlaySound(string name)
        {
            SFXSO sfx = soundLibrary.GetClipFromName(name);
            audioSource.PlayOneShot(sfx.GetClip(), sfx.volume * _globalVolume);
        }

        private void OnDisable()
        {
            SFXEvents.Instance.onSFXVolumeChanged -= OnSFXVolumeChange;
        }
        
    }
}
