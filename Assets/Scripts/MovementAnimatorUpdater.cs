using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class MovementAnimatorUpdater : MonoBehaviour
{

    protected Animator animator;
    protected NavMeshAgent agent;
	public float animationSpeed;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    
    public void Update()
    {

		animationSpeed = (agent.velocity.sqrMagnitude / (agent.speed * agent.speed));
		animator.SetFloat( "speed", ( animationSpeed ) );
        animator.SetBool( "jumping", agent.isOnOffMeshLink );
    }
}
