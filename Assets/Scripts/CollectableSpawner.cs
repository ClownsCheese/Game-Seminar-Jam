using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    float min;
    float max;

    public GameObject collectablePrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMarman", 3f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnMarman()
    {
        float y = Random.Range(-3.6f, 0f);
        Vector3 spawnPos = new Vector3(transform.position.x, y, transform.position.z);
        Instantiate(collectablePrefab, spawnPos, Quaternion.identity);
    }
}
