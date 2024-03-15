using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemies : MonoBehaviour
{
    [SerializeField]List<GameObject> typesOfZombies = new List<GameObject>();
    [SerializeField]List<GameObject> enemyPool = new List<GameObject>();
    [SerializeField] int enemiesInPool = 50;
    [SerializeField] int enemiesAlive = 0;
    [SerializeField] int maxEnemiesAlive = 0;
    [SerializeField] List<Transform> allSpawners = new List<Transform>();
    [SerializeField] Transform poolTransform;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemiesInPool; i++) { 
            int numEnemyType = Random.Range(0, typesOfZombies.Count);
            enemyPool.Add(typesOfZombies[numEnemyType]);
            int spawnerType = Random.Range(0, allSpawners.Count);
            Instantiate(enemyPool[i], allSpawners[spawnerType].position,Quaternion.identity,poolTransform);
            enemyPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive < maxEnemiesAlive)
        {
            Debug.Log("AM INSIDE");
            for (int i = 0; i < maxEnemiesAlive; i++)
            {
                poolTransform.GetChild(i).gameObject.SetActive(true);
                enemiesAlive++;
            }
        }
    }
}
