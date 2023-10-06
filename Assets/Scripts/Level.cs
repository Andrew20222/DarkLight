using System;
using UnityEngine;

namespace Scripts.Healths
{
    [Serializable]
    public class Level
    {
        [field:SerializeField] public GameObject Prefab { get; private set; }
    }
}