using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Vector3 movementDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (movementDirection == Vector3.zero) return;
        transform.position += movementDirection * Time.deltaTime;
    }

    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }

    // private void  OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.collider.CompareTag("Barrel"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrel"))
    {
       
        Destroy(gameObject);
    }
    }
}
