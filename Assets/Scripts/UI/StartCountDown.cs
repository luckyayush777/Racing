using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCountDown : MonoBehaviour
{
    public TextMeshProUGUI startCountDownText;
    private float startCountDown = 3;
    public bool CountDownEnded = false;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (startCountDown > 1)
        { 
            startCountDown -= Time.deltaTime;
            startCountDownText.text = startCountDown.ToString("0");
        }
        else
        {
            startCountDownText.text = "GO!";
            CountDownEnded = true;
        }
    }

   

  
}
