using UnityEngine;

public class Healed_Enemy : Enemy
{
    [SerializeField] private GameObject enemyItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(EnterDamage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.takeDamage(stayDamage);
            }
        }
    }
    
    protected override void Die()
    {
        if (enemyItem != null)
        {
            GameObject Item = Instantiate(enemyItem, transform.position, Quaternion.identity);
            Destroy(Item, 5f);
        }
        base.Die();
    }
  
}
