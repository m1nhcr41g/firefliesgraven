// using UnityEngine;
// using UnityEngine.UI;

// public abstract class Enemy : MonoBehaviour
// {
//     [SerializeField] protected float enemyMoveSpeed = 1f;
//     protected PlayerMovement player;

//     [SerializeField] protected float maxHP = 50f;
//     protected float currentHP;
//     [SerializeField] private Image hpBar;
//     [SerializeField] protected float EnterDamage = 10;
//     [SerializeField] protected float stayDamage = 1f;
//     protected virtual void Start()
//     {
//         player = FindAnyObjectByType<PlayerMovement>();
//         currentHP = maxHP;
//         UpdateHP();
//     }

//     protected virtual void Update()
//     {
//         MoveToPlayer();
//     }

//     protected void MoveToPlayer()
//     {
//         if (player != null)
//         {
//             transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
//             FlipEnemy();
//         }
//     }
//     protected void FlipEnemy()
//     {
//         if (player != null)
//         {
//             transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -1 : 1, 1, 1);
//         }

//     }

//     public virtual void takeDamage(float damage)
//     {
//         currentHP -= damage;
//         currentHP = Mathf.Max(currentHP, 0);
//         UpdateHP();
//         if (currentHP <= 0)
//         {
//             Die();
//         }

//     }

//     protected virtual void Die()
//     {
//         Destroy(gameObject);
//     }

//     protected void UpdateHP()
//     {
//         if (hpBar != null)
//         {
//             hpBar.fillAmount = currentHP / maxHP;
//         }
//     }
// }
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float enemyMoveSpeed = 1f;
    protected PlayerMovement player;

    [SerializeField] protected float maxHP = 50f;
    protected float currentHP;
    [SerializeField] private Image hpBar;
    [SerializeField] protected float EnterDamage = 10;
    [SerializeField] protected float stayDamage = 1f;

    
    protected Vector3 originalScale;

    protected virtual void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        currentHP = maxHP;
        UpdateHP();

 
        originalScale = transform.localScale;
    }

    protected virtual void Update()
    {
        MoveToPlayer();
    }

    protected void MoveToPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyMoveSpeed * Time.deltaTime);
            FlipEnemy();
        }
    }

    protected void FlipEnemy()
    {
        if (player != null)
        {
         
            float xScale = Mathf.Abs(originalScale.x);

       
            transform.localScale = new Vector3(player.transform.position.x < transform.position.x ? -xScale : xScale,
                                               originalScale.y,
                                               originalScale.z);
        }
    }

    public virtual void takeDamage(float damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Max(currentHP, 0);
        UpdateHP();
        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected void UpdateHP()
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = currentHP / maxHP;
        }
    }
}
