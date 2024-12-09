using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINav : MonoBehaviour
{

    public NavMeshAgent agent;

    public GameObject player;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 destination;
    bool walkPointSet;

    [SerializeField] float range;

    public AudioSource coworkerAudio;
    public AudioClip ouch;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //player = GameObject.Find("Player");
        coworkerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    public void Patrol()
    {
        if (!walkPointSet)
        {
            SearchForDest();
        }

        if (walkPointSet)
        {
            agent.SetDestination(destination);
        }

        if (Vector3.Distance(transform.position, destination) < 10)
        {
            walkPointSet = false;
        }
    }

    public void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destination = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destination, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }
}
