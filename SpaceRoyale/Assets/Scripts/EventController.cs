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
    public SpriteRenderer indicatorSprite;

    [Header("Events settings")]
    public int maximumSatisfaction;
    public int revolutionSatisfaction;
    public int minimumSatisfaction;
    public int delayFrames;


    [Header("Indicator settings")]
    public float maxIndicatorSize;

    [Header("Debug preview")]
    public int satisfaction;
    [SerializeField]
    EventType eventType;

    private int randomFrame;



    // Use this for initialization
    void Start ()
    {
        // satisfaction init
        randomFrame = Random.Range(-10, 10);
        satisfaction = Random.Range(revolutionSatisfaction, maximumSatisfaction);

        // sprite renderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = planetSprites[Random.Range(0, planetSprites.Length)];

        // indicatior setup
        indicatorSprite.transform.localPosition = new Vector3(-maxIndicatorSize / 2, 0, 0);

        // start with no event
        StopEvents();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if((Time.frameCount + randomFrame) % delayFrames == 0)
            satisfaction -= Random.Range(0, 2);

        UpdateIndicator();

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
        if(satisfaction > revolutionSatisfaction)
            StopEvents();
    }

    private void UpdateFestival()
    {
        if (satisfaction < maximumSatisfaction)
            StopEvents();
    }

    void UpdateNone()
    {

        if(satisfaction < revolutionSatisfaction)
        {
            StartRevolution();
        }

        if(revolutionSatisfaction > maximumSatisfaction)
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









    void UpdateIndicator()
    {
        float satisfactionRange = maximumSatisfaction - revolutionSatisfaction;
        float newScaleX = Mathf.Max(0,Mathf.Min(maxIndicatorSize,   (float) (maxIndicatorSize / (satisfactionRange) * satisfaction)   )); 
        indicatorSprite.gameObject.transform.localScale = new Vector3(newScaleX, 0.25f, 0.5f);
        float newGreen = satisfaction < satisfactionRange / 2 ? (2*satisfaction / satisfactionRange) : 1;
        float newRed = satisfaction > satisfactionRange / 2 ? 2 * (1 - satisfaction / satisfactionRange) : 1;
        indicatorSprite.color = new Color(newRed, newGreen, 0);

    }



}
