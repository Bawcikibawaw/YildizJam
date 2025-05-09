using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Mehmet.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Mixer")]
        public AudioMixer audioMixer;

        [Header("Sliders")]
        public Slider musicSlider;
        public Slider sfxSlider;

        void Start()
        {
            // Oyun açıldığında önceki ayarları yükle
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(SetSFXVolume); 

            // Opsiyonel: Başlangıç değerleri (daha önce kaydedilmişse PlayerPrefs'ten çekebilirsin)
            float musicVol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
            float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
            musicSlider.value = musicVol;
            sfxSlider.value = sfxVol;
            SetMusicVolume(musicVol);
            SetSFXVolume(sfxVol);
        }

        public void SetMusicVolume(float value)
        {
            audioMixer.SetFloat("_music", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
            PlayerPrefs.SetFloat("MusicVolume", value);
        }

        public void SetSFXVolume(float value)
        {
            audioMixer.SetFloat("_sfx", Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20);
            PlayerPrefs.SetFloat("SFXVolume", value);
        }
    }
}
