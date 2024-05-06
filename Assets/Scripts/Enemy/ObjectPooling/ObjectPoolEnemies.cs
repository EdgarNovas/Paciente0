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
    [SerializeField] float maxTime = .5f;
    float currentTime = 0;
    [SerializeField] List<Transform> allSpawners = new List<Transform>();
    [SerializeField] Transform poolTransform;
    [SerializeField] List<GameObject> unactiveEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        for (int i = 0; i < enemiesInPool; i++) { 
            //TODO IN A FUTURE
            //Appear In pool


            //Instantiate
            //Set active false


            //spawnTotransforms

            int numEnemyType = Random.Range(0, typesOfZombies.Count);
            enemyPool.Add(typesOfZombies[numEnemyType]);
            int spawnerType = Random.Range(0, allSpawners.Count);
            Instantiate(enemyPool[i], allSpawners[spawnerType].position,Quaternion.identity,poolTransform);
            enemyPool[i].SetActive(false);
        }

        for (int i = 0; i < maxEnemiesAlive; i++)
        {
            poolTransform.GetChild(i).gameObject.SetActive(true);
            enemiesAlive++;
        }

        for (int i = 0; i < enemiesInPool; i++)
        {
            if (enemyPool[i].activeSelf == false)
            {
                unactiveEnemies.Add(enemyPool[i]);
            }
            
        }


    }

    
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f)
        {
            for (int i = 0; i< poolTransform.childCount; i++)
            {
                if (!poolTransform.GetChild(i).gameObject.activeSelf)
                {
                    ReactivateEnemy(i);
                }
            }
        }

        /*
        if(enemiesAlive < maxEnemiesAlive)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0f)
            {
                for(int i = 0; i < poolTransform.childCount; i++)
                {
                    unactiveEnemies.Remove(unactiveEnemies[0]);
                    currentTime = maxTime;
                    
                    Debug.Log("TRUEEE");
                                      
                }         
            }   
        }
        */
    }

    private void ReactivateEnemy(int i)
    {
        ResetEnemies(i);
        //ChoosseSpawn
        int spawnerType = Random.Range(0, allSpawners.Count);
        poolTransform.GetChild(i).transform.position = allSpawners[spawnerType].position;
        currentTime = maxTime;
        poolTransform.GetChild(i).gameObject.SetActive(true);
    }

    void ResetEnemies(int i)
    {
        poolTransform.GetChild(i).GetComponent<ZombiesHP>().ResetHPZombie();
    }
}
