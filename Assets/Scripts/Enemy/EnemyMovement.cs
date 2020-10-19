using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    List<Transform> wayPoints = new List<Transform>();
    private Vector3 target;
    private Vector3 dirToMove;


    [SerializeField]
    private float carSpeed = 10.0f;
    [SerializeField]
    private int maxSpeedAmount = 0;
    private Rigidbody carBody;
    [SerializeField]
    private float accelerationAmount = 0;

    static int i = 0;

    void AddToWayPoints()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("wayPoints"))
        {
            wayPoints.Add(g.transform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        carBody = GetComponent<Rigidbody>();
        if(!carBody)
        {
            Debug.Log("Couldnt attach rigidBody");
        }
        AddToWayPoints();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MovementToWayPoints();
    }

 
    void MovementToWayPoints()
    { 
        if( i != wayPoints.Count)
        target = wayPoints[i].position;
        else if (i == wayPoints.Count)
        {
            carSpeed = 0;
            target = Vector3.zero;
        }
        if (i != wayPoints.Count)
            dirToMove = (target - carBody.transform.position);
        else
            dirToMove = Vector3.zero;
        if (i < wayPoints.Count && wayPoints[i].position.z - carBody.transform.position.z <= 0.2f  )
        {
            i++;
        }
        carBody.transform.Translate(dirToMove.normalized * Time.deltaTime * carSpeed, Space.World);
        if(carSpeed <= maxSpeedAmount)
        {
            Accelerate();
        }
    }

    void Accelerate()
    {
        carSpeed += accelerationAmount * Time.deltaTime;
    }
}