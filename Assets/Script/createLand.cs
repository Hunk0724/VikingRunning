using UnityEngine;

public class createLand : MonoBehaviour
{
    //public GameObject groundTile;
    Vector3 nextSpawnPoint;
    //public GameObject groundTileHole;
    GameObject temp;
    public GameObject [] lands;

    float angle;
    public void SpawnTile()
    {
       
        switch (Random.Range(-1, lands.Length))
        {
            case 0:
                temp = Instantiate(lands[0], nextSpawnPoint, Quaternion.identity);
                nextSpawnPoint = temp.transform.GetChild(2).transform.position;
                break;
            case 1:
                temp = Instantiate(lands[1], nextSpawnPoint, Quaternion.identity);
                nextSpawnPoint = temp.transform.GetChild(2).transform.position;
                break;
            case 2:
                temp = Instantiate(lands[2], nextSpawnPoint, Quaternion.identity);
                nextSpawnPoint = temp.transform.GetChild(2).transform.position;
                break;
            case 3:
                temp = Instantiate(lands[3], nextSpawnPoint, Quaternion.identity);
                nextSpawnPoint = temp.transform.GetChild(2).transform.position;
                break;
        }
    }
    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            if (i < 2)
            {
                temp = Instantiate(lands[1], nextSpawnPoint, Quaternion.identity);
                nextSpawnPoint = temp.transform.GetChild(2).transform.position;
            }
            SpawnTile();
            if (i > 3)
            {
                temp = Instantiate(lands[1], nextSpawnPoint, Quaternion.identity);
                nextSpawnPoint = temp.transform.GetChild(2).transform.position;
            }
        }
    }


}
