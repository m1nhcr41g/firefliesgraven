
using UnityEngine;

public class HealedPotion : MonoBehaviour
{
    [SerializeField] private float healValue = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerHP = collision.GetComponent<PlayerMovement>();
        if (playerHP != null)
        {
            playerHP.Heal(healValue);
            Destroy(gameObject);
        }
    }
}
