using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshPatroller : MonoBehaviour
{
    public Transform[] patrolPoints;

    protected int pointIndex;

    protected NavMeshAgent agent;

	public float DistanceReqFromTarget = 0.0f;

    public void Awake ()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Start ()
    {
        pointIndex = 0;
    }
    
    public void Update ()
    {
		if ( agent.remainingDistance <= DistanceReqFromTarget )
        {
            PatrolTo( (pointIndex + 1) % patrolPoints.Length );
        }
        else
        {
            agent.destination = patrolPoints[pointIndex].position;
        }
    }

    public void PatrolTo( int newPointIndex )
    {
        pointIndex = newPointIndex;
        agent.destination = patrolPoints[pointIndex].position;
    }
}
