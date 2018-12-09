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
    StopMove
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

    private Rigidbody2D _rigidbody;

    public int Speed;

    public float FireRate;
    private float nextFire;

    void Start()
    {
        NextActions = new List<eAction>(4);
        for (int i = 0; i < 4; i++)
            NextActions.Add((eAction)Random.Range(1, 7));

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
            if(Time.time > nextFire)
            {
                nextFire = Time.time + FireRate;
                Action();
            }
        }
    }

    void Action()
    {
        Debug.Log(NextActions[0].ToString());
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
            StopMove();
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

        if (Random.Range(0, 100) < 15)
            NextActions.Add((eAction)1);
        else
            NextActions.Add((eAction)Random.Range(1, 7));
    }
}
