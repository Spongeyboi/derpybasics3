using System;
using UnityEngine;
using UnityEngine.AI;

public class blankAiScript : MonoBehaviour
{
    // Blank AIs are characters in game the serve no purpose but to just walk around.
    // There literally is nothing interesting about them.
    // Sorry about that.

    // Start is called before the first frame update
    void Start()
    {
        this.agent = base.GetComponent<NavMeshAgent>();
        this.Wander();
    }

    public void Update()
    {
        if (this.coolDown > 0f)
        {
            this.coolDown -= 1f * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
        {
            this.Wander();
        }
    }

    private void Wander()
    {
        this.wanderer.GetNewTargetHallway();
        this.agent.SetDestination(this.wanderTarget.position);
        this.agent.speed = 15f;
        this.coolDown = 1f;
    }


    private NavMeshAgent agent;

    public AILocationSelectorScript wanderer;

    public Transform wanderTarget;

    public float coolDown;
}
