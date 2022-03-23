using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroids;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAsteroid()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(0, 7), transform.position.z);
        Instantiate(asteroids[Random.Range(0, asteroids.Length)], transform.position, transform.rotation);
        return;
    }
}
