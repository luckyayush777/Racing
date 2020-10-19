using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Canvas beforeStartCanvas = null;
    [SerializeField]
    private Canvas gameProgressCanvas = null;
    [SerializeField]
    private Canvas EndgameCanvas = null;
    public GameObject countDownReference;
    public bool countDownEnded = false;
    
    void InitialisationSetup()
    {
        beforeStartCanvas.enabled = true;
        gameProgressCanvas.enabled = false;
        EndgameCanvas.enabled = false;
        
    }
    // Start is called before the first frame update
    void Start()
    {
       InitialisationSetup();
    }

    // Update is called once per frame
    void Update()
    {
        countDownEnded = countDownReference.GetComponent<StartCountDown>().CountDownEnded;
        if (countDownEnded)
        {
            if(beforeStartCanvas.enabled == true && gameProgressCanvas.enabled == false)
            gameProgressCanvas.enabled = true;
            beforeStartCanvas.enabled = false;
        }
        if(EndpointBehaviour.hasPlayerWon)
        {
            gameProgressCanvas.enabled = false;
            beforeStartCanvas.enabled = false;
            EndgameCanvas.enabled = true;
        }
        else if(!EndpointBehaviour.hasPlayerWon && EndpointBehaviour.raceEnded)
        {
            gameProgressCanvas.enabled = false ;
            beforeStartCanvas.enabled = false;
            EndgameCanvas.enabled = true;
        }
    }

}
