using Murat.Scripts.Runtime.Data.ValueObject.Level;
using UnityEngine;

namespace Murat.Scripts.Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Level", menuName = "SO/CD_Level", order = 0)]
    public class CD_Level : ScriptableObject
    {
        public LevelData[] LevelData;
    }
}