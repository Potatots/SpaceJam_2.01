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

    public ReputationManager reputationManager;

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

    [Header("Size settings")]
    public float minScale;
    public float maxScale;

    [Header("Indicator settings")]
    public float maxIndicatorSize;

    [Header("Particle settings")]
    public Color festivalColor;
    public Color revolutionColor;

    [Header("Debug preview")]
    public int satisfaction;
    [SerializeField]
    EventType eventType;
 

    private int randomFrame;



    // Use this for initialization
    void Start ()
    {


        // reputation manager init
        reputationManager = GameObject.FindGameObjectWithTag("UI").GetComponent<ReputationManager>();
        reputationManager.planetControllers.Add(this);
        reputationManager.maxReputation += maximumSatisfaction;

        // satisfaction init
        randomFrame = Random.Range(-10, 10);
        satisfaction = Random.Range(revolutionSatisfaction, maximumSatisfaction);

        // sprite renderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = planetSprites[Random.Range(0, planetSprites.Length)];

        // indicatior setup
        indicatorSprite.transform.localPosition = new Vector3(-maxIndicatorSize / 2, indicatorSprite.transform.localPosition.y, 0);

        // start with no event
        StopEvents();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((Time.frameCount + randomFrame) % delayFrames == 0)
            satisfaction -= Mathf.Max(Random.Range(0, 2), minimumSatisfaction);

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
        /*
        if ((Time.frameCount + randomFrame) % delayFrames == 0)
            reputationManager.reputation += (satisfaction - revolutionSatisfaction);
        */

        if(satisfaction > revolutionSatisfaction)
            StopEvents();
    }

    private void UpdateFestival()
    {
        /*
        if ((Time.frameCount + randomFrame) % delayFrames == 0)
            reputationManager.reputation += (satisfaction - maximumSatisfaction);
        */

        if (satisfaction < maximumSatisfaction)
            StopEvents();
    }

    void UpdateNone()
    {

        if(satisfaction < revolutionSatisfaction)
        {
            StartRevolution();
        }

        if(satisfaction > maximumSatisfaction)
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


 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Rocket"))
        {
            satisfaction = Random.Range( (maximumSatisfaction - revolutionSatisfaction) / 3, (maximumSatisfaction - revolutionSatisfaction) / 2) ;
            //Debug.Log("Zderzenie z rakietą");
            /*
            if (eventType == EventType.Revolution)
            {
                satisfaction += (maximumSatisfaction - revolutionSatisfaction) / 2;
            }
            else
            {
                satisfaction -= (maximumSatisfaction - revolutionSatisfaction) / 3;
            }
            */
        }
        else if (other.CompareTag("Rocket_Cash"))
        {
            //Debug.Log("Zderzenie z pieniedzmi");
            satisfaction += ConfigurationScript.moneySatisfactionValue;
        }
        else if (other.CompareTag("Rocket_Heart"))
        {
            //Debug.Log("Zderzenie z serduszkiem");
            satisfaction += ConfigurationScript.heartSatisfactionValue;
        }
        else if (other.CompareTag("Rocket_Peace"))
        {
            //Debug.Log("Zderzenie z pacyfką");
            satisfaction += ConfigurationScript.peaceSatisfactionValue;
        }
        else if(other.CompareTag("Rocket_Rainbow"))
        {
            //Debug.Log("Zderzenie z tęczą");
            satisfaction += ConfigurationScript.rainbowSatisfactionValue;
        }

    }

    void StartRevolution()
    {
        eventType = EventType.Revolution;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.enableEmission = true;
        ps.startColor = revolutionColor;
        GameObject bubble = Instantiate(revoltBubblePrefab);
        bubble.transform.parent = transform;
        bubble.transform.localPosition = new Vector3(0, 0, 0);
    }

    void StartFestival()
    {
        eventType = EventType.Festival;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.enableEmission = true;
        ps.startColor = festivalColor;
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
