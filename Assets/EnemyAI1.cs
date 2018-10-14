using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI1 : MonoBehaviour
{
    public Transform target;
    public float pathUpdateFrequency = 1.0f;
    public Color debugColor = Color.cyan;

    private NavMeshAgent agent;
    private float elapsed = 0.0f;

    void OnDrawGizmos()
    {
        for (int i = 0; i < agent.path.corners.Length - 1; i++)
        {
            Debug.DrawLine(agent.path.corners[i],agent.path.corners[i+1],debugColor);
        }
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        elapsed = pathUpdateFrequency;
    }

    public void Update()
    {
        UpdatePath();
    }

    public void UpdatePath()
    {
        // Update the way to the destination every pathUpdateFrequency seconds.
        elapsed += Time.deltaTime;

        if (elapsed > pathUpdateFrequency)
        {
            elapsed -= pathUpdateFrequency;

            agent.destination = target.position;
        }
    }
}
