using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndgameText : MonoBehaviour
{
    public TextMeshProUGUI EndgameTextHolder;
    string endgameText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(EndpointBehaviour.hasPlayerWon && EndpointBehaviour.raceEnded)
       {
            endgameText = "You Won!";
       }else if(!EndpointBehaviour.hasPlayerWon && EndpointBehaviour.raceEnded)
       {
            endgameText = "You lost!";
       }
        HolderSetup(endgameText);
    }

    private void HolderSetup(string endgameMessage)
    {
        EndgameTextHolder.text = endgameMessage;
    }
}
