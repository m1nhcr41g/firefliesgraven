using UnityEngine;

public class Racoon : Enemy
{
    [SerializeField] private GameObject explosionPrefab;
    private void Explosion()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }

    protected override void Die()
    {
        Explosion();
        base.Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Explosion();
            Destroy(gameObject);
        }       
    }

}
