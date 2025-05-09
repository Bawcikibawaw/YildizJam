using UnityEngine;

namespace Murat.Scripts.Runtime.Commands.Level
{
    public class OnLevelDestroyer
    {
        private Transform _levelHolder;

        public OnLevelDestroyer(Transform levelHolder)
        {
            _levelHolder = levelHolder;
        }
        
        public void Execute()
        {
            Object.Destroy(_levelHolder.GetChild(0).gameObject);
        }
    }
}