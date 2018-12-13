using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketReaction : MonoBehaviour
{

    public GameObject rocketPrefab;

    public CapsuleCollider2D collider;

    // Use this for initialization
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<RocketController>() != null)
        {
            Destroy(other.gameObject);

            if (other.CompareTag("Rocket"))
            {
                if (gameObject.transform.parent.gameObject.tag == "TradeShip")
                {
                    staticElement.ModifyRep(-300);
                }
                Destroy(gameObject.transform.parent.gameObject);
           }
        }
    }


}
