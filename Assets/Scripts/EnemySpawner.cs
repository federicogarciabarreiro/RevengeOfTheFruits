using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRadius = 10f;

    public void SpawnEnemies(float t)
    {
        Invoke("InitSpawnEnemies", t);
    }

    private void InitSpawnEnemies()
    {
        StartCoroutine(SpawnEnemies());
    }

    int count = 0;
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            for (int i = 0; i < (int)(GameManager.instance.difficulty/2); i++)
            {
                Vector3 randomPos = player.position + Random.insideUnitSphere * spawnRadius;
                randomPos.y = player.position.y;
                Instantiate(enemyPrefab, randomPos, Quaternion.identity);
                count++;

                if (count == 100)
                {
                    StopAllCoroutines();
                    break;
                }
            }
            yield return new WaitForSeconds(GameManager.instance.increaseDifficultyInterval);
        }
    }
}
