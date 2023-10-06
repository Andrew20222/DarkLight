using System;
using Scripts.Healths;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private LevelSO levelSo;
    [SerializeField] private GameLogic gameLogic;
    private int _id;

    private void OnEnable()
    {
        gameLogic.OnFinish += () => Instantiate(levelSo.Levels[_id++].Prefab);
    }

    private void Start()
    {
        _id = 0;
        Instantiate(levelSo.Levels[_id].Prefab);
    }
}
