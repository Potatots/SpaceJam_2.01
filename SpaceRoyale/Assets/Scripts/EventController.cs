using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {

    public enum EventType
    {
        None,
        Revolution,
        Festival
    };

    public Sprite[] planetSprites;

    public GameObject rocketPrefab;
    public GameObject revoltBubblePrefab;

    [SerializeField]
    EventType eventType;

    [SerializeField]
    int delayFrames;

    [SerializeField]
    [Range(0,1)]
    float revolutionProbability;


    // Use this for initialization
	void Start ()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = planetSprites[Random.Range(0, planetSprites.Length)];
        StartRevolution();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(eventType == EventType.None)
        {
            UpdateNone();
        }
        else
        {

        }
    }

    void UpdateNone()
    {
        if (Time.frameCount % delayFrames == 0)
        {
            float ran = Random.Range(0f, 1f);
            if (ran < revolutionProbability)
            {
                StartRevolution();
            }
        }
    }


 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.otherCollider.CompareTag("Rocket"))
        {
            StopEvents();
        }
    }

    void StartRevolution()
    {
        eventType = EventType.Revolution;
        GetComponent<ParticleSystem>().enableEmission = true;
        GameObject bubble = Instantiate(revoltBubblePrefab);
        bubble.transform.parent = transform;
        bubble.transform.localPosition = new Vector3(0, 0, 0);
    }

    void StopEvents()
    {
        eventType = EventType.None;
        GetComponent<ParticleSystem>().enableEmission = false;
    }


}
