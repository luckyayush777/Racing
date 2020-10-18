using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapTimer : MonoBehaviour
{
    public float timeSinceGameStart;
    public TextMeshProUGUI TimeSinceGameStart;
    


    // Start is called before the first frame update
    void Start()
    {
        timeSinceGameStart = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceGameStart += Time.deltaTime;
        //float seconds_float = timeSinceGameStart % 60;
        string minutes = Mathf.Floor(timeSinceGameStart / 60).ToString("00");
        string seconds = (timeSinceGameStart % 60).ToString("00");
        TimeSinceGameStart.text = minutes + ":" + seconds;
    }


}
