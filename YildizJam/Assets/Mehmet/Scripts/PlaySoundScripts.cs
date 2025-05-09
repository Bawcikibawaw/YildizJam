using UnityEngine;

namespace Mehmet.Scripts
{
    public enum AudioChannel
    {
        SFX,
        Music
    }

    public static class PlaySoundScripts
    {
        private static AudioSource sfxSource;
        private static AudioSource musicSource;

        static PlaySoundScripts()
        {
            // Sahnedeki objeleri isimlerine göre bul
            GameObject sfxObj = GameObject.Find("SFXSource");
            GameObject musicObj = GameObject.Find("MusicSource");

            if (sfxObj != null)
                sfxSource = sfxObj.GetComponent<AudioSource>();
            else
                Debug.LogWarning("SFXSource objesi bulunamadı!");

            if (musicObj != null)
                musicSource = musicObj.GetComponent<AudioSource>();
            else
                Debug.LogWarning("MusicSource objesi bulunamadı!");
        }

        public static void PlaySound(AudioChannel channel, string clipName)
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/" + clipName);
            if (clip == null)
            {
                Debug.LogWarning("Audio clip not found: " + clipName);
                return;
            }

            switch (channel)
            {
                case AudioChannel.SFX:
                    if (sfxSource == null) return;
                    sfxSource.Stop();
                    sfxSource.PlayOneShot(clip);
                    break;
                case AudioChannel.Music:
                    if (musicSource == null) return;
                    musicSource.Stop();
                    musicSource.clip = clip;
                    musicSource.loop = false;
                    musicSource.Play();
                    break;
            }
        }
    }
}
