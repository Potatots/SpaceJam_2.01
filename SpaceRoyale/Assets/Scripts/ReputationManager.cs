using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputationManager : MonoBehaviour
{
    [Header("UI objects to link")]
    public Image reputationBar;



    [Header("Events counts")]
    public int revolutionCount;
    public int festivalCount;

    [Header("Reputation")]
    public int reputation;

    [Header("Reputation settings")]
    public int maxReputation;
    public int initialReputation;

    public List<EventController> planetControllers;
    public GameObject[] planets;


    // Use this for initialization
    void Awake()
    {
        revolutionCount = 0;
        festivalCount = 0;
        reputation = initialReputation;
    }
    void Start()
    {
        /*
        //maxReputation = 0;
        GameObject[]planets = GameObject.FindGameObjectsWithTag("Npc");
        Debug.Log("Szukam planet!");
        planetControllers = new EventController[planets.Length];
        for(int i = 0; i < planets.Length; i++)
        {
            planetControllers[i] = planets[i].GetComponent<EventController>();
            //maxReputation += planetControllers[i].maximumSatisfaction;
        }
        */


    }
	// Update is called once per frame
	void Update ()
    {
        reputation = 0;
        foreach(EventController controller in planetControllers)
        {
            reputation += controller.satisfaction;
        }

        reputationBar.fillAmount = (float)reputation / (float)maxReputation;
	}
}
