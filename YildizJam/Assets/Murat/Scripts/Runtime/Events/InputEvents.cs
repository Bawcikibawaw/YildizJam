using Murat.Scripts.Runtime.Extensions;
using Unity.Mathematics;
using UnityEngine.Events;

namespace Murat.Scripts.Runtime.Events
{
    public class InputEvents : MonoSingleton<InputEvents>
    {
        public UnityAction<float2> onMoveStart;
        public UnityAction onMoveStop;
        public UnityAction onJumpStart;
        public UnityAction onJumpCanceled;
        public UnityAction onDash;

    }
}
