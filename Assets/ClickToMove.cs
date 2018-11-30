using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ClickToMove.cs
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class ClickToMove : MonoBehaviour {

    public Transform goal;
       
    void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position; 
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