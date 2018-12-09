using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionIndicator : MonoBehaviour {


    public ActionController actionController;

    public Sprite[] actionImages;

    public Image[] nextActions;


    // Use this for initialization
    void Start ()
    {
        actionController = GameObject.FindGameObjectWithTag("Player").GetComponent<ActionController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		for(int i = 0; i < nextActions.Length; i++)
        {
            nextActions[i].sprite = actionImages[(int)actionController.NextActions[i]];
        }
	}
}
