using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]

public class Jumper : MonoBehaviour {
	protected Rigidbody body;

	protected NavMeshAgent agent;

	public Animator animator;

	public float jumpImpulse = 10.0f;

	private bool jumping = false;

	// Use this for initialization
	public void Start () 
	{
		body = GetComponent<Rigidbody> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			if (!jumping)
			{
				animator.SetBool( "jumping", true );
				jumping = true;
				Invoke("Jump",0.5f);
//				Jump ();		
			}

		}
	}
	public void Jump () 
	{
		agent.enabled = false;
		body.isKinematic = false;
//		animator.SetBool( "jumping", true );
		animator.SetBool ("jumpEnd", false);
		body.AddForce (Vector3.up * jumpImpulse);

	}

	public void OnCollisionEnter(Collision other)
	{
		if (jumping) 
		{
			agent.enabled = true;
			body.isKinematic = true;
			Invoke ("JumpEnder", 1.5f);
//			animator.SetTrigger ("jumpingEnd");
			animator.SetBool ("jumpEnd", true);
		}
	}
	public void JumpEnder()
	{
		jumping = false;
	}
}
//somethign

