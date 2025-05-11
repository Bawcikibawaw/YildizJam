using Murat.Scripts.Runtime.Commands.Level;
using Murat.Scripts.Runtime.Data.UnityObject;
using Murat.Scripts.Runtime.Extensions;
using UnityEngine;

namespace Murat.Scripts.Runtime.Managers
{
    public class LevelManager : MonoSingleton<LevelManager>
    {
        [SerializeField] private Transform levelHolder;
    
        private OnLevelLoader _levelLoader;
        private OnLevelDestroyer _levelDestroyer;

        private CD_Level _currenLevelData;

        private int _currentLevelIndex;
        private int _currentMapIndex;

        protected override void Awake()
        {
            base.Awake();
            _levelLoader = new OnLevelLoader(levelHolder);
            _levelDestroyer = new OnLevelDestroyer(levelHolder);

            _currenLevelData = Resources.Load<CD_Level>("Data/CD_Level");
            
            _levelLoader.Execute(_currenLevelData.LevelData[_currentLevelIndex],_currentMapIndex);
        }

        public void OnLoadNewMap()
        {
            _levelDestroyer.Execute();
            _currentMapIndex++;
            _levelLoader.Execute(_currenLevelData.LevelData[_currentLevelIndex],_currentMapIndex);
        }
        
        public void Reset()
        {
            _currentMapIndex = 0;
            OnLoadNewMap();
        }

        public void SetNewLevelData()
        {
            _currentLevelIndex++;
            _currentMapIndex = 0;
            OnLoadNewMap();
        }
        
    }
}
