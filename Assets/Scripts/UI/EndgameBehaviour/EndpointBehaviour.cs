using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointBehaviour : MonoBehaviour
{
    public static bool hasPlayerWon;
    public static bool raceEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("ENEMY WON!");
            hasPlayerWon = false;
            raceEnded = true;
        }else if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player Won!");
            hasPlayerWon = true;
            raceEnded = true;
        }
    }
}
