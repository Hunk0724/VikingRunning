using UnityEngine;

public class createLand : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    public GameObject groundTileHole;
    GameObject temp;
    public void SpawnTile()
    {
        if (Random.Range(1, 4) == 3)
        {
            temp = Instantiate(groundTileHole, nextSpawnPoint, Quaternion.identity);
        }else
        {
            temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        }
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            SpawnTile();
        }
    }


}
