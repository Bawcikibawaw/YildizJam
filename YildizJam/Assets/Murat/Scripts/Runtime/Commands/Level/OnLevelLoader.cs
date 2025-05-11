using Murat.Scripts.Runtime.Data.ValueObject.Level;
using UnityEngine;

namespace Murat.Scripts.Runtime.Commands.Level
{
    public class OnLevelLoader
    {
        private Transform _levelHolder;

        public OnLevelLoader(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        
        public void Execute(LevelData data, int currentMapIndex)
        {
            Object.Instantiate(data.LevelObjects[currentMapIndex],data.LevelPositions[currentMapIndex], Quaternion.identity, _levelHolder);
        }
    }
}