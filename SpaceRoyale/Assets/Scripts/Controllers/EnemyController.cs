using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject[] AllNpcs;
    Transform SelectedNpc;

    public float RotationSpeed;
    public float MovementSpeed;

    // Use this for initialization
    void Start()
    {
        AllNpcs = GameObject.FindGameObjectsWithTag("Npc");

        SelectedNpc = AllNpcs[Random.Range(0, AllNpcs.Length)].transform;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelectedNpc = AllNpcs[Random.Range(0, AllNpcs.Length)].transform;
    }
}
