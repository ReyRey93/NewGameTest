using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Spawner_Script : MonoBehaviour
{
    [SerializeField] private GameObject[] collectiblePrefabs;
    public float collectibleSpawnTime = 2f;
    public float collectibleSpeed = 1f;

    private float timeUntilCollectibleSpawn;

    private void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilCollectibleSpawn += Time.deltaTime;

        if (timeUntilCollectibleSpawn >= collectibleSpawnTime)
        {
            Spawn();
            timeUntilCollectibleSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject collectibleToSpawn = collectiblePrefabs[Random.Range(0, collectiblePrefabs.Length)];

        GameObject spawnedCollectible = Instantiate(collectibleToSpawn, transform.position, Quaternion.identity);

        Rigidbody2D collectibleRB = spawnedCollectible.GetComponent<Rigidbody2D>();
        collectibleRB.linearVelocity = Vector2.left * collectibleSpeed;
    }
}
