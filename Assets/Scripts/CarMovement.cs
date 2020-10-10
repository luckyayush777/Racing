using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [System.Serializable]
    public struct AccelerationOnSpecificGears
    {
        public float accelerationOnFirstGear;
        public float accelerationOnSecondGear;
        public float accelerationOnThirdGear;
        public float accelerationOnFourthGear;
        public float accelerationOnFifthGear;
    }
    [System.Serializable]
    public struct SpeedOnSpecificGears
    {
        public float firstGearMaxSpeed;
        public float secondGearMaxSpeed;
        public float thirdGearMaxSpeed;
        public float fourthGearMaxSpeed;
        public float fifthGearMaxSpeed;
    }




    public float speed;
    public float maxSpeed;
    public int currentGear;
    [SerializeField]
    private AccelerationOnSpecificGears accelerationOnSpecificGears = new AccelerationOnSpecificGears();
    [SerializeField]
    private SpeedOnSpecificGears speedOnSpecificGears = new SpeedOnSpecificGears();
    [SerializeField]
    private float breakingConstant = 0;
    public float acceleration;
    public bool isAccelerating = false;
    public bool hasStartedMovement = false;
    //speed has to decrease due to static/dynamic friction and other reasons
    public float speedReductionConstant;


    public float rotationAmountOnTurn;
    // imagine an arc in front of a car, car cant turn 360 degrees, it will only turn in that arc

    public float maxCarTurnRadius;
    public float minCarTurnRadius;
    private Rigidbody carBody;
    Vector3 rotation;

    //variables for checking how much time a key was pressed for
    private float accelerationTimer;
    private float deAccelerationTimer;
    void Start()
    {
        carBody = GetComponent<Rigidbody>();
        rotation = new Vector3(0.0f, 0.0f, rotationAmountOnTurn);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(speed > 0)
        speed -= speedReductionConstant;
        if (speed < 0)
            speed = 0;
        if (Input.GetKeyDown(KeyCode.W))
        {
            hasStartedMovement = true;
            accelerationTimer = 0;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            speed -= speed * breakingConstant;
            isAccelerating = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            deAccelerationTimer = 0;
        }
        if (Input.GetKey(KeyCode.W))
        {
            isAccelerating = true;
            //implementation of final speed = initial speed + acceleration * time W was pressed
            accelerationTimer += Time.deltaTime;
            acceleration = CalculateAcceleratiom(currentGear);
            speed += acceleration * accelerationTimer;
            //some limit on max speed
            if (speed >= maxSpeed)
                speed = maxSpeed;
            carBody.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            deAccelerationTimer += Time.deltaTime;
            speed -= acceleration * deAccelerationTimer;
            carBody.transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            carBody.transform.Rotate(-rotation);
        }
        if (Input.GetKey(KeyCode.D))
        {
            carBody.transform.Rotate(rotation);
        }
        ShowGearInfo();
    }

    private void ShowGearInfo()
    {
        if (speed <= speedOnSpecificGears.firstGearMaxSpeed)
        {
            currentGear = 1;
        }
        else if (speed <= speedOnSpecificGears.secondGearMaxSpeed)
        {
            currentGear = 2;
        }
        else if (speed <= speedOnSpecificGears.thirdGearMaxSpeed)
        {
            currentGear = 3;
        }
        else if (speed <= speedOnSpecificGears.fourthGearMaxSpeed)
        {
            currentGear = 4;
        }
        else if (speed <= speedOnSpecificGears.fifthGearMaxSpeed)
        {
            currentGear = 5;
        }
        //Debug.Log("Current Gear :" + currentGear);
    }

    private float CalculateAcceleratiom(int currentGear)
    {
        float accelerationBase = 0;
        switch (currentGear)
        {
            case 1: accelerationBase = accelerationOnSpecificGears.accelerationOnFirstGear;
                break;
            case 2: accelerationBase = accelerationOnSpecificGears.accelerationOnSecondGear;
                break;
            case 3: accelerationBase = accelerationOnSpecificGears.accelerationOnThirdGear;
                break;
            case 4: accelerationBase = accelerationOnSpecificGears.accelerationOnFourthGear;
                break;
            case 5: accelerationBase = accelerationOnSpecificGears.accelerationOnFifthGear;
                break;
            default: Debug.LogError("SOMETHINGS WRONG! INPUT DATA TO THE ACCELERATION COUNT NOT PROPER");
                break;
        }
        return accelerationBase;

    }

   public float returnSpeed()
    {
        return speed;
    }

}
