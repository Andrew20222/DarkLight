using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Healths
{
    [CreateAssetMenu(menuName = "Levels", fileName = "LevelsSO", order = 0)]
    public class LevelSO : ScriptableObject
    {
        public List<Level> Levels;
    }
}