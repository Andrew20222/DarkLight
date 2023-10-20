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
    [SerializeField] private ButtonManager homeButton;
    [SerializeField] private CanvasGroup menuScreen;
    [SerializeField] private CanvasGroup settingScreen;

    public void OnEnable()
    {
        playButton.onClick.AddListener(Play);
        settingButton.onClick.AddListener(Setting);
        quitButton.onClick.AddListener(Quit);
        tutorialButton.onClick.AddListener(Tutorial);
        homeButton.onClick.AddListener(Home);
    }

    public void Home()
    {
        SetPanel(menuScreen, true, 1);
        SetPanel(settingScreen, false, 0);
    }

    private void Start()
    {
        SetPanel(menuScreen, true, 1);
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Setting()
    {
        SetPanel(menuScreen, false, 0);

        SetPanel(settingScreen, true, 1);
        
    }


    public void Tutorial()
    {
        SceneManager.LoadScene(5);
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void SetPanel(CanvasGroup canvasGroup, bool value, int alpha)
    {
        canvasGroup.alpha = alpha;
        canvasGroup.blocksRaycasts = value;
        canvasGroup.interactable = value;
            
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveListener(Play);
        settingButton.onClick.RemoveListener(Setting);
        quitButton.onClick.RemoveListener(Quit);
    }
}
