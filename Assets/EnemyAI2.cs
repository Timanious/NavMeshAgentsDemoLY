using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI2 : MonoBehaviour
{
    public Transform target;
    public float pathUpdateFrequency = 1.0f;
    public Color debugColor = Color.cyan;

    private NavMeshAgent agent;

    void OnDrawGizmos()
    {
        for (int i = 0; i < agent.path.corners.Length - 1; i++)
        {
            Debug.DrawLine(agent.path.corners[i], agent.path.corners[i + 1], debugColor);
        }
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(pathUpdateFrequency);
            agent.destination = target.position;
        }
    }
}
