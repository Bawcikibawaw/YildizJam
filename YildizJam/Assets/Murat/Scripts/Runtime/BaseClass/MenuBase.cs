using UnityEngine;

namespace Murat.Scripts.Runtime.BaseClass
{
    public class MenuBase : MonoBehaviour
    {
        [SerializeField] private string menuName;

        private bool _isOpen;

        public virtual void Open()
        {
            if (_isOpen) return;
            _isOpen = true;
            gameObject.SetActive(_isOpen);
        }

        public virtual void Close()
        {
            if (!_isOpen) return;
            _isOpen = false;
            gameObject.SetActive(_isOpen);
        }

        public string GetMenuName()
        {
            return menuName;
        }
        
    }
}