using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public int NumberOfNpcs;
    public int MinimumDistance;
    public int VerticalOffset;
    public int HorizontalOffset;
    public GameObject[] ListOfNpcs;
    public GameObject Enemy;
    public GameObject TradeShip;
    public List<Vector3> SpawnedNpcsVectors;
    public ReputationManager rp;
    public int ChanceForEnemy;
    public int ChanceForTradeShip;

    void Start()
    {
        SpawnNpcs(NumberOfNpcs);
        SpawnedNpcsVectors = new List<Vector3>();
        SpawnedNpcsVectors.Add(Vector3.zero);

        SpawnEnemy();
        SpawnTradeShips();
    }

    private void Update()
    {
        if(rp.reputation >= rp.maxReputation)
        {
            SpawnNpcs(1);
            rp.maxReputation = (int)(rp.maxReputation * 1.1f);
            SpawnTradeShips();
            SpawnEnemy();
        }
        else if(rp.reputation <=0)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    public void SpawnNpcs(int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject obj = ListOfNpcs[Random.Range(0, ListOfNpcs.Length - 1)];
            Vector3 newVector = Vector3.zero;
            int counter = 0;
            do
            {
                counter++;
                newVector = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(HorizontalOffset, Screen.width - HorizontalOffset), Random.Range(VerticalOffset, Screen.height - VerticalOffset), Camera.main.farClipPlane / 2));

                if (counter % 10 == 0 && MinimumDistance > 0)
                    MinimumDistance--;

            } while (!IsFarEnough(newVector));

            SpawnedNpcsVectors.Add(newVector);

            Instantiate(obj, newVector, Quaternion.identity);
        }
    }

    public void SpawnEnemy()
    {
        Vector3 newVector = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-HorizontalOffset, 0), Random.Range(-VerticalOffset, 0), Camera.main.farClipPlane / 2));

        Instantiate(Enemy, newVector, Quaternion.identity);
    }
    public void SpawnTradeShips()
    {
        Vector3 newVector = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(-HorizontalOffset, 0), Random.Range(-VerticalOffset, 0), Camera.main.farClipPlane / 2));

        Instantiate(TradeShip, newVector, Quaternion.identity);
    }

    private bool IsFarEnough(Vector3 v)
    {
        foreach (Vector3 vector in SpawnedNpcsVectors)
        {
            if (Vector3.Distance(vector, v) < MinimumDistance)
                return false;
        }
        return true;
    }
}
