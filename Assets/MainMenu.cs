using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   public string firstLevel;
   public GameObject settingsWindow;

   public void startGame()
    {
        SceneManager.LoadScene(firstLevel);    
    }
    public void settingsButton()
    {
        settingsWindow.SetActive(true);
    }
    public void closeSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
