using Murat.Scripts.Runtime.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Murat.Scripts.Runtime.Controllers
{
    public class BGController : MonoBehaviour
    {
        private Material _material;
        private float _scrollSpeed;
        private Vector2 _scrollPosition = Caches.Float2Zero;
        
        private void Start()
        {
            _material = GetComponent<SpriteRenderer>().material;
        }
        
        private void Update()
        {
            _material.mainTextureOffset += _scrollSpeed * Time.deltaTime * _scrollPosition;
        }

        public void SetDir(float x)
        {
            _scrollPosition.x = x;
        }

        public void SetScrollSpeed(float scrollSpeed)
        {
            this._scrollSpeed = scrollSpeed;
        }
    }
}
