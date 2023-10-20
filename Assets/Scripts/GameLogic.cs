using System;
using System.Collections;
using Scripts.Healths;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public event Action OnFinish;

    [SerializeField] private Detection detection;
    [SerializeField] private EnemyFactory enemyFactory;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private Health playerHealth;
    [SerializeField] private TextMeshProUGUI textFreezeTime;
    [SerializeField] private float countSpawnEnemy;

    public bool IsFreezeTime = true;
    private void OnEnable()
    {
        detection.OnChange += GameWin;
        playerHealth.OnDie += GameLose;
    }
    private void OnDisable()
    {
        detection.OnChange -= GameWin;
        playerHealth.OnDie -= GameLose;
    }


    private void Start()
    {
        playerMove.UpdateFreezeTime(IsFreezeTime);

        if (IsFreezeTime)
        {
            StartCoroutine(FreezeTime());
        }

        StartCoroutine(SpawnEnemy(countSpawnEnemy));
    }

    private IEnumerator SpawnEnemy(float amountEnemy)
    {
        for (int i = 0; i < amountEnemy + 2; i++)
        {
            yield return new WaitForSeconds(1f);
            if (IsFreezeTime) continue;
            var enemy = enemyFactory.GetNewInstance();
            enemy.Init(playerHealth.transform);
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

    private IEnumerator FreezeTime()
    {
        for (int i = 3; i > 0; i--)
        {
            textFreezeTime.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        textFreezeTime.enabled = false;
        IsFreezeTime = false;
        EnemyController._enabled = true;
        playerMove.UpdateFreezeTime(IsFreezeTime);
        
    }

    private IEnumerator SceneReloader()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator SceneLoader()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        if (SceneManager.GetActiveScene().buildIndex >= 4)
        {
            SceneManager.LoadScene(1);
        }
    }
}