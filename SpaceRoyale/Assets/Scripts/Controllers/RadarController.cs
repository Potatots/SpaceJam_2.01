using UnityEngine;

public class RadarController : MonoBehaviour
{
    public float Speed;

    public float Angle
    {
        get
        {
            return _angle;
        }
        set
        {
            _angle = value % 360;
        }
    }
    private float _angle;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Angle));
        Angle -= Speed;
    }
}
