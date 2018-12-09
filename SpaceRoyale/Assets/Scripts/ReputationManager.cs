using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReputationManager : MonoBehaviour {

    public int reputation;
    public int maxReputation;

    public int revolutionCount;
    public int festivalCount;

    // Use this for initialization
    void Awake()
    {
        maxReputation = 10000;
        revolutionCount = 0;
        festivalCount = 0;
        reputation = 5000;
    }
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}
}
