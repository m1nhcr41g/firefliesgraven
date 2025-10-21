using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private AudioManager audioManager;
    // [SerializeField] private GameObject winNoti;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Healed_Item"))
        {
            PlayerMovement player = GetComponent<PlayerMovement>();
            player.Heal(0f);
            Destroy(collision.gameObject);
            audioManager.playGetItemSound();
        }
        else if (collision.CompareTag("Item"))
        {
            gameManager.addRecallPoint();
            Destroy(collision.gameObject);
            audioManager.playGetItemSound();
        }

        else if (collision.CompareTag("BossBullet"))
        {
            PlayerMovement player = GetComponent<PlayerMovement>();
            player.takeDamage(10f);
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("WinItem"))
        {
            audioManager.playGetItemSound();
            if (pauseMenu != null)
                pauseMenu.ShowGameWin();

            if (audioManager != null)
                audioManager.stopAudio();
            audioManager.playWinSound();

            Destroy(collision.gameObject);
        }
    }

    
}
