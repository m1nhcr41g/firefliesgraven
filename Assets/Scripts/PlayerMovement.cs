using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement; //luu tru chieu ngang va chieu doc
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public PauseMenu pauseMenu;
    [SerializeField] private float maxHP = 100f;
    private float currentHP;
    [SerializeField] private Image hpBar;
    [SerializeField] private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;
        UpdateHP();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate() //movement
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void takeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        UpdateHP();
        if (currentHP <= 0)
        {
            Die();
        }
    }



    private void UpdateHP()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }

    public void Heal(float healValue)
    {
        if (currentHP < maxHP)
        {
            currentHP += healValue;
            currentHP = Mathf.Min(currentHP, maxHP);
            UpdateHP();
        }
    }

    private void Die()
    {
        pauseMenu.ShowGameOver();
        gameObject.SetActive(false);
    }
}
