using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Tutorial()
    {
        Application.OpenURL("https://github.com/xanorade/DGD070-EyupCanErkal");
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("First Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}