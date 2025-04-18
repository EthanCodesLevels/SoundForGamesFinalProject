using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) 
        {
            Pause();
        }

    }

    public void Pause()
    {

        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;

    }
    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("open menu");
    }
}
