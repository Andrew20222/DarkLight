using Michsky.MUIP;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIMenu : MonoBehaviour
{
    [SerializeField] private ButtonManager playButton;
    [SerializeField] private ButtonManager settingButton;
    [SerializeField] private ButtonManager tutorialButton;
    [SerializeField] private ButtonManager quitButton;
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject settingScreen;

    public void OnEnable()
    {
        playButton.onClick.AddListener(Play);
        settingButton.onClick.AddListener(Setting);
        quitButton.onClick.AddListener(Quit);
        tutorialButton.onClick.AddListener(Tutorial);

    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Setting()
    {
        menuScreen.SetActive(false);
        
        settingScreen.SetActive(true);
        
    }


    public void Tutorial()
    {
        SceneManager.LoadScene(5);
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(Play);
        settingButton.onClick.RemoveListener(Setting);
        quitButton.onClick.RemoveListener(Quit);
    }
}
