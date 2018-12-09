using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int NumberOfObjects;
    public GameObject[] ListOfObjects;
    public List<Vector3> SpawnedVectors;
    public int MinimumDistance;
    public int ScreenOffset;

    void Start()
    {
        SpawnEnemies();
        SpawnedVectors = new List<Vector3>();
        SpawnedVectors.Add(Vector3.zero);
    }

    public void SpawnEnemies()
    {
        for(int i=0;i<NumberOfObjects;i++)
        {
            GameObject obj = ListOfObjects[Random.Range(0, ListOfObjects.Length - 1)];
            Vector3 newVector = Vector3.zero;
            do
            {
                newVector = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(ScreenOffset, Screen.width - ScreenOffset), Random.Range(ScreenOffset, Screen.height - ScreenOffset), Camera.main.farClipPlane / 2));
            } while (!IsFarEnough(newVector));

            Debug.Log(Screen.width);
            Debug.Log(Screen.height);

            SpawnedVectors.Add(newVector);

            Instantiate(obj, newVector, Quaternion.identity);
        }
    }

    private bool IsFarEnough(Vector3 v)
    {
        foreach(Vector3 vector in SpawnedVectors)
        {
            if (Vector3.Distance(vector, v) < MinimumDistance)
                return false;
        }
        return true;
    }
}
