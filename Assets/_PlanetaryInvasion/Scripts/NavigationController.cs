using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ClickToMove.cs
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationController : MonoBehaviour
{
    public string spawner_Tag;
    public string wander_tag;

    private Vector3 pos;
    private bool reached_mid = false;
    private bool left_mid = false;

    [SerializeField]
    Animator anim;
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    

    void Start() {
        GameObject[] midPoint = GameObject.FindGameObjectsWithTag(wander_tag);
        Transform goal = midPoint[Random.Range(0, midPoint.Length)].transform;
        
        //Vector3 s = goal.position;
        pos = RandomizedPos(goal);

        agent.destination = pos;
        agent.updatePosition = false;

    }

    void Update()
    {
        ProcessStep();

        if (Vector3.Distance(this.pos, this.gameObject.transform.position) < 1 && !reached_mid) {
            agent.destination = this.gameObject.transform.position;
            agent.isStopped = true;
            ProcessStep();
            reached_mid = true;
            StartCoroutine("Fade");
        }
        if (Vector3.Distance(this.pos, this.gameObject.transform.position) < 1 && left_mid) {
            DestroyObject(); // does not destroy the object, makes a check as well
        }
    }

    IEnumerator Fade() {
        yield return new WaitForSeconds(1.03f * Random.Range(1, 3));
        if (Random.value < 0.4f) {
            GameObject[] midPoint = GameObject.FindGameObjectsWithTag(wander_tag);
            Transform goal = midPoint[Random.Range(0, midPoint.Length)].transform;
            pos = RandomizedPos(goal);
            left_mid = false;
            reached_mid = false;
            agent.isStopped = false;
            agent.destination = pos;
        }
        else {
            GameObject[] destinationPoints = GameObject.FindGameObjectsWithTag(spawner_Tag);
            Transform goal = destinationPoints[Random.Range(0, destinationPoints.Length)].transform;
            pos = goal.position;
            agent.isStopped = false;
            agent.destination = pos;
            left_mid = true;
        }
    }

    void OnAnimatorMove() {
        // Update position to agent position
        this.gameObject.transform.position = agent.nextPosition;
    }

    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void ProcessStep() {
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        // Update object direcion based on velocity
        // Normally velocity should be checked otherwise, but my animation is
        // pointing to the right by default.
        if (velocity.x < 0f && !m_FacingRight) Flip();
        else if (velocity.x > 0f && m_FacingRight) Flip();

        bool shouldMove = velocity.magnitude > 0.1f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        anim.SetBool("move", shouldMove);
    }

    private void DestroyObject() {
        if (Vector3.Distance(this.pos, this.gameObject.transform.position) < 1)
        {
            Destroy(this.gameObject);
        }
    }

    private Vector3 RandomizedPos(Transform goal) {
        Bounds goal_bounds = goal.GetComponent<BoxCollider>().bounds;
		pos = goal.position + new Vector3(Random.Range(-goal_bounds.size.x / 2, goal_bounds.size.x / 2),
                                                  Random.Range(-goal_bounds.size.y / 2, goal_bounds.size.y / 2),
                                                  Random.Range(-goal_bounds.size.z / 2, goal_bounds.size.z / 2));
        return pos;
    }
}