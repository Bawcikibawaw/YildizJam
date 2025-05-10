using Murat.Scripts.Runtime.Managers;
using UnityEngine;

namespace Murat.Scripts.Runtime.BaseClass
{
    public class MenuBase : MonoBehaviour
    {
        [SerializeField] private string menuName;

        private bool _isOpen;

        public void Open()
        {
            if (_isOpen) return;
            _isOpen = true;
            gameObject.SetActive(_isOpen);
        }

        public void Close()
        {
            if (!_isOpen) return;
            _isOpen = false;
            gameObject.SetActive(_isOpen);
        }

        public void OpenMenu(string name)
        {
            MenuManager.Instance.OpenMenu(name);
        }

        public void CloseMenu()
        {
            MenuManager.Instance.CloseAllMenu();
        }

        public string GetMenuName()
        {
            return menuName;
        }
        
    }
}