using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyToSpawn;

    public float timeToSpawn;
    private float spawnCounter;
    public int checkPerFrame;
    private int EnemyToCheck;

    public Transform minSpawn, maxSpawn;
    private Transform target;
    private float dspawnDistance;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeToSpawn;
        target = PlayerHealthController.instance.transform;
        dspawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0 )
        {
            spawnCounter = timeToSpawn;

            GameObject newEnemy = Instantiate(enemyToSpawn, SelectSpawnPoint() , transform.rotation);
            spawnedEnemies.Add(newEnemy);
        }

        transform.position = target.position;

        int checkTarget = EnemyToCheck + checkPerFrame;

        while(EnemyToCheck < checkTarget)
        {
            if(EnemyToCheck < spawnedEnemies.Count )
            {
                if (spawnedEnemies[EnemyToCheck] != null)
                {
                    if(Vector3.Distance(transform.position, spawnedEnemies[EnemyToCheck].transform.position) > dspawnDistance)
                    {
                        Destroy(spawnedEnemies[EnemyToCheck]);
                        spawnedEnemies.RemoveAt(EnemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        EnemyToCheck++;
                    }
                } else
                {
                    spawnedEnemies.RemoveAt(EnemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                EnemyToCheck = 0;
                checkTarget = 0;
            }
        }

    }

    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = Vector3.zero;

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = minSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = minSpawn.position.y;
            }
        }



        return spawnPoint;
    }
}
