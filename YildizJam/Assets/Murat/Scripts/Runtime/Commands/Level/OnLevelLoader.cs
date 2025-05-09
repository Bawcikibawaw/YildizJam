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
        
        public void Execute(GameObject spawnLevel)
        {
            Object.Instantiate(spawnLevel,_levelHolder, true);
        }
    }
}