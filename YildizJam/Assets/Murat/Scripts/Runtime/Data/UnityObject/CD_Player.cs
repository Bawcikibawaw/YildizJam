using Murat.Scripts.Runtime.Data.ValueObject;
using UnityEngine;

namespace Murat.Scripts.Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Player", menuName = "SO/CD_Player", order = 0)]
    public class CD_Player : ScriptableObject
    {
        public PlayerMovementData  PlayerMovementData;
        public PlayerJumpData PlayerJumpData;
    }
}