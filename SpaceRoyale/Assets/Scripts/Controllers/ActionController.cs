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
    public eAction CurrentAction { get; set; }
    public eAction NextAction { get; set; }

    public Transform Rocket;
    public Transform Money;
    public Transform Peace;
    public Transform Heart;
    public Transform Rainbow;
    public Transform Radar;

    private Rigidbody2D _rigidbody;

    public int Speed;

    void Start()
    {
        CurrentAction = (eAction)Random.Range(1, 7);
        NextAction = (eAction)Random.Range(1, 7);
        _rigidbody = GetComponent<Rigidbody2D>();
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
            CurrentAction = NextAction;
            NextAction = (eAction)Random.Range(1, 7);
        }
        else if(CurrentAction == eAction.Heart)
        {
            Instantiate(Heart, transform.position, Radar.rotation);
            CurrentAction = NextAction;
            NextAction = (eAction)Random.Range(1, 7);
        }
        else if(CurrentAction == eAction.Money)
        {
            Instantiate(Money, transform.position, Radar.rotation);
            CurrentAction = NextAction;
            NextAction = (eAction)Random.Range(1, 7);
        }
        else if(CurrentAction == eAction.Peace)
        {
            Instantiate(Peace, transform.position, Radar.rotation);
            CurrentAction = NextAction;
            NextAction = (eAction)Random.Range(1, 7);
        }
        else if(CurrentAction == eAction.Rainbow)
        {
            Instantiate(Rainbow, transform.position, Radar.rotation);
            CurrentAction = NextAction;
            NextAction = (eAction)Random.Range(1, 7);
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

            CurrentAction = NextAction;
            NextAction = (eAction)Random.Range(1, 7);
        }
        else if(CurrentAction == eAction.Empty)
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
}
