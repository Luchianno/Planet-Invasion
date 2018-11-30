using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ClickToMove.cs
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class NavigationController : MonoBehaviour {
    
    //public Transform[] destinationPoints; 
    private Transform goal;

    void Start () {
        GameObject[] destinationPoints = GameObject.FindGameObjectsWithTag("alien_spawner");
        goal = destinationPoints[Random.Range(0, destinationPoints.Length-1) % destinationPoints.Length -1].transform;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Update () {
        if (Vector3.Distance(goal.position, this.gameObject.transform.position) < 5) {
            Destroy(this.gameObject);
        }
    } 

    /*RaycastHit hitInfo = new RaycastHit();
    NavMeshAgent agent;

    void Start () {
        agent = GetComponent<NavMeshAgent> ();
    }
    void Update () {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                agent.destination = hitInfo.point;
        }
    }*/
}