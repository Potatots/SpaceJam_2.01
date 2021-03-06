﻿using System.Collections.Generic;
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
    public Spawner Spawner;

    private Rigidbody2D _rigidbody;

    public int Speed;
    public int ChanceForEnemy;
    public int ChanceForTradeShip;

    public float FireRate;
    private float nextFire;
    private bool IsOkPos = true;
    private bool FireTriggerExit = false;

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
            else
            {
                FireTriggerExit = true;
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

        int enemyNumber = Random.Range(0, 100);
        int tradeNumber = Random.Range(0, 100);

        if (enemyNumber < ChanceForEnemy)
            Spawner.SpawnEnemy();
        if (tradeNumber < ChanceForTradeShip)
            Spawner.SpawnTradeShips();
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
        eAction oldAction = NextActions[3];
        NextActions.RemoveAt(0);

        int rndVal = Random.Range(0, 100);

        if (rndVal < 2)
            NextActions.Add((eAction)8);
        //if (rndVal < 10)
            //NextActions.Add((eAction)1);
        else
        {
            eAction newAction;

            do
            {
                newAction = (eAction)Random.Range(1, 7);

            } while (oldAction == newAction);

            NextActions.Add(newAction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Npc")
            IsOkPos = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsOkPos = true;

        if (collision.tag == "Npc" && FireTriggerExit)
        {
            StopMove();
            MoveActions();
            FireTriggerExit = false;
        }
    }
}
