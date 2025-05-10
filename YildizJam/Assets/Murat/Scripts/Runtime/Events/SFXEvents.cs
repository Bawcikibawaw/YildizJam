using Murat.Scripts.Runtime.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Murat.Scripts.Runtime.Events
{
    public class SFXEvents : MonoSingleton<SFXEvents>
    {
        public UnityAction<float> onSFXVolumeChanged;
        public UnityAction<float> onMusicVolumeChanged;
    }
}
