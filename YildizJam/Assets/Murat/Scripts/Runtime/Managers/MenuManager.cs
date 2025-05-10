using System;
using Murat.Scripts.Runtime.BaseClass;
using Murat.Scripts.Runtime.Events;
using Murat.Scripts.Runtime.Extensions;
using Murat.Scripts.Runtime.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Murat.Scripts.Runtime.Managers
{
    public class MenuManager : MonoSingleton<MenuManager>
    {
        [SerializeField] private MenuBase[] menus;
        
        [SerializeField] private Slider sfxSlider;
        [SerializeField] private Slider musicSlider;
        
        private void Start()
        {
            OpenMenu("MainMenu");

            sfxSlider.value = PlayerPrefs.GetFloat(Const.SFX_KEY);
            musicSlider.value = PlayerPrefs.GetFloat(Const.MUSIC_KEY);
        }

        public void OnSFXVolumeChanged()
        {
            SFXEvents.Instance.onSFXVolumeChanged.Invoke(sfxSlider.value);
        }
        
        public void OnMusicVolumeChanged()
        {
            SFXEvents.Instance.onMusicVolumeChanged?.Invoke(musicSlider.value);
        }

        public void OpenMenu(MenuBase menu)
        {
            foreach (var item in menus)
            {
                item.Close();
                
                if (item == menu)
                {
                    item.Open();
                }
            }
        }
        
        public void OpenMenu(string menuName)
        {
            foreach (var item in menus)
            {
                item.Close();
                
                if (item.GetMenuName() == menuName)
                {
                    item.Open();
                }
            }
        }

        public void CloseAllMenu()
        {
            foreach (var item in menus)
            {
                item.Close();
            }
        }

        public void Quit()
        {
            Application.Quit();
        }
        
    }
}
