using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    List<GameObject> AllNpcs;
    Transform SelectedNpc;

    public float RotationSpeed;
    public float MovementSpeed;
    public float WaitTime;

    // Use this for initialization
    void Start()
    {
        AllNpcs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Npc").OrderByDescending(go => go.GetComponent<EventController>().satisfaction));

        SelectedNpc = AllNpcs[0].transform;
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

        AllNpcs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Npc").OrderByDescending(go => go.GetComponent<EventController>().satisfaction));

        if (SelectedNpc.position == AllNpcs[0].transform.position)
            SelectedNpc = AllNpcs[1].transform;
        else
            SelectedNpc = AllNpcs[0].transform;
    }


    public void DestroyWithFade()
    {

    }


}
