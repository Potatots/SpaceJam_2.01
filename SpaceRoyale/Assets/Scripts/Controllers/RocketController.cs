using UnityEngine;

public class RocketController : MonoBehaviour {

    public float Speed;

    public int minX = -55;
    public int maxX = 55;
    public int minY = -34;
    public int maxY = 34;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
        if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
            Destroy(gameObject);
    }
}
