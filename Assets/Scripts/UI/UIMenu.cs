using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private CanvasGroup menuScreen;
    [SerializeField] private CanvasGroup settingScreen;

    private void OnEnable()
    {
        playButton.onClick.AddListener(Play);
        settingButton.onClick.AddListener(Setting);
        quitButton.onClick.AddListener(Quit);
    }

    private void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Setting()
    {
        menuScreen.alpha = 0;
        settingScreen.alpha = 1;
    }

    private void Quit()
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
