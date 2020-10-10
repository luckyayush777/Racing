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
        TimeSinceGameStart.text = " " + timeSinceGameStart;
    }
}
