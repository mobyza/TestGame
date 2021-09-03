using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{ 
    public GameObject[] asteroidsPrefab;
    public Transform[] spawnPoints;
    [SerializeField]
    private float minDelay;
    [SerializeField]
    private float maxDelay;
    public GameManager gm;
    


    private void Start()
    {
        StartCoroutine(spawnObjects());
    }

    private void Update()
    {
        if (!gm.CanPlay)
        {
            var AsteroidsArr = GameObject.FindGameObjectsWithTag("Asteroid");
            foreach (GameObject go in AsteroidsArr)
            {
                Destroy(go);
            }

        }
    }

    IEnumerator spawnObjects()
    {
        while (true && gm.CanPlay)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            Instantiate(asteroidsPrefab[Random.Range(0, asteroidsPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
        }
    }
}
