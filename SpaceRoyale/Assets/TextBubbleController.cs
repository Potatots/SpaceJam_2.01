using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBubbleController : MonoBehaviour {

    public Sprite[] bubbleSprites;

    Animation anim;

	// Use this for initialization
	void Start ()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = bubbleSprites[Random.Range(0, bubbleSprites.Length)];
        anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!anim.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
