using System;
using Ates.ScriptsAtes;
using Murat.Scripts.Runtime.Controllers;
using Murat.Scripts.Runtime.Data.UnityObject;
using Murat.Scripts.Runtime.Data.ValueObject;
using Murat.Scripts.Runtime.Data.ValueObject.BG;
using Murat.Scripts.Runtime.Events;
using Unity.Mathematics;
using UnityEngine;

namespace Murat.Scripts.Runtime.Managers
{
    public class BGManager : MonoBehaviour
    {
        [SerializeField] private BGController[] bgs;

        [SerializeField] private BokMovementFinal movement;

        private CD_BG _data;

        private void Awake()
        {
            GetData();
        }
        
        private void GetData()
        {
            _data = Resources.Load<CD_BG>("Data/CD_BG");
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputEvents.Instance.onMoveStart += OnStartMove;
            InputEvents.Instance.onMoveStop += OnStopMove;
        }

        private void Update()
        {
            SetAllBGsDir(movement.GetXInput);
        }

        private void OnStartMove(float2 value)
        {
            SetAllBGsDir(value.x);
        }
        
        private void OnStopMove()
        {
            SetAllBGsDir(0);
        }

        private void UnSubscribeEvents()
        {
            InputEvents.Instance.onMoveStart -= OnStartMove;
            InputEvents.Instance.onMoveStop -= OnStopMove;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void Start()
        {
            SetAllBGsSpeed();
        }

        private void SetAllBGsSpeed()
        {
            for (int i = 0; i < bgs.Length; i++)
            {
                bgs[i].SetScrollSpeed(_data.BgDatas[i].ScrollingSpeed);
            }
        }

        private void SetAllBGsDir(float x)
        {
            foreach (var item in bgs)
            {
                item.SetDir(x);
            }
        }
    }
}
