using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public static int CountTankAlive = 0;
    public Wavee[] wavees;
    public Transform START;
    public float waveeRate = 0.2f;

     void Start()
    {
        StartCoroutine(KSpawnEnemy());
    }
    IEnumerator KSpawnEnemy()
    {
        foreach(Wavee wavee in wavees)
        {
            for(int i = 0; i < wavee.count; i++)
            {
                GameObject.Instantiate(wavee.tankPrefab, START.position, Quaternion.identity);
                CountTankAlive++;
                if(i!=wavee.count-1)
                  yield return new WaitForSeconds(wavee.rate);
            }
            yield return new WaitForSeconds(waveeRate);
        }
    }
}
