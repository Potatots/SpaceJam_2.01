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



    // Use this for initialization
    void Awake()
    {
        revolutionCount = 0;
        festivalCount = 0;
        reputation = initialReputation;
    }
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        reputationBar.fillAmount = (float)reputation / (float)maxReputation;
	}
}
