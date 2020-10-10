using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GearDisplay : MonoBehaviour
{
    private int playerCarGear;
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
       playerCarGear = (int)playerCar.GetComponent<CarMovement>().currentGear;
        //Debug.Log(playerCarSpeed);
        playerSpeedText.text = "" +playerCarGear;
    }
}
