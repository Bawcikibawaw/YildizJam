using Murat.Scripts.Runtime.BaseClass;
using UnityEngine;

namespace Murat.Scripts.Runtime.Managers
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private MenuBase[] menus;

        public void OpenMenu(MenuBase menu)
        {
            foreach (var item in menus)
            {
                if (item == menu)
                {
                    item.Open();
                }
                
                item.Close();
            }
        }
        
        public void OpenMenu(string menuName)
        {
            foreach (var item in menus)
            {
                if (item.GetMenuName() == menuName)
                {
                    item.Open();
                }
                
                item.Close();
            }
        }
        
    }
}
