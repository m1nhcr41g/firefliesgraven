using UnityEngine;
public class Explosion : MonoBehaviour
{
    [SerializeField] private float damage = 0f;
    [SerializeField] private AudioManager audioManager;
    private bool hasExploded = false;

    private void Start()
{
    if (audioManager == null)
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }
}

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasExploded) return;

        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.takeDamage(damage);
                playExplosion("Player");
            }
        }
        else if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(damage);
                playExplosion("Enemy");
            }
        }
    }

    private void playExplosion(string target)
    {
        if (!hasExploded && audioManager != null)
        {
            audioManager.playExplosiveSound();
            hasExploded = true;
        }
    }

    public void DestroyRacoon()
    {
        Destroy(gameObject);
    }

}
