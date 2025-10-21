using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float bulletSpeed = 25f;
    [SerializeField] private float timeDestroy = 0.5f;
    [SerializeField] private float damage = 10f;
    [SerializeField] GameObject bloodPrefabs;
    void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }

    void moveBullet()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takeDamage(damage);
                GameObject blood = Instantiate(bloodPrefabs, transform.position, Quaternion.identity);
                Destroy(blood, 1f);
            }
            Destroy(gameObject);
        }

        else if (collision.CompareTag("Barrel"))
    {
            Debug.Log("hit");
            Destroy(gameObject);
    }
    }

   
}
