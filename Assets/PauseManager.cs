using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsWindow;

    public GameObject pauseButton;

    public void activePause()
    {
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }
    // Start is called before the first frame update
    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void settingsButton()
    {
        settingsWindow.SetActive(true);
    }
    public void closeSettingsWindow()
    {
        settingsWindow.SetActive(false);
    } 
}
