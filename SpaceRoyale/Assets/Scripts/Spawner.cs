using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int NumberOfObjects;
    public GameObject[] ListOfObjects;

    void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        for(int i=0;i<NumberOfObjects;i++)
        {
            GameObject obj = ListOfObjects[Random.Range(0, ListOfObjects.Length - 1)];

            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width-200), Random.Range(0, Screen.height-200), Camera.main.farClipPlane / 2));
            Instantiate(obj, pos, Quaternion.identity);
        }
    }
}
