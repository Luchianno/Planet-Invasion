using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ClickToMove.cs
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]
public class NavigationController : MonoBehaviour {
    
    //public Transform[] destinationPoints; 
    private Transform goal;
    private Animator anim;
    private NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    public Vector2 mognitud;
    public Vector2 mognitud2;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    void Start () {
        anim = GetComponent<Animator> ();
        GameObject[] destinationPoints = GameObject.FindGameObjectsWithTag("alien_spawner");
        goal = destinationPoints[Random.Range(0, destinationPoints.Length)].transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        agent.updatePosition = false;
    }

    void Update () {
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
        

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot (transform.right, worldDeltaPosition);
        float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2 (dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
        smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;
        
        // Update object direcion based on velocity
        // Normally velocity should be checked otherwise, but my animation is
        // pointing to the right by default.
        if (velocity.x < 0f && !m_FacingRight) Flip();
        else if (velocity.x > 0f && m_FacingRight) Flip();

        mognitud = velocity;
        mognitud2 = smoothDeltaPosition;

        bool shouldMove = velocity.magnitude > 0.1f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        anim.SetBool("move", shouldMove);

        if (Vector3.Distance(this.goal.position, this.gameObject.transform.position) < 1) {
            Destroy(this.gameObject);
        }
        //this.GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;
    }

    void OnAnimatorMove ()
    {
        // Update position to agent position
        this.gameObject.transform.position = agent.nextPosition;
    }

    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}