using UnityEngine;
using System.Collections;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotDelay = 0.1f;
    private float nextShot;
    [SerializeField] private TextMeshProUGUI ammoText;



    [SerializeField] private int maxAmmo = 30;
    [SerializeField] private float reloadTime = 2f;
    [SerializeField] private AudioManager audioManager;
    public int currentAmmo;
    private bool isReloading = false;


    private Vector3 initialLocalPos;
    private Vector3 initialScale;
    private float rotateOffset = 180f;

    void Start()
    {

        initialLocalPos = transform.localPosition;
        initialScale = transform.localScale;
        currentAmmo = maxAmmo;
        UpdateAmmo();
    }

    void Update()
    {
        if (isReloading) return;

        RotateGun();
        Shoot();

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }

        if (currentAmmo == 0)
        {
            StartCoroutine(Reload());
        }

    }

    void RotateGun()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 displacement = transform.position - mouseWorld;
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle + rotateOffset);

        // Kiểm tra chuột bên trái hay bên phải Player
        if (mouseWorld.x < player.position.x) // chuột bên trái
        {
            // Lật position (qua trục Y) 
            transform.localPosition = new Vector3(-initialLocalPos.x, initialLocalPos.y, initialLocalPos.z);

            // Lật scale theo trục Y
            transform.localScale = new Vector3(initialScale.x, -initialScale.y, initialScale.z);
        }
        else // chuột bên phải
        {
            transform.localPosition = initialLocalPos;
            transform.localScale = initialScale;
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && currentAmmo > 0 && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            currentAmmo--;
            UpdateAmmo();
            audioManager.playShootSound();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        audioManager.playReloadSound();
        Debug.Log("Reloading...");
        if (ammoText != null) ammoText.text = "Reloading";
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("Reloaded!");
        UpdateAmmo();
        
    }

    private void UpdateAmmo()
    {
        if (ammoText != null)
        {
            if (currentAmmo > 0)
            {
                ammoText.text = currentAmmo.ToString()+"/"+ maxAmmo.ToString();
            }
            else
            {
                ammoText.text = "Out of Ammo";
            }
        }
    }
}
