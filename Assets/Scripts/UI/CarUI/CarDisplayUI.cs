using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarDisplayUI : MonoBehaviour
{
    private int playerCarSpeed;
    public TextMeshProUGUI playerSpeedText;
    private GameObject playerCar;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCar = GameObject.FindGameObjectWithTag("Player");
        if (!playerCar)
            Debug.Log("Couldnt find the object CarMovement Script is attached to");
        //CarMovement carMovement = playerCar.GetComponent<CarMovement>();
        //playerCarSpeed = (int)playerCar.GetComponent<CarMovement>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        playerCarSpeed = (int)playerCar.GetComponent<CarMovement>().speed;
        //Debug.Log(playerCarSpeed);
        playerSpeedText.text = "" + playerCarSpeed;
    }
}
