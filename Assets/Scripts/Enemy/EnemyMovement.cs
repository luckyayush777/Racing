using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    List<Transform> wayPoints = new List<Transform>();
    [SerializeField]
    private float carSpeed = 10.0f;
    private Rigidbody carBody;
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
        throwAwayMovement();
    }

    void AddToWayPoints()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("wayPoints"))
        {
            wayPoints.Add(g.transform);
        }
    }

    void CalculateDirectionToMove()
    {
        Vector3 currentPosition = carBody.transform.position;
        //1  - traverse through the list, the difference between the
        //     current position and the next waypoint, the vector
        //     difference is the direction to move and 
        //2  - if the difference in 
        //     positions is really less(the car reached the waypoint) then
        //     go to 1
        for(int i = 0; i < wayPoints.Count; i++)
        {
            Vector3 directionToMove = wayPoints[i].position - currentPosition;
            MoveCar(directionToMove);
        }
    }

    void MoveCar(Vector3 directionToMove)
    {
        carBody.transform.Translate(directionToMove * carSpeed * Time.deltaTime);
    }

    void throwAwayMovement()
    {
        Vector3 currentPosition = carBody.transform.position;
        Vector3 wayPointToMove = wayPoints[0].position;
        Vector3 dirToMove = wayPointToMove - currentPosition;
        Debug.DrawRay(currentPosition, dirToMove);
        transform.Translate(dirToMove * carSpeed * Time.deltaTime);
    }
}