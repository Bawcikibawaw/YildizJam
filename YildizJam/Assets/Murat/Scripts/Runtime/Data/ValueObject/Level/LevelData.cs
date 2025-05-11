using System;
using UnityEngine;

namespace Murat.Scripts.Runtime.Data.ValueObject.Level
{
    [Serializable]
    public struct LevelData
    {
        public GameObject[] LevelObjects;
        public Vector3[] LevelPositions;
    }
}