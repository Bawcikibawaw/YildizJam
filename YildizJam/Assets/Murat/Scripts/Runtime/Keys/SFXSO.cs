using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Murat.Scripts.Runtime.Keys
{
    [CreateAssetMenu(menuName = "Sound Effect", fileName = "SO/SoundEffect")]
    public class SFXSO : ScriptableObject
    {
        public string groupName;
        public float volume;
        public AudioClip[] clips;

        public AudioClip GetClip()
        {
            return clips[Random.Range(0, clips.Length)];
        }
    }
}