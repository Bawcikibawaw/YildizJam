using Murat.Scripts.Runtime.Data.ValueObject.BG;
using UnityEngine;

namespace Murat.Scripts.Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_BG", menuName = "SO/CD_BG", order = 0)]
    public class CD_BG : ScriptableObject
    {
        public BGData[] BgDatas;
    }
}