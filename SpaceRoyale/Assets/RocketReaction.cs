using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketReaction : MonoBehaviour {

    public GameObject rocketPrefab;

    public CapsuleCollider2D collider;

	// Use this for initialization
	void Start ()
    {
        collider = GetComponent<CapsuleCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
