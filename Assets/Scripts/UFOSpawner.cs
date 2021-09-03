using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSpawner : MonoBehaviour
{
    public GameObject[] ufoPrefab;
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
            var UFOArr = GameObject.FindGameObjectsWithTag("UFO");
            foreach (GameObject go in UFOArr)
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

            Instantiate(ufoPrefab[Random.Range(0, ufoPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
        }
    }
}
