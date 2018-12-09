using System.Collections.Generic;
using UnityEngine;

public class NukeController : MonoBehaviour
{
    public ParticleSystem ps;

    public int MovementSpeed;
    bool WasEnabled = false;
    void Start()
    {
    }

    private void Update()
    {
        MoveToCenter();

        if (transform.position.x == 0 && transform.position.y == 0 && !WasEnabled)
        {
            Debug.Log("Dupa");

            ps = GetComponentInChildren<ParticleSystem>();
            ps.enableEmission = true;

            List<GameObject> AllShips = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
            AllShips.ForEach(ship => Destroy(ship));

            WasEnabled = true;

            //Destroy(gameObject,5);
        }
    }

    private void MoveToCenter()
    {
        Vector2 direction = Vector3.zero - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);

        transform.rotation = rotation;

        transform.position = Vector2.MoveTowards(transform.position, Vector3.zero, MovementSpeed * Time.deltaTime);
    }
}
