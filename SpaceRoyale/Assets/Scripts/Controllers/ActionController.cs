using System.Collections.Generic;
using UnityEngine;

public enum eAction
{
    Empty,
    Shoot,
    Money,
    Peace,
    Heart,
    Rainbow,
    StartMove,
    StopMove,
    Nuke
}

public class ActionController : MonoBehaviour
{
    public List<eAction> NextActions;

    public Transform Rocket;
    public Transform Money;
    public Transform Peace;
    public Transform Heart;
    public Transform Rainbow;
    public Transform Radar;
    public Transform Nuke;

    private Rigidbody2D _rigidbody;

    public int Speed;

    public float FireRate;
    private float nextFire;
    private bool IsOkPos = true;

    void Start()
    {
        NextActions = new List<eAction>(4);
        for (int i = 0; i < 4; i++)
            NextActions.Add((eAction)6);

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((NextActions[0] == eAction.StartMove || NextActions[0] == eAction.StopMove) && Input.GetKeyDown(KeyCode.Space))
        {
            Action();
        }
        else if ((NextActions[0] != eAction.StopMove && NextActions[0] != eAction.StartMove) && Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + FireRate;
                Action();
            }
        }
    }

    void Action()
    {
        if (NextActions[0] == eAction.Shoot)
        {
            Instantiate(Rocket, transform.position, Radar.rotation);
            MoveActions();
        }
        else if (NextActions[0] == eAction.Heart)
        {
            Instantiate(Heart, transform.position, Radar.rotation);
            MoveActions();
        }
        else if (NextActions[0] == eAction.Money)
        {
            Instantiate(Money, transform.position, Radar.rotation);
            MoveActions();
        }
        else if (NextActions[0] == eAction.Peace)
        {
            Instantiate(Peace, transform.position, Radar.rotation);
            MoveActions();
        }
        else if (NextActions[0] == eAction.Rainbow)
        {
            Instantiate(Rainbow, transform.position, Radar.rotation);
            MoveActions();
        }
        else if (NextActions[0] == eAction.StartMove)
        {
            StartMove(Radar.rotation);
            NextActions[0] = eAction.StopMove;
        }
        else if (NextActions[0] == eAction.StopMove)
        {
            if (IsOkPos)
            {
                StopMove();
                MoveActions();
            }
        }
        else if (NextActions[0] == eAction.Nuke)
        {
            Instantiate(Nuke, transform.position, Quaternion.FromToRotation(transform.position, Vector3.zero));
            MoveActions();
        }
        else if (NextActions[0] == eAction.Empty)
        {
            Debug.Log("Coś kurwa poszło nie tak, eAction.Empty");
        }
    }

    public void StartMove(Quaternion qtMove)
    {
        _rigidbody.velocity = Radar.transform.up * Speed;
    }
    public void StopMove()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void MoveActions()
    {
        NextActions.RemoveAt(0);

        int rndVal = Random.Range(0, 100);

        if (rndVal < 2)
            NextActions.Add((eAction)8);
        if (rndVal < 15)
            NextActions.Add((eAction)1);
        else
            NextActions.Add((eAction)Random.Range(1, 7));
    }
    private bool IsCorrectPosition()
    {
        List<GameObject> AllNpcs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Npc"));

        foreach (GameObject npc in AllNpcs)
        {
            Debug.Log(Vector3.Distance(npc.transform.position, transform.position));
            if (Vector3.Distance(npc.transform.position, transform.position) < 490.008)
                return false;
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Dupa wejście");

        if (collision.tag == "Npc")
            IsOkPos = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Dupa wyjście");
        IsOkPos = true;
    }
}
