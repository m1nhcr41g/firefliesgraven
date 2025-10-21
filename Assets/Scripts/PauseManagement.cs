using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public GameObject pointBarUI;
    private bool isPaused = false;
    private bool isGameOver = false;

    private bool isGameWin = false;


    void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;
        isGameOver = false;
        if (pauseMenuUI != null) pauseMenuUI.SetActive(false);
        if (gameOverUI != null) gameOverUI.SetActive(false);
        if (gameWinUI != null) gameWinUI.SetActive(false);
        if (pointBarUI != null) pointBarUI.SetActive(true);
    }

    void Update()
    {
        if (isGameOver) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if (pointBarUI != null) pointBarUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        if (pointBarUI != null) pointBarUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("UI");
    }

    public void ShowGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        if (gameOverUI != null) gameOverUI.SetActive(true);
        if (pointBarUI != null) pointBarUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ShowGameWin()
    {
        if (isGameWin) return;
        isGameWin = true;
        if (gameWinUI != null) gameWinUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void reTry()
    {
        isGameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}
