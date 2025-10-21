
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagement : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject tutorialPanel;
    public void playGame()
    {
        audioManager.playDefaultBackground();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void openTutorial()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true); 
        }
    }

     public void closeTutorial()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
