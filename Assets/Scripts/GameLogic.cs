using System;
using System.Collections;
using Scripts.Healths;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public event Action OnFinish;
    
    [SerializeField] private Detection detection;
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private Health player;
    [SerializeField] private float countSpawnEnemy;

    private void OnEnable()
    {
        detection.OnChange += GameWin;
        player.OnDie += GameLose;
    }
    
    private void OnDisable()
    {
        detection.OnChange -= GameWin;
        player.OnDie -= GameLose;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy(countSpawnEnemy));
    }

    private IEnumerator SpawnEnemy(float amountEnemy)
    {
        for (int i = 0; i < amountEnemy; i++)
        {
            yield return new WaitForSeconds(1f);
            var enemy = enemyFactory.GetNewInstance();
            enemy.Init(player.transform);
        }
    }

    private void GameWin()
    {
        StartCoroutine(SceneLoader());
    }

    private void GameLose()
    {
        StartCoroutine(SceneReloader());
    }

    private IEnumerator SceneReloader()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private IEnumerator SceneLoader()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        
        if (SceneManager.GetActiveScene().buildIndex >= 4)
        {
            SceneManager.LoadScene(1);
        }
    }
}