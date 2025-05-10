using System.Collections;
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

        private float _globalVolume = 0.5f;

        private Coroutine _playingCoroutine;

        private void OnEnable()
        {
            SFXEvents.Instance.onSFXVolumeChanged += OnSFXVolumeChange;
            _globalVolume = PlayerPrefs.GetFloat(Const.SFX_KEY, _globalVolume);
            audioSource.volume = _globalVolume;
        }

        private void OnDisable()
        {
            SFXEvents.Instance.onSFXVolumeChanged -= OnSFXVolumeChange;
        }

        private void OnSFXVolumeChange(float value)
        {
            _globalVolume = value;
            PlayerPrefs.SetFloat(Const.SFX_KEY, _globalVolume);
            audioSource.volume = _globalVolume;
        }

        public void PlaySound(string name)
        {
            SFXSO sfx = soundLibrary.GetClipFromName(name);

            if (sfx == null || sfx.GetClip() == null)
            {
                Debug.LogWarning($"Sound '{name}' not found in library.");
                return;
            }

            if (_playingCoroutine == null)
            {
                _playingCoroutine = StartCoroutine(PlaySoundCoroutine(sfx.GetClip(), sfx.volume * _globalVolume));
            }
        }

        private IEnumerator PlaySoundCoroutine(AudioClip clip, float volume)
        {
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.Play();

            yield return new WaitWhile(() => audioSource.isPlaying);

            _playingCoroutine = null;
        }
        
        
    }
}