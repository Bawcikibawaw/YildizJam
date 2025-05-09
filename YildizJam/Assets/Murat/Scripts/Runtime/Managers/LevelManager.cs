using Murat.Scripts.Runtime.Commands.Level;
using Murat.Scripts.Runtime.Data.ValueObject.Level;
using Murat.Scripts.Runtime.Extensions;
using UnityEngine;

namespace Murat.Scripts.Runtime.Managers
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        [SerializeField] private Transform levelHolder;
    
        private OnLevelLoader _levelLoader;
        private OnLevelDestroyer _levelDestroyer;

        private LevelData _currenLevelData;

        private int _currentMapIndex;

        protected override void Awake()
        {
            base.Awake();
            _levelLoader = new OnLevelLoader(levelHolder);
            _levelDestroyer = new OnLevelDestroyer(levelHolder);
        }

        public void OnLoadNewMap()
        {
            _levelDestroyer.Execute();
            _currentMapIndex++;
            _levelLoader.Execute(_currenLevelData.LevelObjects[_currentMapIndex]);
        }

        public void SetNewLevelData(LevelData levelData)
        {
            _currenLevelData = levelData;
            _currentMapIndex = 0;
            OnLoadNewMap();
        }
        
    }
}
