using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject menuWindow;

    public MonoBehaviour[] componentsToDisaple;

    public void OpenMenuWindow()
    {
        menuButton.SetActive(false);
        menuWindow.SetActive(true);
        ScriptsManager(false);
        Time.timeScale = 0.01f;
    }

    public void CloseMenuWindow()
    {
        menuButton.SetActive(true);
        menuWindow.SetActive(false);
        ScriptsManager(true);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ScriptsManager(bool value)
    {
        for (int i = 0; i < componentsToDisaple.Length; i++)
        {
            componentsToDisaple[i].enabled = value;
        }
    }
}
