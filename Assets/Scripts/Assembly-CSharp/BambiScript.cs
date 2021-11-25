using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BambiScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.agent = base.GetComponent<NavMeshAgent>(); //Get AI Agent
        this.audioDevice = base.GetComponent<AudioSource>();
        this.Wander(); //Start wandering
    }

    // Update is called once per frame
    void Update()
    {
        if (this.coolDown > 0f)
        {
            this.coolDown -= 1f * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (this.playerSeen)
        {
            bambiRenderer.sprite = marcellohappy;
        }
        else
        {
            bambiRenderer.sprite = marcellosad;
        }
        Vector3 direction = this.player.position - base.transform.position;
        RaycastHit raycastHit;
        if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player" & (base.transform.position - this.player.position).magnitude <= 80f)
        {
            //If playtime sees the player, she chases after them
            this.playerSeen = true;
            this.TargetPlayer();
        }
        else if (this.playerSeen & this.coolDown <= 0f)
        {
            //If the player seen cooldown expires, she will just start wandering again
            this.playerSeen = false;
            this.Wander();
        }
        else if (this.agent.velocity.magnitude <= 1f & this.coolDown <= 0f)
        {
            this.Wander();
        }
    }

    private void TargetPlayer()
    {
        this.agent.SetDestination(this.player.position); // Go after the player
        this.agent.speed = 20f; // Speed up
        this.coolDown = 0.2f;
        if (!this.playerSpotted)
        {
            this.playerSpotted = true;
            this.audioDevice.PlayOneShot(this.aud_Laugh);
        }
    }

    private void Wander()
    {
        this.wanderer.GetNewTargetHallway();
        this.agent.SetDestination(this.wanderTarget.position);
        this.agent.speed = 15f;
        this.playerSpotted = false;
        this.coolDown = 1f;
    }


    public SpriteRenderer bambiRenderer;

    public Sprite marcellosad;

    public Sprite marcellohappy;

    // Token: 0x04000055 RID: 85
    public Transform player;

    // Token: 0x04000056 RID: 86
    public PlayerScript ps;

    // Token: 0x04000057 RID: 87
    public Transform wanderTarget;

    // Token: 0x04000058 RID: 88
    public AILocationSelectorScript wanderer;

    // Token: 0x04000059 RID: 89
    public float coolDown;

    public bool playerSeen;

    public bool playerSpotted;

    private NavMeshAgent agent;

    public AudioSource audioDevice;

    public AudioClip aud_Laugh;
}
