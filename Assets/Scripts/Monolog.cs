using Michsky.MUIP;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Monolog : MonoBehaviour
{
    [SerializeField] private GameObject[] ActionsOnStage = new GameObject[3];
    [SerializeField] private TextMeshProUGUI textMonolog;
    [SerializeField] private ButtonManager NextTextButton;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject light2D;
    

    private string[] texts = {
        "It is you.",
        "This is your worst enemy that will haunt you until you die.",
        "You can move with your mouse cursor. I do not advise you to touch the enemy. Click on the character.",
        "By the way, your enemy can also move... Don't die. If you die you have to start all over again",
        "It got a little dark. Is not it?",
        "Try to pass the level",
    };
    private int n = 0;
    private void Start()
    {

        enemyController.Init(player.transform);
        EnemyController._enabled = false;
        playerMove.UpdateFreezeTime(true);
        WaitTimeStart();
        ChangesInMonolog();
        n++;
        
    }
    private void Update()
    {
        EndTutorial();
    }

    private void EndTutorial()
    {
        if (!player.activeSelf)
        {
            textMonolog.text = "You lost try again. Click on the red button";
        }
        if (Detection.IsDetection)
        {
            Detection.IsDetection = false;
            SceneManager.LoadScene(0);
        }
    }

    public void NextText()
    {
        if (n == 3 && playerMove.IsFreeze == false)
        {

            ChangesInMonolog();
            n++;
        }
        else if (n == 4)
        {
            ChangesInMonolog();
            light2D.SetActive(true);
            n++;
        }
        else if (n < 3 || n > 4)
        {
            ChangesInMonolog();
            n++;
        }
        if (!player.activeSelf)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void ChangesInMonolog()
    {
        if (n < texts.Length && n >= 0 && player.IsDestroyed() == false)
        {
            switch (n)
            {
                case 2:
                    PlayerDrag._enabled = true;
                    break;
                case 3:
                    EnemyController._enabled = true;
                    break;

            }
            textMonolog.text = texts[n];

            if (n - 1 >= 0)
            {
                ActionsOnStage[n - 1].SetActive(false);
            }

            ActionsOnStage[n].SetActive(true);
        }
    }

   
    private IEnumerator WaitTimeStart()
    {
        yield return new WaitForSeconds(3f);
        textMonolog.text = texts[n];
        ActionsOnStage[n].SetActive(true);
        n++;
    }
}
