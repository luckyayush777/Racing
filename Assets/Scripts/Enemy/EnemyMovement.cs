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
    static int i = 0;
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

    void AddToWayPoints()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("wayPoints"))
        {
            wayPoints.Add(g.transform);
        }
    }
    void MovementToWayPoints()
    {
        //start moving to the waypoint
        //if reached waypoint
        //move to the next waypoint
        Vector3 target = wayPoints[i].position;
        Vector3 dirToMove = (target - carBody.transform.position);
        if (wayPoints[i].position.z - carBody.transform.position.z <= 0.2f && i < wayPoints.Count - 1)
        {
            i++;
        }
        carBody.transform.Translate(dirToMove.normalized * Time.deltaTime * carSpeed, Space.World);
    }
}