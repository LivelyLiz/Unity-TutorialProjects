using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public Vector3 SpawnValue;
    public float SpawnWait;
    public float StarWait;
    public float WaveWait;
    public int HazardCount;
    public GameObject Hazard;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StarWait);

        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnValue.x, SpawnValue.x), SpawnValue.y, SpawnValue.z + Random.Range(i, 10));
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(Hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(SpawnWait);
            }

            yield return new WaitForSeconds(WaveWait);
        }   
    }
}
