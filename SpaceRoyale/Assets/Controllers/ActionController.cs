using UnityEngine;

public enum eAction
{
    Empty,
    Shoot,
    StartMove,
    StopMove
}

public class ActionController : MonoBehaviour
{
    public eAction CurrentAction { get; set; }

    public Transform Rocket;
    public Transform Radar;

    private Rigidbody2D _rigidbody;

    public int Speed;

    void Start()
    {
        CurrentAction = eAction.Shoot;
        _rigidbody = GetComponent<Rigidbody2D>();
        Speed = 10;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Action();
        }
    }

    void Action()
    {
        if(CurrentAction == eAction.Shoot)
        {
            Instantiate(Rocket, transform.position, Radar.rotation);
        }
        else if(CurrentAction == eAction.StartMove)
        {
            StartMove(Radar.rotation);
            CurrentAction = eAction.StopMove;
        }
        else if(CurrentAction == eAction.StopMove)
        {
            StopMove();
            CurrentAction = eAction.StartMove;
        }
        else if(CurrentAction == eAction.Empty)
        {
            Debug.Log("Coś kurwa poszło nie tak, eAction.Empty");
        }
    }

    public void StartMove(Quaternion qtMove)
    {
        _rigidbody.velocity = Radar.transform.right * Speed;
    }
    public void StopMove()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
