using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murat.Scripts.Runtime.Events;
using Murat.Scripts.Runtime.Extensions;
using Murat.Scripts.Runtime.Handler;
using Murat.Scripts.Runtime.Helpers;
using Murat.Scripts.Runtime.Keys;

namespace Murat.Scripts.Runtime.Managers
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        [SerializeField] private SoundLibrary soundLibrary;
        [SerializeField] private AudioSource audioSource;

        private float _globalVolume = 0.5f;
        private Queue<AudioRequest> _audioQueue = new();
        private bool _isPlaying = false;

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

            _audioQueue.Enqueue(new AudioRequest(sfx.GetClip(), sfx.volume * _globalVolume));
            
            if (!_isPlaying)
                StartCoroutine(PlayQueue());
        }

        private IEnumerator PlayQueue()
        {
            _isPlaying = true;

            while (_audioQueue.Count > 0)
            {
                var request = _audioQueue.Dequeue();
                audioSource.clip = request.Clip;
                audioSource.volume = request.Volume;
                audioSource.Play();

                yield return new WaitWhile(() => audioSource.isPlaying);
            }

            _isPlaying = false;
        }

        private class AudioRequest
        {
            public AudioClip Clip { get; }
            public float Volume { get; }

            public AudioRequest(AudioClip clip, float volume)
            {
                Clip = clip;
                Volume = volume;
            }
        }
    }
}
