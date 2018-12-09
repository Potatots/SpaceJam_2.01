using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TradeShipController : MonoBehaviour
{
    List<GameObject> AllNpcs;
    Transform SelectedNpc;

    public float RotationSpeed;
    public float MovementSpeed;
    public float WaitTime;

    // Use this for initialization
    void Start()
    {
        AllNpcs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Npc"));

        SelectedNpc = AllNpcs[Random.Range(0, AllNpcs.Count - 1)].transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNpc();
    }

    private void MoveToNpc()
    {
        Vector2 direction = SelectedNpc.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        rotation = Quaternion.Slerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);

        transform.rotation = rotation;

        transform.position = Vector2.MoveTowards(transform.position, SelectedNpc.position, MovementSpeed * Time.deltaTime);
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        
        yield return new WaitForSeconds(WaitTime);
        soundHandler.Engine();
        Transform newNpc;

        do
        {
            newNpc = AllNpcs[Random.Range(0, AllNpcs.Count - 1)].transform;

        } while (SelectedNpc.position == newNpc.position);

        SelectedNpc = newNpc;
    }
}
