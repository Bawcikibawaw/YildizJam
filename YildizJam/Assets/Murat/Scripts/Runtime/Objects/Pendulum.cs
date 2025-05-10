using System;
using System.Collections.Generic;
using DG.Tweening;
using Murat.Scripts.Runtime.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Murat.Scripts.Runtime.Objects
{
    public class Pendulum : MonoBehaviour, IDamageable
    {
        [SerializeField] private float angle;
        [SerializeField] private float duration;
        [SerializeField] private List<Ease> easeMods;
        
        private Vector3 _endPos = Vector3.zero;
        
        private Ease _currentEase = Ease.Linear;

        private void Start()
        {
            MoveAngle(angle);
            InvokeRepeating(nameof(ChangeMovePattern),0, duration * 2);
        }

        private void MoveAngle(float angle)
        {
            _endPos.z = -angle;
            transform.DORotate(_endPos, duration, RotateMode.Fast).SetEase(_currentEase).OnComplete(() =>
            {
                MoveAngle(_endPos.z);
            });
        }

        private void ChangeMovePattern()
        {
            List<Ease> changeEaseMods = new List<Ease>(easeMods);
            changeEaseMods.Remove(_currentEase);
            _currentEase = changeEaseMods[Random.Range(0, changeEaseMods.Count)];
        }
        
        public void Damage()
        {
            
        }
        
    }
}
