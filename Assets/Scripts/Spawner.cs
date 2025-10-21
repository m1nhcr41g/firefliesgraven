using UnityEngine;
using System.Collections;




public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnpoints;
    [SerializeField] private float SpawnTime = 2f;
    private bool canSpawn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCouroutine());
    }

    private IEnumerator SpawnCouroutine()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(SpawnTime);
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Transform spawnpoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
            Instantiate(enemy, spawnpoint.position, Quaternion.identity);
        }
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }

}
