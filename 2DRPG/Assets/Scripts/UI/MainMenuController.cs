using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button _playButton;
    [SerializeField] Button _setttingsButton;
    [SerializeField] Button _exitButton;
    

    private void OnPlayClick()
    {
        SceneManager.LoadScene(1);
    }
    public void OnSettingsCkick()
    {

    }
    public void OnExitCkick()
    {
        Application.Quit();
    }


    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClick);
        _exitButton.onClick.AddListener(OnExitCkick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveAllListeners();
    }


}
