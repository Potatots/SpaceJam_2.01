using UnityEngine;

public class RocketController : MonoBehaviour {

    public float Speed;

	// Use this for initialization
	void Start () {
        Speed = 20;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
