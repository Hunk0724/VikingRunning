using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    createLand groundSpawner;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<createLand>();
        SpawnObstacle();
        SpawnCoins();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 5);
    }

    
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;

    void SpawnObstacle()
    {
        //int obstacleSpawnIndex = Random.Range(2, 4);
        Transform spawnPoint = transform.GetChild(3).transform;

        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinsToSpawn = 12;

        for(int i = 0; i < coinsToSpawn; i++)
        {
            GameObject  temp = Instantiate(coinPrefab,transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x,collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if(point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
