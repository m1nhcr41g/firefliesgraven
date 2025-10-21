using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private Transform firepos;
    [SerializeField] private float bullet_speed;
    [SerializeField] private float bullet_speed_2;
    [SerializeField] private float hpAmount;
    [SerializeField] GameObject miniEnemy;
    [SerializeField] GameObject bossItem;
    [SerializeField] private float skillCooldown;
    [SerializeField] private AudioManager audioManager;
    private float nextSkill;

    protected override void Update()
    {
        base.Update();
        if (Time.time >= nextSkill)
        {
            using_skill();
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //     {
        //         // normal_skill();
        //         // heal(hpAmount);
        //         spawn_mini();
        //     }

        //     if (Input.GetKeyDown(KeyCode.P))
        //     {
        //         circle_bullet();
        //     }
    }



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

    private void normal_skill()
    {
        if (player != null)
        {
            Vector3 direction_to_player = player.transform.position - firepos.position;
            direction_to_player.Normalize();
            GameObject bullet = Instantiate(bulletPrefabs, firepos.position, Quaternion.identity);
            BossBullet bossBullet = bullet.AddComponent<BossBullet>();
            bossBullet.SetMovementDirection(direction_to_player * bullet_speed_2);
        }
    }

    private void circle_bullet()
    {
        const int bulletCount = 20;
        float angleStep = 360f / bulletCount;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            Vector3 bulletDirection = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            BossBullet bossBullet = bullet.AddComponent<BossBullet>();
            bossBullet.SetMovementDirection(bulletDirection * bullet_speed);
        }
    }

    private void heal(float hpAmount)
    {
        currentHP = Mathf.Min(currentHP + hpAmount, maxHP);
        UpdateHP();
    }

    private void spawn_mini()
    {
        Instantiate(miniEnemy, transform.position, Quaternion.identity);

    }

    private void random_skill()
    {
        int randomSkill = Random.Range(0, 100);
        if (randomSkill < 50)
        {
            audioManager.playLaserSound();
            normal_skill();
        }
        else if (randomSkill < 80)
        {
            audioManager.playLaserSound();
            circle_bullet();
        }
        else if (randomSkill < 95) heal(hpAmount);
        else
        {
            audioManager.playMiniBossSound();
            spawn_mini(); 
        }   
    }

    private void using_skill()
    {
        nextSkill = Time.time + skillCooldown;
        random_skill();
    }

    protected override void Die()
    {
        base.Die();
        Instantiate(bossItem, transform.position, Quaternion.identity);
    }

}
