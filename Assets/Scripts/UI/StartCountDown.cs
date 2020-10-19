using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCountDown : MonoBehaviour
{
    public TextMeshProUGUI startCountDownText;
    private float startCountDown = 4;
    public bool CountDownEnded = false;

    // Start is called before the first frame update
    void Start() => StartCoroutine(Countdown());
    

    // Update is called once per frame
    void Update()
    {
    }

   
    IEnumerator Countdown()
    {
        while(startCountDown > 1)
        {
            startCountDown -= 1;
            startCountDownText.text = startCountDown.ToString("0");
            yield return new WaitForSeconds(1);
        }
        if(startCountDown == 1)
        {
            startCountDownText.text = "GO!";
            yield return new WaitForSeconds(1);
            CountDownEnded = true;
        }
    }
    
  
}
