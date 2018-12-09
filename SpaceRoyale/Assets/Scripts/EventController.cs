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

    [Header("Prefabs to link")]
    public Sprite[] planetSprites;
    public GameObject revoltBubblePrefab;
    public GameObject festivalBubblePrefab;

    [Header("Events settings")]
    public int maximumSatifaction;
    public int revolutionSatisfaction;
    public int minimumSatisfaction;
    public int delayFrames;

    [Header("Debug preview")]
    public int satisfaction;
    [SerializeField]
    EventType eventType;

    private int randomFrame;



    // Use this for initialization
    void Start ()
    {
        randomFrame = Random.Range(-10, 10);
        satisfaction = Random.Range(revolutionSatisfaction, maximumSatifaction);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = planetSprites[Random.Range(0, planetSprites.Length)];
        StartRevolution();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if((Time.frameCount + randomFrame) % delayFrames == 0)
            satisfaction -= Random.Range(0, 2);

        if(eventType == EventType.Revolution)
        {
            UpdateRevolution();
        }
        else if(eventType == EventType.Festival)
        {
            UpdateFestival();
        }
        else
        {
            UpdateNone();
        }
    }

    private void UpdateRevolution()
    {
        ;
    }

    private void UpdateFestival()
    {
        ;
    }

    void UpdateNone()
    {

        if(satisfaction < revolutionSatisfaction)
        {
            StartRevolution();
        }

        if(revolutionSatisfaction > maximumSatifaction)
        {
            StartFestival();
        }
        /*
        if ((Time.frameCount + randomFrame) % delayFrames == 0)
        {
            float ran = Random.Range(0f, 1f);
            if (ran < revolutionProbability)
            {
               
            }
        }
        */
    }


 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(true)
        {
            if (eventType == EventType.Revolution)
            {

            }
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

    void StartFestival()
    {
        eventType = EventType.Revolution;
        GetComponent<ParticleSystem>().enableEmission = true;
        GameObject bubble = Instantiate(festivalBubblePrefab);
        bubble.transform.parent = transform;
        bubble.transform.localPosition = new Vector3(0, 0, 0);
    }

    void StopEvents()
    {
        eventType = EventType.None;
        GetComponent<ParticleSystem>().enableEmission = false;
    }


}
