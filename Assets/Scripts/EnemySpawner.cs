using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesPrefab = null;
    [SerializeField] private float minSpawnCooldown = 10f;
    [SerializeField] private float maxSpawnCooldown = 50f;

    private float currentSpawnCooldown;
    private bool canSpawn = true;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentSpawnCooldown = Random.Range(minSpawnCooldown, maxSpawnCooldown);
    }

    private void Update()
    {
        if (player.GetIsGameOver() || !canSpawn) { return; }

        SpawnEnemy();
    }

    private void SpawnEnemy()
    { 
        Instantiate(enemiesPrefab[Random.Range(0, enemiesPrefab.Length)], transform);
        canSpawn = false;
        StartCoroutine(SpawnCooldown());
    }

    public void ResetSpawner()
    {
        canSpawn = true;
        currentSpawnCooldown = Random.Range(minSpawnCooldown, maxSpawnCooldown);
    }

    private IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(currentSpawnCooldown);
        canSpawn = true;
        currentSpawnCooldown = Random.Range(minSpawnCooldown, maxSpawnCooldown);
    }
}
